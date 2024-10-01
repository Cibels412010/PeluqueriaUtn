using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTurnos.Models;

namespace BackTurnos.Repository
{
    public interface IServicioRepository
    {
        Task<bool> SaveAsync(TServicio servicio);
        Task<bool> DeleteAsync(int id);
        Task<List<TServicio>> GetAllAsync();
        Task<TServicio> GetOneAsync(int id);
    }
    public class ServicioRepository : IServicioRepository
    {
        //creo una instancia de la bd
        private readonly DbCici2Context _context;

        //inyecto dependecnia
        public ServicioRepository(DbCici2Context context)
        {
                _context = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var serv = await GetOneAsync(id);
            if (serv != null)
            {
                _context.TServicios.Remove(serv);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<TServicio>> GetAllAsync()
        {
            //devuelvo un lista de servicios
            return await _context.TServicios
                .ToListAsync();          
        }

        public async Task<TServicio> GetOneAsync(int id)
        {
            return await _context.TServicios.FirstOrDefaultAsync(s => s.Id == id);
        }


        public async Task<bool> SaveAsync(TServicio servicio)
        {
            if (servicio.Id == 0)
            {
                var UltimoId = await _context.TServicios.MaxAsync(s => s.Id);
                int newId = UltimoId + 1;
                servicio.Id = newId;
                _context.TServicios.Add(servicio);
            }
            else
            {
                _context.TServicios.Update(servicio);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        
    }
}
