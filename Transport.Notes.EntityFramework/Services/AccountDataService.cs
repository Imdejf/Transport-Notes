using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services;
using Transport.Notes.EntityFramework.Services.Common;

namespace Transport.Notes.EntityFramework.Services
{
    public class AccountDataService : IAccountService
    {
        private readonly TransportNotesDbContextFacotry _contextFacotry;
        private readonly NonQueryService<Account> _nonQueryService;

        public AccountDataService(TransportNotesDbContextFacotry contextFactory)
        {
            _contextFacotry = contextFactory;
            _nonQueryService = new NonQueryService<Account>(contextFactory);
        }
        public async Task<Account> Create(Account entity)
        {
            return await _nonQueryService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryService.Delete(id);
        }

        public async Task<Account> Get(int id)
        {
            using(TransportNotesDbContext context = _contextFacotry.CreateDbContext())
            {
                Account entity = await context.Accounts
                    .Include(a => a.AccountHolder)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using(TransportNotesDbContext context = _contextFacotry.CreateDbContext())
            {
                IEnumerable<Account> entities = await context.Accounts
                    .Include(a => a.AccountHolder)
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<Account> GetByEmail(string email)
        {
            using(TransportNotesDbContext context = _contextFacotry.CreateDbContext())
            {
                return await context.Accounts
                    .Include(a => a.AccountHolder)
                    .FirstOrDefaultAsync(a => a.AccountHolder.Email == email);
            }
        }

        public async Task<Account> GetByUsername(string username)
        {
            using(TransportNotesDbContext context = _contextFacotry.CreateDbContext())
            {
                return await context.Accounts
                    .Include(a => a.AccountHolder)
                    .FirstOrDefaultAsync(a => a.AccountHolder.Username == username);
            }
        }

        public async Task<Account> Update(Account entity, int id)
        {
            return await _nonQueryService.Update(id,entity);
        }
    }
}
