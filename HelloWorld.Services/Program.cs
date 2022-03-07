using HelloWorld.Abstractions;
using Orleans;
using Orleans.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOrleansClusterClient(builder.Configuration);

var app = builder.Build();

app.UseRouting();

app.MapGet("/", async (IClusterClient orleansClient) =>
{
    var grain = orleansClient.GetGrain<IHelloWorld>(Guid.Empty);
    return await grain.SayHelloWorld();
});

app.Run();
