using NetCoreSimple1.Interfaces;

namespace NetCoreSimple1.Models
{
    public class CounterService
    {
        public ICounter Counter { get; }

        public CounterService(ICounter counter)
        {
            Counter = counter;
        }
    }
}
