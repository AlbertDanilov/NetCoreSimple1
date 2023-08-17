using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World! 1234");
//app.Run(async (context) => await context.Response.WriteAsync("Hello!"));
//app.Run(async (context) => await context.Response.WriteAsync(string.Join("\n", context.Features.ToList())));
//app.UseWelcomePage();
//app.Run(HandleRequest);

int x = 2;
app.Run(async (context) =>
{
    x = x * 2;
    await context.Response.WriteAsync($"Result: {x}");
});

app.Run();

//async Task HandleRequest(HttpContext context)
//{
//    await context.Response.WriteAsync("Hello!");
//}

//await app.StartAsync();
//await Task.Delay(5000);
//await app.StopAsync();


