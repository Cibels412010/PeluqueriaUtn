using BackTurnos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTurnos.Models;

namespace BackTurnos.Servicio
{
    public interface IPeluqueriaServicio
    {
        //SERVICIO
        Task<bool> Guardar(TServicio servicio);
        Task<bool> DarBaja(int id);
        Task<List<TServicio>> MostrarTodos();
        Task<TServicio> MostrarUno(int id);

        //TURNOS

        Task<bool> GuardarTurno(TTurno turno);
        Task<bool> DarBajaTurno(int id);
        Task<List<TTurno>> MostrarTurnos();
        Task<TTurno> MostrarUnTurno(int id);
    }
    public class PeluqueriaServicio : IPeluqueriaServicio
    {
        private readonly IServicioRepository _servicioRepository;
        private readonly ITurnoRepository _turnoRepository;

        public PeluqueriaServicio(IServicioRepository servicioRepository, ITurnoRepository turnoRepository)
        {
            _servicioRepository = servicioRepository;
            _turnoRepository = turnoRepository;
        }

        public async Task<bool> DarBaja(int id)
        {
            var servicioexiste = await _servicioRepository.DeleteAsync(id);
            if (servicioexiste != null)
            {
                await _servicioRepository.DeleteAsync(id);
                return true;
            }
            return false;
        }

        public async Task<bool> DarBajaTurno(int id)
        {
            var turnoExiste = await _turnoRepository.DeleteAsync(id);
            if (turnoExiste != null)
            {
                await _turnoRepository.DeleteAsync(id);
                return true;
            }
            return false;
        }

        public async Task<bool> Guardar(TServicio servicio)
        {
           return await _servicioRepository.SaveAsync(servicio);
        }

        public async Task<bool> GuardarTurno(TTurno turno)
        {
            return await _turnoRepository.SaveAsync(turno);
        }

        public async Task<List<TServicio>> MostrarTodos()
        {
            return await _servicioRepository.GetAllAsync();
        }

        public async Task<List<TTurno>> MostrarTurnos()
        {
            return await _turnoRepository.GetAllAsync();
        }

        public async Task<TServicio> MostrarUno(int id)
        {
           return await _servicioRepository.GetOneAsync(id);
        }

        public async Task<TTurno> MostrarUnTurno(int id)
        {
            return await _turnoRepository.GetOneAsync(id);
        }
    }
}
