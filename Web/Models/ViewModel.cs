using System.Linq;
using Core;

namespace Web.Models
{
    public class ViewModel
    {
        private readonly DataManager _manager;
        public EntitiesModel GetModel { get; private set; }

        public ViewModel(DataManager manager)
        {
            _manager = manager;
            //Manager.GetInstance().Manage();
            FillModel();
        }

        private void FillModel()
        {
            try
            {
                GetModel = new EntitiesModel()
                {
                    Manufacturer = _manager.Manufacturers.Get().FirstOrDefault(),
                    Computer = _manager.Computers.Get().FirstOrDefault(),
                    Users = _manager.Users.Get().ToList()
                };
            }
            catch
            {
                // ignored
            }
        }
    }
}