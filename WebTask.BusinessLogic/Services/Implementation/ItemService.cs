using System;
using System.Collections.Generic;
using System.Linq;
using WebTask.Core.Extensions;
using WebTask.Core.ViewModels;
using WebTask.DataAccess;

namespace WebTask.BusinessLogic.Services.Implementation
{
    public class ItemService : IItemService
    {
        public UnitOfWork unitOfWork = new UnitOfWork();

        public void Add(ItemViewModel model)
        {
            this.unitOfWork.ItemRepository.Insert(model.ToDbObject());
        }

        public void Delete(int id)
        {
            this.unitOfWork.ItemRepository.Delete(id);
        }

        public ItemViewModel GetDetails(int id)
        {
            return this.unitOfWork.ItemRepository.GetDetails(id).ToViewModel();
        }

        public IEnumerable<ItemViewModel> GetList(Guid? userId = null)
        {
            return this.unitOfWork.ItemRepository.GetList()
                .Select(x => x.ToViewModel());
        }

        public void Update(ItemViewModel model)
        {
            this.unitOfWork.ItemRepository.Update(model.ToDbObject());
        }
    }
}
