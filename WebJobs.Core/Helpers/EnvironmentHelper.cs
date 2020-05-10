using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebJobs.Core.Helpers
{
    public class EnvironmentHelper
    {
        public static string GetInfoFromConfig(string infoName)
        {
            return string.IsNullOrEmpty(Environment.GetEnvironmentVariable(infoName))
                    ? ConfigurationManager.AppSettings[infoName]
                    : Environment.GetEnvironmentVariable(infoName);
        }
    }
}
