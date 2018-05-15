namespace Solid04.ISP
{
    public class LoggingSettings: ILoad, IPersist
    {
        public string LogFilePath { get; set; }
        public bool LogSensitiveData { get; set; }
                
        public void Load()
        {
            // LOAD FROM JSON FILE
            // string json = File.ReadAllText(settingsFilePath);
            // JsonConver.Deserialize ...
            LogFilePath = "my_app.log";
            LogSensitiveData = true;            
        }

        public void Persist()
        {
            // PERSIST TO JSON FILE
            // string json = JsonConvert.SerializeObject(this);
            // File.WriteAllText(settingsFilePath, json);
        }
    }
}
