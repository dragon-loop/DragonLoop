using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrexelBusApp.Services
{
    public interface IDataService<T>
    {
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync();
    }
}
