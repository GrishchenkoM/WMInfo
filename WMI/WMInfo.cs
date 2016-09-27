using System.Collections.Generic;
using System.Linq;
using System.Management;
using Core;
using Core.Entities;

namespace WMI
{
    /// <summary>
    /// WMI data reading class
    /// </summary>
    public class WmInfo : IGetInfo
    {
        public EntitiesModel GetInfo()
        {
            var model = new EntitiesModel {Manufacturer = new Manufacturer()};

            var manufacturer = GetInfo("Win32_Processor", "Manufacturer");
            if (manufacturer.Any())
            {
                model.Manufacturer.Name = manufacturer[0];
            }

            model.Computer = new Computer();
            var computerName = GetInfo("Win32_ComputerSystem", "Name");
            if (computerName.Any())
            {
                model.Computer.Name = computerName[0];
            }

            model.Users = new List<User>();
            var userNames = GetInfo("Win32_UserAccount", "Name");
            if (userNames.Any())
                foreach (var name in userNames)
                {
                    model.Users.Add(new User() {Name = name});
                }

            return model;
        }

        private List<string> GetInfo(string fromWin32Class, string classItemAdd)
        {
            List<string> result = new List<string>();
            ManagementObjectSearcher searcher =
            new ManagementObjectSearcher("SELECT * FROM " + fromWin32Class);
            try
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    result.Add(obj[classItemAdd].ToString().Trim());
                }
            }
            catch
            {
                // ignored
            }

            return result;
        }
    }
}
