using System;

namespace CovidStatus.WebJob.Core.Model
{
    public class Covid
    {
        public int Cases { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
    }
}
