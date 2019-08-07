using System.Collections.Generic;
using System.Threading.Tasks;
using WinesWorld.Services.Models;

namespace WinesWorld.Services
{
    public interface IWinesService
    {
        Task<bool> Add(WineServiceModel wineAddInputModel);

        List<WineServiceModel> GetAllWines();

        Task<WineServiceModel> GetWineDetails(string id);
    }
}
