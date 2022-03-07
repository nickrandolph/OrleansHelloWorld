using HelloWorld.Abstractions;
using Orleans;

namespace HelloWorld.Entities;

public class HelloWorld : Grain, IHelloWorld
{
    public Task<string> SayHelloWorld()
    {
        return Task.FromResult("Hello World");
    }
}
