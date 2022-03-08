var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

var app = builder.Build();


app.MapGrpcService<WeatherService>();
app.MapGet("/", () => "This is a grpc server.");

app.Run();
