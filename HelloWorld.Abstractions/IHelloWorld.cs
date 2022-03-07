using Orleans;

namespace HelloWorld.Abstractions;

public interface IHelloWorld : IGrainWithGuidKey
{
    Task<string> SayHelloWorld();
}
