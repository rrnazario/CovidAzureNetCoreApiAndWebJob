using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAndWebJob.Model;

namespace WebApiAndWebJob.Interfaces
{
    public interface IHealthService
    {
        Covid GetCovidResults();
    }
}
