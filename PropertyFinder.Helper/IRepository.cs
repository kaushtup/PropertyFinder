using PropertyFinder.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyFinder.Helper
{
    public interface IRepository<T> where T : ModelBase
    {
        T Add(T item, bool saveChanges = true);
        T Update(T item, int id, bool saveChanges = true);
        void Remove(T item, bool saveChanges = true);
        void RemoveById(int id, bool saveChanges = true);
    }
}
