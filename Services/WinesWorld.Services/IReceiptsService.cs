using System.Linq;
using System.Threading.Tasks;
using WinesWorld.Services.Models;

namespace WinesWorld.Services
{
    public interface IReceiptsService
    {
        Task<string> CreateReceipt(string recipientId);

        IQueryable<ReceiptServiceModel> GetAll();
    }
}