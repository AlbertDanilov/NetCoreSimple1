using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World! 1234");
//app.Run(async (context) => await context.Response.WriteAsync("Hello!"));
//app.Run(async (context) => await context.Response.WriteAsync(string.Join("\n", context.Features.ToList())));
//app.UseWelcomePage();
//app.Run(HandleRequest);

//int x = 2;
//app.Run(async (context) =>
//{
//    x = x * 2;
//    await context.Response.WriteAsync($"Result: {x}");
//});

//app.Run(async (context) => 
//{ 
//    await context.Response.WriteAsync("Hello!", System.Text.Encoding.Default);
//});

//app.Run(async (context) =>
//{
    //var response = context.Response;
    //response.Headers.ContentLanguage = "ru-RU";
    //response.Headers.ContentType = "text/plain; charset=utf-8";
    //response.Headers.Append("secret_id", "256"); // custom header
    //await response.WriteAsync("Helo");

    //context.Response.StatusCode = 404;
    //await context.Response.WriteAsync("Resource not found");

    //var response = context.Response;
    //response.ContentType = "text/html; charset=utf-8";
    //await response.WriteAsync("<h2>Hello METANIT.COM</h2><h3>Welcome to ASP.NET Core</h3>");

    //context.Response.ContentType = "text/html; charset=utf-8";

    //var acceptHeaderValue = context.Request.Headers["accept"];

    //var stringBuilder = new System.Text.StringBuilder("<table>");
    //foreach(var header in context.Request.Headers)
    //{
    //    stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
    //}
    //stringBuilder.Append("</table>");

    //await context.Response.WriteAsync(stringBuilder.ToString());


    //var path = context.Request.Path;
    //var now = DateTime.Now;
    //var response = context.Response;

    //switch (path)
    //{
    //    case "/date":
    //        await response.WriteAsync($"Date: {now.ToShortDateString()}");
    //        break;
    //    case "/time":
    //        await response.WriteAsync($"Date: {now.ToShortTimeString()}");
    //        break;
    //    default:
    //        await response.WriteAsync("Wrong path");
    //        break;
    //}


    //context.Response.ContentType = "text/html; charset=utf-8";
    //var q = context.Request.Query["filter"];
    //await context.Response.WriteAsync($"<p>Path: {context.Request.Path}</p><p>QueryString: {context.Request.QueryString}</p>");

    

//});


//app.Run(async (context) => await context.Response.SendFileAsync("D:\\IMG.JPG"));
//app.Run(async (context) => await context.Response.SendFileAsync("Resourses\\IMG.JPG"));
app.Run(async (context) => 
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("Html/index.html");
});

//app.Run(async (context) => await context.Response.WriteAsync($"Path: {context.Request.Path}"));



app.Run();

//async Task HandleRequest(HttpContext context)
//{
//    await context.Response.WriteAsync("Hello!");
//}

//await app.StartAsync();
//await Task.Delay(5000);
//await app.StopAsync();


