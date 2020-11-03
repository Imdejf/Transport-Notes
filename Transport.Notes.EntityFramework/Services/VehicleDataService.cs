﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services;
using Transport.Notes.EntityFramework.Services.Common;

namespace Transport.Notes.EntityFramework.Services
{
    public class VehicleDataService : IVehicleService
    {
        private readonly TransportNotesDbContextFacotry _contextFacotry;
        private readonly NonQueryService<Vehicle> _nonQueryService;

        public VehicleDataService(TransportNotesDbContextFacotry contextFacotry)
        {
            _contextFacotry = contextFacotry;
            _nonQueryService = new NonQueryService<Vehicle>(contextFacotry);
        }
        public async Task<Vehicle> Create(Vehicle entity)
        {
            return await _nonQueryService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryService.Delete(id);
        }

        public async Task<Vehicle> Get(int id)
        {
            using(TransportNotesDbContext context = _contextFacotry.CreateDbContext())
            {
                Vehicle entity = await context.Vehicles
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            using(TransportNotesDbContext context = _contextFacotry.CreateDbContext())
            {
                IEnumerable<Vehicle> entites = await context.Vehicles
                     .ToListAsync();
                return entites;
            }
        }

        public async Task<Vehicle> GetByRegistrationNumber(string registrationNumber)
        {
            using (TransportNotesDbContext context = _contextFacotry.CreateDbContext())
            {
                return await context.Vehicles
                    .FirstOrDefaultAsync();
            }
        }

        public async Task<Vehicle> GetByVIN(string vin)
        {
            using (TransportNotesDbContext context = _contextFacotry.CreateDbContext())
            {
                return await context.Vehicles
                    .FirstOrDefaultAsync();
            }
        }

        public Task<Vehicle> Update(Vehicle entity, int id)
        {
            return _nonQueryService.Update(id, entity);
        }
    }
}
