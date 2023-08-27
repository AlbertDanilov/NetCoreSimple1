using NetCoreSimple1.Interfaces;

namespace NetCoreSimple1.Models
{
    public class RandomCounter : ICounter
    {
        static Random rnd = new Random();
        private int _value;

        public RandomCounter()
        {
            _value = rnd.Next(0, 1000);
        }

        public int Value 
        {
            get => _value;
        }
    }
}
