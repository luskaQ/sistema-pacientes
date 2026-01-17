using Microsoft.EntityFrameworkCore;
using SistemaPacientesBlazor.Data;
using SistemaPacientesBlazor.Models;

namespace SistemaPacientesBlazor.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly AppDbContext _context;

        public ConsultaService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Consulta>> GetAllAsync()
        {
            return await _context.Consultas.ToListAsync();
        }

        public async Task<List<Consulta>> GetByCpfAsync(string cpf)
        {
            return await _context.Consultas
                .Where(c => c.CpfPaciente == cpf)
                .Include(c => c.Paciente)
                .ToListAsync();
        }

        public async Task<Consulta?> GetByIdAsync(int id)
        {
            return await _context.Consultas
                .FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task AddAsync(Consulta consulta)
        {
            _context.Consultas.Add(consulta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Consulta consulta)
        {
            _context.Consultas.Update(consulta);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var consulta = await GetByIdAsync(id);
            if (consulta != null)
            {
                _context.Consultas.Remove(consulta);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAllAsync(string cpf)
        {
            var consultas = await _context.Consultas
                .Where(c => c.CpfPaciente == cpf)
                .ToListAsync();

            if (consultas.Count == 0)
                return;

            _context.Consultas.RemoveRange(consultas);
            await _context.SaveChangesAsync();
        }
    }
}