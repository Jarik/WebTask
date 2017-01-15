using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebTask.BusinessLogic.Services;
using WebTask.BusinessLogic.Services.Implementation;
using WebTask.Core.ViewModels;

namespace WebTask.API.Controllers
{
    public class ItemsController : ApiController
    {
        public IItemService ItemService = new ItemService();

        // GET: api/Items
        public IHttpActionResult Get()
        {
            var list = this.ItemService.GetList();

            return Ok(list);
        }

        // GET: api/Items/5
        public IHttpActionResult Get(int id)
        {
            var details = this.ItemService.GetDetails(id);

            return Ok(details);
        }

        // POST: api/Items
        public IHttpActionResult Post([FromBody]ItemViewModel model)
        {
            this.ItemService.Add(model);

            return Ok();
        }

        // PUT: api/Items/5
        public IHttpActionResult Put(int id, [FromBody]ItemViewModel model)
        {
            model.Id = id;

            this.ItemService.Update(model);

            return Ok();
        }

        // DELETE: api/Items/5
        public IHttpActionResult Delete(int id)
        {
            this.ItemService.Delete(id);

            return Ok();
        }
    }
}
