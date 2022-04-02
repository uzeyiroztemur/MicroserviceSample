using System.Threading.Tasks;

namespace Microservice.Core.DataAccess.Mongo
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }
}