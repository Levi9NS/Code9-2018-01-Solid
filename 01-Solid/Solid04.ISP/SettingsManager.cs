using System.Collections.Generic;

namespace Solid04.ISP
{
    public class SettingsManager
    {
        private readonly List<IPersistedSettings> _settings = new List<IPersistedSettings>();

        public SettingsManager()
        {
            _settings.Add(new LoggingSettings());
            _settings.Add(new UserAccessSettings());
        }

        public void LoadAll()
        {
            foreach (var settings in _settings)
            {
                settings.Load();
            }
        }

        public void PersistAll()
        {
            foreach (var settings in _settings)
            {
                settings.Persist();
            }
        }
    }
}
