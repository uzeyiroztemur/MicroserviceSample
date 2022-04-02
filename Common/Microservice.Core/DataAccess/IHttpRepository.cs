using System.Net.Http;
using System.Threading.Tasks;

namespace Microservice.Core.DataAccess
{
    public interface IHttpRepository<TEntity> where TEntity : class, new()
    {
        Task<TEntity> GetJsonAsync(string uri);

        Task<HttpResponseMessage> PostJsonAsync<T>(string uri, T data);
    }
}