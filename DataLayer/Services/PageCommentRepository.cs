using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageCommentRepository : IPageCommnetRepository
    {
        private MyCmsContext db;

        public PageCommentRepository(MyCmsContext context)
        {
            db = context;
        }

        public bool AddCommnet(PageComment commnet)
        {
            try
            {
                db.PageComments.Add(commnet);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public IEnumerable<PageComment> GetCommnetByNewId(int pageId)
        {
            return db.PageComments.Where(c => c.PageID == pageId);
        }
    }
}
