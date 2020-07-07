using CovidStatus.Presentation.Model;

namespace CovidStatus.Presentation.Interfaces
{
    public interface IHealthService
    {
        Covid GetCovidResults();
    }
}
