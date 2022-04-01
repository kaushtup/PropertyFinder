using PropertyFinder.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyFinder.Helper
{
    public partial class DbHelper
    {
        public async Task<bool> AddMessageAsync(int tenantId, int ownerId, string message,DateTime currentdate, bool IsChecked, bool IsOwner)
        {
            var objMessage = new Message
            {
                TenantId = tenantId,
                OwnerId = ownerId,
                Messages = message,
                date = currentdate,
                IsChecked = IsChecked,
                IsOwner = IsOwner
            };

            try
            {
               await new Repository<Message>(_context).AddAsync(objMessage);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
       
        public async Task<List<Message>> GetMessageByOwnerIdAsync(int ownerid)
        {
            var list = new List<Message>();
            (await new Repository<Message>(_context).FindAsync(x => x.OwnerId == ownerid)).ToList().ForEach(x => list.Add(x));
            return list;
        }

        //update
        public bool UpdateMessageByOwnerIdAsync(int id)
        {
            var objMessage = GetMessageByOwnerIdAsync(id);

            try
            {
                foreach (var item in objMessage.Result.Where(x => x.IsOwner == false))
                {
                    var model = new Message();
                    model.Id = item.Id;
                    model.OwnerId = item.OwnerId;
                    model.TenantId = item.TenantId;
                    model.IsOwner = false;
                    model.date = item.date;
                    model.IsChecked = true;
                    model.Messages = item.Messages;
                    
                    new Repository<Message>(_context).Update(model, item.Id);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<Message>> GetMessageByTenantIdAsync(int tenantid)
        {
            var list = new List<Message>();
            (await new Repository<Message>(_context).FindAsync(x => x.TenantId == tenantid)).ToList().ForEach(x => list.Add(x));
            return list;
        }

        //update
        public bool UpdateMessageByTenantIdAsync(int id)
        {
            var objMessage = GetMessageByTenantIdAsync(id);

            try
            {
                foreach (var item in objMessage.Result.Where(x => x.IsOwner == true))
                {
                    var model = new Message();
                    model.Id = item.Id;
                    model.OwnerId = item.OwnerId;
                    model.TenantId = item.TenantId;
                    model.IsOwner = true;
                    model.date = item.date;
                    model.IsChecked = true;
                    model.Messages = item.Messages;

                    new Repository<Message>(_context).Update(model, item.Id);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public bool DeleteMessageById(int id)
        {
            if (id < 1)
            {
                return false;
            }
            try
            {
                new Repository<Message>(_context).RemoveById(id);
                
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
