using NetCoreSimple1.Interfaces;

namespace NetCoreSimple1.Models
{
    public class Logger : Interfaces.ILogger
    {
        public void Log(string message) => Console.WriteLine(message);
    }
}
