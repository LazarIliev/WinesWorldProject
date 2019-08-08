using System.Linq;
using System.Threading.Tasks;
using WinesWorld.Data.Models;
using WinesWorld.Services.Models;

namespace WinesWorld.Services
{
    public interface IOrdersService
    {
       Task<bool> CreateOrder(OrderServiceModel orderServiceModel);

       IQueryable<OrderServiceModel> GetAll(string userId);

       Task SetOrdersToReceipt(Receipt receipt);

       Task<bool> CompleteOrder(string orderId);
    }
}