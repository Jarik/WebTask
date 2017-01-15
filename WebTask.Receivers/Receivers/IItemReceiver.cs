using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTask.Core.ViewModels;

namespace WebTask.Receivers.Receivers
{
    public interface IItemReceiver
    {
        Task Add(ItemViewModel model);

        Task Update(ItemViewModel model);

        Task Delete(int id);

        Task<IEnumerable<ItemViewModel>> GetList();

        Task<ItemViewModel> GetDetails(int id);
    }
}
