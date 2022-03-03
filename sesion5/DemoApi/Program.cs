
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<GuidService>();
builder.Services.AddTransient<FooService>();
var constr = builder.Configuration["data:constr"];
builder.Services.AddDbContext<TodoContext>(opt => opt.UseNpgsql(constr));
builder.Services.AddTransient<ITodoService,TodoService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
builder.Logging.ClearProviders(); 
builder.Logging.AddConsole();
*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/hello", () => "Hello World");
app.MapGet("/pendingtodos", async (ITodoService svc) => await svc.GetPendingTodos());


app.MapControllers();

app.Run();
