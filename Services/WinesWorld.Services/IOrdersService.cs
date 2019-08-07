using System.Linq;
using System.Threading.Tasks;
using WinesWorld.Services.Models;

namespace WinesWorld.Services
{
    public interface IOrdersService
    {
       Task<bool> CreateOrder(OrderServiceModel orderServiceModel);

       IQueryable<OrderServiceModel> GetAll(string userId);
    }
}