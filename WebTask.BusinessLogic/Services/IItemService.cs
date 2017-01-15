using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTask.Core.ViewModels;

namespace WebTask.BusinessLogic.Services
{
    public interface IItemService
    {
        void Add(ItemViewModel model);

        void Update(ItemViewModel model);

        void Delete(int id);

        IEnumerable<ItemViewModel> GetList(Guid? userId = null);

        ItemViewModel GetDetails(int id);
    }
}
