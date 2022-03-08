using Common.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataServices();


var app = builder.Build();




app.MapGet("/", (ITodoService ctx) => "Hello World!");

app.Run();
