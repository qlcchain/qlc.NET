using System.Threading.Tasks;

namespace Qlc.Net
{
    public interface IQlcNetClient
    {
        Task<QlcResponse<T>> GetResponseAsync<T>(QlcRequest request);
    }
}
