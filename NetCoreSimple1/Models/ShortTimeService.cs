using NetCoreSimple1.Interfaces;

namespace NetCoreSimple1.Models
{
    public class ShortTimeService : ITimeService
    {
        public string GetTime() => DateTime.Now.ToShortTimeString();
    }
}
