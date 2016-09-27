using System.Collections.Generic;
using Core.Entities;

namespace Core
{
    public class EntitiesModel
    {
        public Computer Computer { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public IList<User> Users { get; set; }
    }
}
