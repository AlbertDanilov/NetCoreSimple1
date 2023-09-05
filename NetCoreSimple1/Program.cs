using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using NetCoreSimple1.Interfaces;
using NetCoreSimple1.Models;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;


var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Map("/", () => "Index Page");
app.Map("/users/{id}", (string id) => $"User id: {id}");
app.Map("/users/{id:int}/{name:minlength(5):maxlength(150)}", HandleRequest);
app.Map("/users/{id}-{name}", (string id, string name) => $"User id: {id}, name: {name}");
app.Map("/about", () => "About Page");
app.Map("/contact", () => "Contact Page");
app.Map("/user", () => Console.WriteLine("Request Path: /user"));
app.Map("/test", async (context) =>
{
    await context.Response.WriteAsync("Test page");
});

app.MapGet("/", (IEnumerable<EndpointDataSource> endpointSources) => string.Join("\n", endpointSources.SelectMany(source => source.Endpoints)));

app.Run();

string HandleRequest(string id, string name)
{
    return $"User id: {id}, name: {name}";
}


