using System.Threading.Tasks;

namespace Microservice.Core.DataAccess.Mongo
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync();
    }
}