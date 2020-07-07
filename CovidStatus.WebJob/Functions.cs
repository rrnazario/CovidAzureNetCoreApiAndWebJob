using System.IO;
using Microsoft.Azure.WebJobs;
using CovidStatus.WebJob.Core.Helpers;
using CovidStatus.WebJob.Core.Model;

namespace CovidStatus.WebJob
{
    public class Functions
    {
        /// <summary>
        /// Checks COVID-19 indexes and, if it matches with some condition, it triggers alarms
        /// </summary>
        /// <param name="log"></param>
        [Timeout("05:00:00")]
        [NoAutomaticTrigger]
        public static void CheckCovidIndexes(TextWriter log)
        {
            //log.WriteLine(message);
            var baseEndpoint = EnvironmentHelper.GetInfoFromConfig("APIBaseAddress");

            var covidInformation = HttpClientHelper.GetContentFromRequest<Covid>($"{baseEndpoint}/Health/GetCovidResults");

            var deathBounds = int.TryParse(EnvironmentHelper.GetInfoFromConfig("DeathBounds"), out var bound) ? bound : 0;
            if (covidInformation.Deaths > deathBounds)
            {
                EmailHelper.SendMail("", "", "COVID alert", $"COVID has now {covidInformation.Deaths} confirmed deaths");
            }
        }
    }
}
