using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAndWebJob.Interfaces;
using WebApiAndWebJob.Model;

namespace WebApiAndWebJob.Services
{
    public class HealthService : IHealthService
    {
        public Covid GetCovidResults()
        {
            var webDoc = new HtmlWeb();
            var doc = webDoc.Load(@"https://www.worldometers.info/coronavirus/");

            var texts = doc.DocumentNode.SelectNodes("//div/div[@id=\"maincounter-wrap\"]")
                .Select(s => s.InnerText.Split('\n', StringSplitOptions.RemoveEmptyEntries).Last().Replace(",", "")).ToArray();

            return new Covid()
            {
                Cases = int.Parse(texts[0]),
                Deaths = int.Parse(texts[1]),
                Recovered = int.Parse(texts[2])
            };
        }
    }
}
