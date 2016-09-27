using System.Web.Mvc;
using Core;
using Management;
using WMI;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            Manager.CreateInstance(new DataManager(), new WmInfo());
        }
        public HomeController(DataManager dataManager)
        {
            Manager.CreateInstance(dataManager, new WmInfo());
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
