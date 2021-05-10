using SugarchainApiClient.Operations;

namespace SugarchainApiClient.Interfaces
{
    public interface ISugarchainClient
    {
        public T UseOperation<T>() where T : Operation;
    }
}