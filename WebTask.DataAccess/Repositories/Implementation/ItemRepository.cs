using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTask.DataAccess.Repositories.Implementation
{
    public class ItemRepository : BaseRepository<Item>, IDisposable
    {
        public WebTaskEntities WebTaskEntities { get; set; }

        public ItemRepository(WebTaskEntities context) : base(context)
        {
            this.WebTaskEntities = context;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.WebTaskEntities.Dispose();
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
