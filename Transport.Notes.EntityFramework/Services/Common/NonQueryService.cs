using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.EntityFramework.Services.Common
{
    public class NonQueryService<T> where T : DomainObject 
    {
        private readonly TransportNotesDbContextFacotry _contextFacotry;

        public NonQueryService(TransportNotesDbContextFacotry contextFacotry)
        {
            _contextFacotry = contextFacotry;
        }

        public async Task<T> Create(T entity)
        {
            using(TransportNotesDbContext context = _contextFacotry.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return createdResult.Entity;
            }
        }
        public async Task<T> Update(int id,T entity)
        {
            using(TransportNotesDbContext context = _contextFacotry.CreateDbContext())
            {
                entity.Id = id;

                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
        public async Task<bool> Delete(int id)
        {
            using(TransportNotesDbContext context = _contextFacotry.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
