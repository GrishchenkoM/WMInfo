using System.Web.Http;
using System.Web.Http.Results;
using Core;
using Web.Models;

namespace Web.Controllers
{
    public class ValuesController : ApiController
    {
        // before adding dependency injection (Autofac)
        //public ValuesController()
        //{
        //    _dataManager = new DataManager();
        //}
        public ValuesController(IDataManager dataManager)
        {
            _dataManager = dataManager as DataManager;
        }
        
        // GET api/values
        public IHttpActionResult Get()
        {
            var model = new ViewModel(_dataManager).GetModel;
            if (model.Users != null && model.Computer != null && model.Manufacturer != null)
                return Ok(model);

            return new InternalServerErrorResult(Request);
        }

        private readonly DataManager _dataManager;
    }
}
