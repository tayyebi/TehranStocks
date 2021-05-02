using System.Threading.Tasks;

namespace TehranStocks.ServicesInterfaces.Network
{
    public interface ITsetmcClient
    {
        Task<string> GetMessageAsync();
    }
}