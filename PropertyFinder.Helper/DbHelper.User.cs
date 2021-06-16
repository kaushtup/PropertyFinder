using PropertyFinder.Data;
using PropertyFinder.Data.Models;
using PropertyFinder.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyFinder.Helper
{
    public partial class DbHelper
    {
        public User GetUserById(int id)
        {
            return new Repository<User>(_context).FindById(id);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return (await new Repository<User>(_context).FindByIdAsync(id));
        }

        public List<User> GetUsers()
        {
            var list = new List<User>();

            new Repository<User>(_context).FindAll().ToList().ForEach(x => list.Add(x));

            return list;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var list = new List<User>();

            (await new Repository<User>(_context).FindAllAsync()).ToList().ForEach(x => list.Add(x));

            return list;
        }

        public async Task<User> GetUserAsync(string email)
        {
            return (await new Repository<User>(_context).FindAsync(x => x.Email == email)).FirstOrDefault();
        }

        public async Task<int> GetUserId(int id)
        {
            return (await new Repository<User>(_context).FindAsync(x => x.Id == id)).FirstOrDefault().Id;
        }

        public async Task<bool> CreateUserAsync(string firstname,string lastname,string contact,string email,string password, int roleid)
        {
            var objUser = new User
            {
                Firstname = firstname,
                Lastname = lastname,
                Contact = contact,
                Email = email,
                Password = password,
                RoleId = roleid
            };

            try
            {
                await new Repository<User>(_context).AddAsync(objUser);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteUserById(int id)
        {
            if (id < 1)
            {
                return false;
            }
            try
            {
                new Repository<User>(_context).RemoveById(id);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
