using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageCommnetRepository
    {
        IEnumerable<PageComment> GetCommnetByNewId(int pageId);

        bool AddCommnet(PageComment commnet);

        

    }
}
