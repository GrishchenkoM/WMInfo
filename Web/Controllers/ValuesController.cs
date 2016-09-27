using System.Web.Http;
using System.Web.Http.Results;
using Core;
using Web.Models;

namespace Web.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly DataManager _dataManager;
        public ValuesController()
        {
            _dataManager = new DataManager();
        }
        public ValuesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        
        // GET api/values
        public IHttpActionResult Get()
        {
            var model = new ViewModel(_dataManager).GetModel;
            if (model.Users != null && model.Computer != null && model.Manufacturer != null)
                return Ok(model);

            return new InternalServerErrorResult(Request);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
