using System.Threading;

namespace Management
{
    /// <summary>
    /// Start reading the WMI data save it into the database with a specified interval 
    /// </summary>
    public class Timer
    {
        public Timer(Manager manager)
        {
            _manager = manager;
        }
        public Timer(Manager manager, int updateTime) : this(manager)
        {
            _updateTime = updateTime;
        }
        public void SwitchOn()
        {
            var adapter = new Adapter(_manager);
            var tm = new TimerCallback(adapter.Manage);
            var timer = new System.Threading.Timer(tm, null, 0, _updateTime * 1000);
        }

        private readonly Manager _manager;
        private readonly int _updateTime = 3600; // 60 minutes
    }

    internal class Adapter
    {
        public Adapter(Manager manager)
        {
            _manager = manager;
        }

        public void Manage(object o)
        {
            _manager.Manage();
        }

        private readonly Manager _manager;
    }
}
