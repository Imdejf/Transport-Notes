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
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly TransportNotesDbContextFacotry _contextFactory;
        private readonly NonQueryService<T> _nonQueryService;

        public GenericDataService(TransportNotesDbContextFacotry contextFacotry)
        {
            _contextFactory = contextFacotry;
            _nonQueryService = new NonQueryService<T>(contextFacotry);
        }
        public async Task<T> Create(T entity)
        {
            return await _nonQueryService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryService.Delete(id);
        }

        public async Task<T> Get(int id)
        {
            using(TransportNotesDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (TransportNotesDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<T> Update(T entity, int id)
        {
            return await _nonQueryService.Update(id, entity);
        }
    }
}
