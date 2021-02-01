using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace MyCms.Controllers
{
    public class NewsController : Controller
    {
        MyCmsContext db=new MyCmsContext();

        private IPageGrropRepository pageGrropRepository;

        private IPageRepository pageRepository;

        private IPageCommnetRepository pageCommnetRepository;
        public NewsController()
        {
            pageGrropRepository=new PageGroupRepository(db);
            pageRepository=new PageRepository(db);
            pageCommnetRepository=new PageCommentRepository(db);
        }
        // GET: News
        public ActionResult ShowGroups()
        {
            return PartialView(pageGrropRepository.GetGroupsForView());
        }

        public ActionResult ShowGroupsInMenu()
        {
            return PartialView(pageGrropRepository.GetAllGroups());
        }

        public ActionResult topNews()
        {
            return PartialView(pageRepository.TopNews());
        }

        public ActionResult LatesNews()
        {
            return PartialView(pageRepository.LastNews());
        }

        [Route("Archive")]
        public ActionResult ArchiveNews()
        {
            return View(pageRepository.GetAllPage());
        }

        [Route("Group/{id}/{title}")]
        public ActionResult ShowNewsByGroupId(int id, string title)
        {
            ViewBag.name = title;
            return View(pageRepository.ShowPageByGroupId(id));
        }

        [Route("News/{id}")]
        public ActionResult ShowNews(int id)
        {
            var news = pageRepository.GetPageById(id);

            if (news == null)
            {
                return HttpNotFound();
            }

            news.Visit += 1;
            pageRepository.UpdatePage(news);
            pageRepository.Save();

            return View(news);
        }

        public ActionResult AddCommnet(int id, string name, string email, string commnet)
        {
            PageComment addcomment=new PageComment()
            {
                CreateDate=DateTime.Now,
                PageID=id,
                Comment=commnet,
                Email=email,
                Name = name
            };
            pageCommnetRepository.AddCommnet(addcomment);

            return PartialView("ShowComments", pageCommnetRepository.GetCommnetByNewId(id));
        }

        public ActionResult ShowComments(int id)
        {
            return PartialView(pageCommnetRepository.GetCommnetByNewId(id));
        }

    }
}