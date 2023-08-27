namespace NetCoreSimple1.Models
{
    public class RoutingMIddleware
    {
        public RoutingMIddleware(RequestDelegate _) 
        { 
            
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path;
            if (path == "/index")
            {
                await context.Response.WriteAsync("Home Page");
            }
            else if (path == "/about") 
            {
                await context.Response.WriteAsync("About Page");
            }
            else
            {
                context.Response.StatusCode = 404;
            }
        }
    }
}
