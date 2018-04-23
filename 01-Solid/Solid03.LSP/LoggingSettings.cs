using System.IO;
using Newtonsoft.Json;

namespace Solid03.LSP
{
    public class LoggingSettings: PersistedSettingsBase
    {
        public string LogFilePath { get; set; }
        public bool LogSensitiveData { get; set; }

        
        public override void Load()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                var settings = JsonConvert.DeserializeObject<LoggingSettings>(json);
                LogFilePath = settings.FilePath;
                LogSensitiveData = settings.LogSensitiveData;
            }
        }

        public override void Persist()
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(FilePath, json);
        }

        protected override string FileName { get; } = "log_settings.json";
    }
}
