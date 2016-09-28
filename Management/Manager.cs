using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Core;
using Core.Entities;
using WMI;


namespace Management
{
    /// <summary>
    /// Start reading the WMI data and save it into the database
    /// </summary>
    public class Manager
    {
        public static Manager CreateInstance(DataManager dataManager, IGetInfo info)
        {
            if (_instance == null)
                lock (Obj)
                    _instance = new Manager(dataManager, info);

            return _instance;
        }

        public static Manager GetInstance()
        {
            return _instance;
        }

        public void Manage()
        {
            var model = _info.GetInfo();

            ManageComputerName(model);
            ManageManufacturer(model);
            ManageUserName(model);
        }

        private Manager(DataManager dataManager, IGetInfo info)
        {
            _dataManager = dataManager;
            _info = info;

            var thread = new Thread(new Timer(this, _updateTime).SwitchOn);
            thread.Start();
        }

        private void ManageUserName(EntitiesModel model)
        {
            try
            {
                List<User> userNames = null;
                try
                {
                    userNames = _dataManager.Users.Get().ToList();
                }
                catch { }

                if (userNames == null || userNames.Count == 0)
                    foreach (var user in model.Users)
                    {
                        _dataManager.Users.Create(user);
                    }
                else
                {
                    var userNamesOld = new List<User>(userNames);
                    var userNamesNew = new List<User>(model.Users);

                    if (userNamesNew.Count >= userNamesOld.Count)
                    {
                        foreach (var oldName in userNamesOld)
                        {
                            var item = userNamesNew.FirstOrDefault(x => x.Name.Equals(oldName.Name));

                            if (item != null)
                                userNamesNew.Remove(item);
                            else
                                userNames.Remove(item);

                            userNamesOld.Remove(item);
                        }
                        foreach (var userName in userNamesNew)
                        {
                            _dataManager.Users.Create(userName);
                        }
                    }
                    else
                    {
                        foreach (var userName in userNamesNew)
                        {
                            var item = userNamesOld.FirstOrDefault(x => x.Name.Equals(userName.Name));

                            if (item != null)
                            {
                                userNamesNew.Remove(item);
                                userNamesOld.Remove(item);
                            }
                            else
                                _dataManager.Users.Create(userName);
                        }
                        foreach (var userName in userNamesOld)
                        {
                            userNames.Remove(userName);
                        }
                    }
                }
            }
            catch { }
        }

        private void ManageManufacturer(EntitiesModel model)
        {
            try
            {
                var manufacturer = _dataManager.Manufacturers.Get().ToList();

                if (!manufacturer.Any())
                    _dataManager.Manufacturers.Create(model.Manufacturer);
                else
                {
                    if (!manufacturer[0].Name.Equals(model.Manufacturer.Name))
                    {
                        model.Manufacturer.Id = manufacturer[0].Id;
                        _dataManager.Manufacturers.Update(model.Manufacturer);
                    }
                }
            }
            catch { }
        }

        private void ManageComputerName(EntitiesModel model)
        {
            try
            {
                var computerNames = _dataManager.Computers.Get().ToList();

                if (!computerNames.Any())
                    _dataManager.Computers.Create(model.Computer);
                else
                {
                    if (!computerNames[0].Name.Equals(model.Computer.Name))
                    {
                        model.Computer.Id = computerNames[0].Id;
                        _dataManager.Computers.Update(model.Computer);
                    }
                }
            }
            catch { }
        }

        private static Manager _instance;
        private readonly DataManager _dataManager;
        private readonly IGetInfo _info;
        private readonly int _updateTime = 1800; // 30 minutes
        private static readonly object Obj = new object();
    }
}
