namespace NetCoreSimple1.Interfaces
{
    public interface IHelloService
    {
        string Message { get; }
    }

    public class RuHelloService : IHelloService
    {
        public string Message => "Привет!";
    }

    public class EnHelloService : IHelloService
    {
        public string Message => "Hello!";
    }

    public class HelloMiddleware
    {
        readonly IEnumerable<IHelloService> helloServices;

        public HelloMiddleware(RequestDelegate _, IEnumerable<IHelloService> helloServices)
        {
            this.helloServices = helloServices;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8;";
            string responseText = "";

            foreach (var service in helloServices)
            {
                responseText += $"<h3>{service.Message}</h3>";
            }
            await context.Response.WriteAsync(responseText);
        }
    }
}
