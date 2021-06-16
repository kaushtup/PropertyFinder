using PropertyFinder.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyFinder.Helper
{
    public partial class DbHelper
    {
        public async Task<List<AddressInfo>> GetAddressInfosAsync()
        {
            var list = new List<AddressInfo>();
            (await new Repository<AddressInfo>(_context).FindAllAsync()).ToList().ForEach(x => list.Add(x));
            return list;
        }

        public async Task<AddressInfo> GetAddressByIdAsync(int id)
        {
            return (await new Repository<AddressInfo>(_context).FindByIdAsync(id));
        }
    }
}
