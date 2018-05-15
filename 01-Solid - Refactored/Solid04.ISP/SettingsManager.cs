using System.Collections.Generic;

namespace Solid04.ISP
{
    public class SettingsManager
    {
        private readonly List<IPersist> _persistList = new List<IPersist>();
        private readonly List<ILoad> _loadList = new List<ILoad>();

        public SettingsManager()
        {
            var loggingSettings = new LoggingSettings();
            var userAccessSettings = new UserAccessSettings();

            _persistList.Add(loggingSettings);
            _loadList.Add(loggingSettings);
            _loadList.Add(userAccessSettings);
        }

        public void LoadAll()
        {
            foreach (var settings in _loadList)
            {
                settings.Load();
            }
        }

        public void PersistAll()
        {
            foreach (var settings in _persistList)
            {
                settings.Persist();
            }
        }
    }
}
