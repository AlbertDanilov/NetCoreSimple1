using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using NetCoreSimple1.Models;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseMiddleware<RoutingMIddleware>();

app.Run();


