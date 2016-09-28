using System.Web.Mvc;
using Core;
using Management;
using WMI;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        // before adding dependency injection (Autofac)
        //public HomeController()
        //{
        //    Manager.CreateInstance(new DataManager(), new WmInfo());
        //}
        public HomeController(IDataManager dataManager)
        {
            Manager.CreateInstance(dataManager as DataManager, new WmInfo());
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
