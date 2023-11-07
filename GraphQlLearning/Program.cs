using GraphQlLearning.Queries;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

Log.Logger = new LoggerConfiguration().Enrich.FromLogContext().WriteTo.Console().CreateLogger();

builder.Logging.AddSerilog();
builder.Host.UseSerilog();
services.AddGraphQLServer().AddQueryType<MyQueries>();
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.UseSerilogRequestLogging();
app.MapGraphQL();
app.Run();
