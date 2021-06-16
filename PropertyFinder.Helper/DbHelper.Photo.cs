using PropertyFinder.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyFinder.Helper
{
    public partial class DbHelper
    {
        public async Task<List<Photo>> GetPhotoInfo()
        {
            var list = new List<Photo>();
            (await new Repository<Photo>(_context).FindAllAsync()).ToList().ForEach(x => list.Add(x));
            return list;
        }

        public Photo GetPhotoByIdAsync(int id)
        {
            return (new Repository<Photo>(_context).FindById(id));
        }

        public Photo GetPhotoByNameAsync(string name)
        {
            var data = (new Repository<Photo>(_context).Find(x => x.Image == name));

            var photo = new Photo();
            foreach (var item in data)
            {
                photo.Id = item.Id;
                photo.Image = item.Image;

                return photo;
            }

            return photo;
        }

       
        public bool DeletePhotoById(int photoid)
        {
            if (photoid < 1)
            {
                return false;
            }
            try
            {
                new Repository<Photo>(_context).RemoveById(photoid);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
