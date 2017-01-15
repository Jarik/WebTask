using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebTask.Core.ViewModels;
using WebTask.Receivers.Receivers;
using WebTask.Receivers.Receivers.Implementation;

namespace WebTask.Web.Controllers
{
    public class ItemsController : Controller
    {
        public IItemReceiver ItemReceiver = new ItemReceiver();

        public async Task<ActionResult> Index()
        {
            var itemList = await this.ItemReceiver.GetList();

            return View(itemList.ToList());
        }

        public async Task<ActionResult> Edit(int id)
        {
            var details = await this.ItemReceiver.GetDetails(id);

            return View(details);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ItemViewModel model)
        {
            await this.ItemReceiver.Update(model);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> View(int id)
        {
            var details = await this.ItemReceiver.GetDetails(id);

            return View(details);
        }

        public async Task<ActionResult> Delete(int id)
        {
            await this.ItemReceiver.Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ItemViewModel model)
        {
            await this.ItemReceiver.Add(model);

            return RedirectToAction("Index");
        }
    }
}