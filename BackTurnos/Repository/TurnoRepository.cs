using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTurnos.Models;

namespace BackTurnos.Repository
{
    public interface ITurnoRepository
    {
        Task<bool> SaveAsync(TTurno turno);
        Task<bool> DeleteAsync(int id);
        Task<List<TTurno>> GetAllAsync();
        Task<TTurno> GetOneAsync(int id);
    }
    public class TurnoRepository : ITurnoRepository
    {
        private readonly DbCici2Context _context;

        public TurnoRepository(DbCici2Context context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var darbaja = await GetOneAsync(id);
            if (darbaja != null)
            {
                _context.TTurnos.Remove(darbaja);
                
                return await _context.SaveChangesAsync() > 1;
            }
            return false;
        }

        public async Task<List<TTurno>> GetAllAsync()
        {
            return await _context.TTurnos.ToListAsync();
        }

        public async Task<TTurno> GetOneAsync(int id)
        {
            return await _context.TTurnos.FirstOrDefaultAsync(s => s.Id == id);


        }

        public async Task<bool> SaveAsync(TTurno turno)
        {
            if (turno.Id == 0)
            {
                _context.TTurnos.Add(turno);
                
            }
            else
            {
                _context.TTurnos.Update(turno);
            }
           return await _context.SaveChangesAsync() >0;
        }
    }
}
