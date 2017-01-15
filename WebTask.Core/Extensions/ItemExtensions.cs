using WebTask.DataAccess;
using WebTask.Core.ViewModels;

namespace WebTask.Core.Extensions
{
    public static class ItemExtensions
    {
        public static ItemViewModel ToViewModel(this Item dbObject)
        {
            if (dbObject == null)
            {
                return null;
            }

            return new ItemViewModel
            {
                CreatedBy = dbObject.CreatedBy,
                Id = dbObject.Id,
                Name = dbObject.Name
            };
        }

        public static Item ToDbObject(this ItemViewModel viewModel)
        {
            if (viewModel == null)
            {
                return null;
            }

            return new Item
            {
                CreatedBy = viewModel.CreatedBy,
                Id = viewModel.Id,
                Name = viewModel.Name
            };
        }
    }
}
