using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.Text;

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
    //context.Response.ContentType = "text/html; charset=utf-8";
    //await context.Response.SendFileAsync("Html/index.html");

    //var path = context.Request.Path;
    //var fullPath = $"html\\{path}";
    //var response = context.Response;

    //response.ContentType = "text/html; charset:utf-8";
    //if (File.Exists(fullPath)) 
    //{ 
    //    await context.Response.SendFileAsync(fullPath);
    //}
    //else
    //{
    //    response.StatusCode = 404;
    //    await context.Response.WriteAsync("<h2>Not found.</h2>");
    //}

    //context.Response.Headers.ContentDisposition = "attachment; filename=my_IMG.JPG";
    //await context.Response.SendFileAsync("Resourses\\IMG.JPG");

    //var fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
    //var fileInfo = fileProvider.GetFileInfo("Resourses\\IMG.JPG");

    //context.Response.Headers.ContentDisposition = "attachment; filename=my_IMG.JPG";
    //await context.Response.SendFileAsync(fileInfo);
    //await context.Response.SendFileAsync(fileInfo);


    //context.Response.ContentType = "text/html; charset=utf-8";

    //if (string.Compare(context.Request.Path, "/postuser",true) == 0)
    //{
    //    var form = context.Request.Form;
    //    string name = form["name"];
    //    string age = form["age"];
    //    string[] languages = form["languages"]; 

    //    StringBuilder stringBuilder = new StringBuilder();

    //    foreach (var lang in languages) 
    //    { 
    //        stringBuilder.Append(lang); 
    //        stringBuilder.Append(" "); 
    //    }

    //    await context.Response.WriteAsync($"<div><p>Name: {name}</p><p>Age: {age}</p><div>Languages: {stringBuilder.ToString()}</div></div>");
    //}
    //else 
    //{
    //    await context.Response.SendFileAsync("Html/index.html");
    //}


    if (String.Compare(context.Request.Path, "/old", true) == 0)
    {
        //await context.Response.WriteAsync("Old page");
        context.Response.Redirect("/new");
    }
    else if (String.Compare(context.Request.Path, "/new", true) == 0)
    {
        await context.Response.WriteAsync("New page");
    }
    else
    {
        await context.Response.WriteAsync("Main page");
    }

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


