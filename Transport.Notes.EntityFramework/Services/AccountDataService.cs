using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services;

namespace Transport.Notes.EntityFramework.Services
{
    public class AccountDataService : IAccountService
    {
        public Task<Account> Create(Account entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Account> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<Account> Update(Account entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
