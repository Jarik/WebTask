using System;
using WebTask.DataAccess.Repositories.Implementation;

namespace WebTask.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private WebTaskEntities context = new WebTaskEntities();

        private ItemRepository _itemRepository;

        public ItemRepository ItemRepository
        {
            get
            {
                if (_itemRepository == null)
                {
                    _itemRepository = new ItemRepository(context);
                }

                return _itemRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
