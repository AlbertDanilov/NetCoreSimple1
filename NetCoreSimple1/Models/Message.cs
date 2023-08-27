using NetCoreSimple1.Interfaces;

namespace NetCoreSimple1.Models
{
    public class Message
    {
        Interfaces.ILogger logger;
        public string Text { get; set; } = string.Empty;

        public Message(Interfaces.ILogger logger)
        {
            this.logger = logger;
        }

        public void Print() => logger.Log(Text);
    }
}
