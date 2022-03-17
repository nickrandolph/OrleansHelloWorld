using HelloWorld.Abstractions;
using Orleans;
using Orleans.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseOrleans(siloBuilder =>
{
    var storageConnectionString = builder.Configuration.GetValue<string>(EnvironmentVariables.AzureStorageConnectionString);
    siloBuilder
        .HostSiloInAzure(builder.Configuration);
});

var app = builder.Build();
app.UseRouting();

// Uncomment this to expose an endpoint that can be opened
// in the browser to test that the silo is up and running
app.MapGet("/", async (IGrainFactory grainFactory) =>
{
    var grain = grainFactory.GetGrain<IHelloWorld>(Guid.Empty);
    return await grain.SayHelloWorld();
});

app.Run();