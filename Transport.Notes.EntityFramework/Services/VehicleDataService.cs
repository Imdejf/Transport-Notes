using Microsoft.EntityFrameworkCore;
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
                return await context.Vehicles
                    .Include(e => e.Equipment)
                    .FirstOrDefaultAsync((e) => e.Id == id);
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

        public async Task<Vehicle> GetById(int id)
        {
            using (TransportNotesDbContext context = _contextFacotry.CreateDbContext())
            {
                return await context.Vehicles
                    .Include(i => i.Id)
                    .Include(a => a.Equipment)
                    .FirstOrDefaultAsync(a => a.Id == id);
            }
        }
        public async Task<bool> DeleteEquipment(int id)
        {
            using (TransportNotesDbContext context = _contextFacotry.CreateDbContext())
            {
                Equipment vehicle = await context.Set<Equipment>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<Equipment>().Remove(vehicle);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Vehicle> GetByRegistrationNumber(string registrationNumber)
        {
            using (TransportNotesDbContext context = _contextFacotry.CreateDbContext())
            {
                return await context.Vehicles
                    .FirstOrDefaultAsync(v => v.RegistrationNumber == registrationNumber) ;
            }
        }

        public async Task<Vehicle> GetByVIN(string vin)
        {
            using (TransportNotesDbContext context = _contextFacotry.CreateDbContext())
            {
                return await context.Vehicles
                    .FirstOrDefaultAsync(v => v.VIN == vin);
            }
        }

        public Task<Vehicle> Update(Vehicle entity, int id)
        {
            return _nonQueryService.Update(id, entity);
        }
    }
}
