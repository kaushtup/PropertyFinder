using PropertyFinder.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyFinder.Helper
{
    public partial class DbHelper : IDbHelper
    {
        private readonly ApplicationDbContext _context;

        public DbHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
