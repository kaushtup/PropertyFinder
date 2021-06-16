using PropertyFinder.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyFinder.Helper
{
    public partial class DbHelper
    {
        public async Task<List<HouseType>> GetHouseTypesAsync()
        {
            var list = new List<HouseType>();
            (await new Repository<HouseType>(_context).FindAllAsync()).ToList().ForEach(x => list.Add(x));
            return list;
        }

        public async Task<HouseType> GetHouseTypeByIdAsync(int id)
        {
            return (await new Repository<HouseType>(_context).FindByIdAsync(id));
        }
    }
}
