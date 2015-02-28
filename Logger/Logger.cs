using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Logger
{
    public class Log
    {
        private static Log instance;
        private static readonly ILog log = LogManager.GetLogger(typeof(Object));

        private Log()
        {
            string config = System.IO.File.ReadAllText("Log4netCFG.txt");
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            System.IO.File.WriteAllText("Log4netCFG.xml", config.Replace("%date%", secondsSinceEpoch.ToString()));
            System.IO.Directory.CreateDirectory("Logs");

            XmlConfigurator.Configure(new System.IO.FileInfo("Log4netCFG.xml"));
        }

        public void Debug(string message)
        {
            log.Debug(message);
        }

        public void Warn(string message)
        {
            log.Warn(message);
        }

        public void Info(string message)
        {
            log.Info(message);
        }

        public void Error(string message)
        {
            log.Error(message);
        }

        public void Fatal(string message)
        {
            log.Fatal(message);
        }


        public static Log Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Log();
                }
                return instance;
            }
        }
    }
}
