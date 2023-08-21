using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using NetCoreSimple1.Models;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

//List<Person> users = new List<Person>()
//{ 
//    new() { Id = Guid.NewGuid().ToString(), Name = "Tom", Age = 37 },
//    new() { Id = Guid.NewGuid().ToString(), Name = "Bob", Age = 41 },
//    new() { Id = Guid.NewGuid().ToString(), Name = "Sam", Age = 24 },
//};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string date = "";


app.MapWhen(
    context => context.Request.Path == "/time",
    HandeTimeRequest
);

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello METANIT.COM");
});

app.Run();

void HandeTimeRequest(IApplicationBuilder appBuilder)
{
    appBuilder.Use(async (context, next) =>
    {
        var time = DateTime.Now.ToShortTimeString();
        Console.WriteLine(time);
        await next();
    });
}


//async Task GetDate(HttpContext context, RequestDelegate next)
//{
//    date = DateTime.Now.ToShortDateString();
//    await next.Invoke(context);
//    Console.WriteLine($"Date: {date}");
//}


//app.Use(GetDate);

//app.Run(async (context) => await context.Response.WriteAsync($"Date: {date}"));



//app.Run(async (context) =>
//{
//    var response = context.Response;
//    var request = context.Request;

//    response.ContentType = "text/html; charset=utf-8";

//    if (request.Path =="/upload" && request.Method == "POST") 
//    {
//        IFormFileCollection files = request.Form.Files;
//        var uploadPath = $"{Directory.GetCurrentDirectory()}/uploads";
//        Directory.CreateDirectory(uploadPath);

//        foreach (var file in files) 
//        {
//            string fullPath = $"{uploadPath}/{file.FileName}";

//            using (var fileStream = new FileStream(fullPath, FileMode.Create))
//            {
//                await file.CopyToAsync(fileStream); 
//            }
//        }
//        await response.WriteAsync("Файлы загружены");
//    }
//    else 
//    {
//        await response.SendFileAsync("Html/filePage.html");
//    }
//});





//app.Run(async (context) => 
//{
//    var response = context.Response;
//    var request = context.Request;
//    var path = request.Path;

//    string expressionForGuid = @"^/api/users/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";

//    if (path == "/api/users" && request.Method == HttpMethod.Get.ToString())
//    {
//        await GetAllPeople(response);
//    }
//    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == HttpMethod.Get.ToString())
//    {
//        string? id = path.Value?.Split("/")[3];
//        await GetPerson(id, response);
//    }
//    else if (path == "/api/users" && request.Method == "POST")
//    {
//        await CreatePerson(response, request);
//    }
//    else if (path == "/api/users" && request.Method == HttpMethod.Put.ToString())
//    {
//        await UpdatePerson(response, request);
//    }
//    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == HttpMethod.Delete.ToString())
//    {
//        string? id = path.Value?.Split("/")[3];
//        await DeletePerson(id, response);
//    }
//    else
//    {
//        response.ContentType = "text/html; charset=utf-8";
//        await response.SendFileAsync("Html/index.html");
//    }

//});

//app.Run();


//async Task GetAllPeople(HttpResponse response)
//{
//    await response.WriteAsJsonAsync(users);
//}

//async Task GetPerson(string? id, HttpResponse response)
//{
//    Person? user = users.FirstOrDefault((x) => x.Id == id);

//    if (user != null)
//        await response.WriteAsJsonAsync(user);
//    else
//    {
//        response.StatusCode = (int)HttpStatusCode.NotFound;
//        await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
//    }
//}

//async Task CreatePerson(HttpResponse response, HttpRequest request)
//{
//    try
//    {
//        // получаем данные пользователя
//        var user = await request.ReadFromJsonAsync<Person>();
//        if (user != null)
//        {
//            // устанавливаем id для нового пользователя
//            user.Id = Guid.NewGuid().ToString();
//            // добавляем пользователя в список
//            users.Add(user);
//            await response.WriteAsJsonAsync(user);
//        }
//        else
//        {
//            throw new Exception("Некорректные данные");
//        }
//    }
//    catch (Exception)
//    {
//        response.StatusCode = 400;
//        await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
//    }
//}

//async Task UpdatePerson(HttpResponse response, HttpRequest request)
//{
//    try
//    {
//        Person? userData = await request.ReadFromJsonAsync<Person>();
//        if (userData != null)
//        {
//            var user = users.FirstOrDefault((x) => x.Id == userData.Id);

//            if (user != null)
//            {
//                user.Age = userData.Age;
//                user.Name = userData.Name;
//                await response.WriteAsJsonAsync(user);
//            }
//            else
//            {
//                response.StatusCode = (int)HttpStatusCode.NotFound;
//                await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
//            }
//        }
//        else
//        {
//            throw new Exception("Некорректные данные");
//        }
//    }
//    catch
//    {
//        response.StatusCode = (int)HttpStatusCode.BadRequest;
//        await response.WriteAsJsonAsync(new {message = "Некорректные данные"});
//    }
//}

//async Task DeletePerson(string? id, HttpResponse response)
//{
//    Person? user = users.FirstOrDefault((x) => x.Id == id);

//    if (user != null)
//    {
//        users.Remove(user);
//        await response.WriteAsJsonAsync(user);
//    }
//    else
//    {
//        response.StatusCode = (int)HttpStatusCode.NotFound;
//        await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
//    }
//}







////app.MapGet("/", () => "Hello World! 1234");
////app.Run(async (context) => await context.Response.WriteAsync("Hello!"));
////app.Run(async (context) => await context.Response.WriteAsync(string.Join("\n", context.Features.ToList())));
////app.UseWelcomePage();
////app.Run(HandleRequest);

////int x = 2;
////app.Run(async (context) =>
////{
////    x = x * 2;
////    await context.Response.WriteAsync($"Result: {x}");
////});

////app.Run(async (context) => 
////{ 
////    await context.Response.WriteAsync("Hello!", System.Text.Encoding.Default);
////});

////app.Run(async (context) =>
////{
//    //var response = context.Response;
//    //response.Headers.ContentLanguage = "ru-RU";
//    //response.Headers.ContentType = "text/plain; charset=utf-8";
//    //response.Headers.Append("secret_id", "256"); // custom header
//    //await response.WriteAsync("Helo");

//    //context.Response.StatusCode = 404;
//    //await context.Response.WriteAsync("Resource not found");

//    //var response = context.Response;
//    //response.ContentType = "text/html; charset=utf-8";
//    //await response.WriteAsync("<h2>Hello METANIT.COM</h2><h3>Welcome to ASP.NET Core</h3>");

//    //context.Response.ContentType = "text/html; charset=utf-8";

//    //var acceptHeaderValue = context.Request.Headers["accept"];

//    //var stringBuilder = new System.Text.StringBuilder("<table>");
//    //foreach(var header in context.Request.Headers)
//    //{
//    //    stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
//    //}
//    //stringBuilder.Append("</table>");

//    //await context.Response.WriteAsync(stringBuilder.ToString());


//    //var path = context.Request.Path;
//    //var now = DateTime.Now;
//    //var response = context.Response;

//    //switch (path)
//    //{
//    //    case "/date":
//    //        await response.WriteAsync($"Date: {now.ToShortDateString()}");
//    //        break;
//    //    case "/time":
//    //        await response.WriteAsync($"Date: {now.ToShortTimeString()}");
//    //        break;
//    //    default:
//    //        await response.WriteAsync("Wrong path");
//    //        break;
//    //}


//    //context.Response.ContentType = "text/html; charset=utf-8";
//    //var q = context.Request.Query["filter"];
//    //await context.Response.WriteAsync($"<p>Path: {context.Request.Path}</p><p>QueryString: {context.Request.QueryString}</p>");



////});


////app.Run(async (context) => await context.Response.SendFileAsync("D:\\IMG.JPG"));
////app.Run(async (context) => await context.Response.SendFileAsync("Resourses\\IMG.JPG"));
//app.Run(async (context) =>
//{
//    //context.Response.ContentType = "text/html; charset=utf-8";
//    //await context.Response.SendFileAsync("Html/index.html");

//    //var path = context.Request.Path;
//    //var fullPath = $"html\\{path}";
//    //var response = context.Response;

//    //response.ContentType = "text/html; charset:utf-8";
//    //if (File.Exists(fullPath)) 
//    //{ 
//    //    await context.Response.SendFileAsync(fullPath);
//    //}
//    //else
//    //{
//    //    response.StatusCode = 404;
//    //    await context.Response.WriteAsync("<h2>Not found.</h2>");
//    //}

//    //context.Response.Headers.ContentDisposition = "attachment; filename=my_IMG.JPG";
//    //await context.Response.SendFileAsync("Resourses\\IMG.JPG");

//    //var fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
//    //var fileInfo = fileProvider.GetFileInfo("Resourses\\IMG.JPG");

//    //context.Response.Headers.ContentDisposition = "attachment; filename=my_IMG.JPG";
//    //await context.Response.SendFileAsync(fileInfo);
//    //await context.Response.SendFileAsync(fileInfo);


//    //context.Response.ContentType = "text/html; charset=utf-8";

//    //if (string.Compare(context.Request.Path, "/postuser",true) == 0)
//    //{
//    //    var form = context.Request.Form;
//    //    string name = form["name"];
//    //    string age = form["age"];
//    //    string[] languages = form["languages"]; 

//    //    StringBuilder stringBuilder = new StringBuilder();

//    //    foreach (var lang in languages) 
//    //    { 
//    //        stringBuilder.Append(lang); 
//    //        stringBuilder.Append(" "); 
//    //    }

//    //    await context.Response.WriteAsync($"<div><p>Name: {name}</p><p>Age: {age}</p><div>Languages: {stringBuilder.ToString()}</div></div>");
//    //}
//    //else 
//    //{
//    //    await context.Response.SendFileAsync("Html/index.html");
//    //}


//    //if (String.Compare(context.Request.Path, "/old", true) == 0)
//    //{
//    //    //await context.Response.WriteAsync("Old page");
//    //    context.Response.Redirect("/new");
//    //}
//    //else if (String.Compare(context.Request.Path, "/new", true) == 0)
//    //{
//    //    await context.Response.WriteAsync("New page");
//    //}
//    //else
//    //{
//    //    await context.Response.WriteAsync("Main page");
//    //}


//    //Person person = new("Albert", 28);
//    //await context.Response.WriteAsJsonAsync(person);


//    var response = context.Response;
//    var request = context.Request;

//    if (string.Compare(context.Request.Path, "/api/user", true) == 0)
//    {
//        var message = "Некорректные данные";
//        try
//        {
//            if (request.HasJsonContentType()) 
//            {
//                var jsonOptions = new JsonSerializerOptions();
//                jsonOptions.Converters.Add(new PersonConverter());

//                var person = await request.ReadFromJsonAsync<Person>(jsonOptions);

//                if (person != null)
//                    message = $"Name: {person.name}, Age: {person.age}";
//            }           
//        }
//        catch { }
//        await response.WriteAsJsonAsync(new { text = message });
//    }
//    else 
//    {
//        context.Response.ContentType = "text/html; charset=utf-8";
//        await response.SendFileAsync("Html/sendJson.html");
//    }

//});

//app.Run(async (context) => await context.Response.WriteAsync($"Path: {context.Request.Path}"));



//app.Run();

//async Task HandleRequest(HttpContext context)
//{
//    await context.Response.WriteAsync("Hello!");
//}

//await app.StartAsync();
//await Task.Delay(5000);
//await app.StopAsync();

//public record Person(string name, int age);

//public class PersonConverter : JsonConverter<Person>
//{
//    public override Person Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//    {
//        var personName = "Undefined";
//        var personAge = 0;

//        while (reader.Read()) 
//        { 
//            var propertyName = reader.GetString();
//            reader.Read();

//            switch (propertyName?.ToLower())
//            {
//                case "age" when reader.TokenType == JsonTokenType.Number:
//                    personAge = reader.GetInt32();
//                    break;
//                case "age" when reader.TokenType == JsonTokenType.String:
//                    string? stringValue = reader.GetString();
//                    if (int.TryParse(stringValue, out int value)) 
//                    {
//                        personAge = value;
//                    }
//                    break;
//                case "name":
//                    string? name = reader.GetString();
//                    if (name != null)
//                        personName = name;
//                    break;
//            }
//        }

//        return new Person(personName, personAge);
//    }

//    public override void Write(Utf8JsonWriter writer, Person person, JsonSerializerOptions options)
//    {
//        writer.WriteStartObject();

//        writer.WriteString("name", person.name);
//        writer.WriteNumber("age", person.age);

//        writer.WriteEndObject();
//    }
//}



