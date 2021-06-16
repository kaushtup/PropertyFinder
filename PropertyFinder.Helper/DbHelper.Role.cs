using PropertyFinder.Data;
using PropertyFinder.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyFinder.Helper
{
    public partial class DbHelper
    {
        public async Task<List<Role>> GetRolesAsync()
        {
            var list = new List<Role>();

            (await new Repository<Role>(_context).FindAllAsync()).Where(x => x.Name != "Admin").ToList().ForEach(x => list.Add(x));

            return list;
        }
    }
}
