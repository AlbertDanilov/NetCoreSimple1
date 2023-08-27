using NetCoreSimple1.Interfaces;

namespace NetCoreSimple1.Models
{
    public class LongTimeService : ITimeService
    {
        public string GetTime() => DateTime.Now.ToLongTimeString();
    }
}
