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

//builder.Services.AddTimeService();

//builder.Services.AddSingleton<ICounter, RandomCounter>();
//builder.Services.AddSingleton<CounterService>();

//builder.Services.AddScoped<ITimer, NetCoreSimple1.Models.Timer>();
//builder.Services.AddSingleton<TimeService>();

builder.Services.AddTransient<IHelloService, RuHelloService>();
builder.Services.AddTransient<IHelloService, EnHelloService>();

var app = builder.Build();

app.UseMiddleware<HelloMiddleware>();

//app.UseMiddleware<TimerMiddleware>();

//Console.WriteLine(app.Environment.EnvironmentName);

//app.UseMiddleware<CounterMiddleware>();

//app.UseMiddleware<ErrorHandlingMiddleware>();
//app.UseMiddleware<AuthenticationMiddleware>();
//app.UseMiddleware<RoutingMIddleware>();

//app.Run(async context =>
//{
//    var timeService = app.Services.GetService<ITimeService>();
//    await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
//});

app.Run();


