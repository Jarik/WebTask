using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebTask.Core.ViewModels;

namespace WebTask.Receivers.Receivers.Implementation
{
    public class ItemReceiver : BasicReceiver, IItemReceiver
    {
        const string Path = "items";

        public async Task Add(ItemViewModel model)
        {
            var result = await base.Add<ItemViewModel>(Path, model);
        }

        public async Task Delete(int id)
        {
            string path = Path + $"/{id}";

            var result = await base.Delete(path);
        }

        public async Task<ItemViewModel> GetDetails(int id)
        {
            string path = Path + $"/{id}";

            var result = await base.Get(path);

            ItemViewModel details = new ItemViewModel();

            if (result.IsSuccessStatusCode)
            {
                details = await result.Content.ReadAsAsync<ItemViewModel>();
            }

            return details;
        }

        public async Task<IEnumerable<ItemViewModel>> GetList()
        {
            var result = await base.Get(Path);

            IEnumerable<ItemViewModel> list = new List<ItemViewModel>();

            if (result.IsSuccessStatusCode)
            {
                list = await result.Content.ReadAsAsync<IEnumerable<ItemViewModel>>();
            }

            return list;
        }

        public async Task Update(ItemViewModel model)
        {
            string path = Path + $"/{model.Id}";

            var result = await base.Update<ItemViewModel>(path, model);
        }
    }
}
