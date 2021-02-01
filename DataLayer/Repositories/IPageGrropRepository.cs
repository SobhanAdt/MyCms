using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageGrropRepository:IDisposable
    {
        IEnumerable<PageGroup> GetAllGroups();

        PageGroup GetGroupbyId(int groupId);

        bool InsertGroup(PageGroup pageGroup);

        bool UpdateGroup(PageGroup pageGroup);

        bool DeleteGroup(PageGroup pageGroup);

        bool DeleteGroup(int groupId);

        void save();

        IEnumerable<ShowGroupsViewModel> GetGroupsForView();

    }
}
