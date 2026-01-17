using Microsoft.EntityFrameworkCore;
using SistemaPacientesBlazor.Data;
using SistemaPacientesBlazor.Models;

namespace SistemaPacientesBlazor.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly AppDbContext _context;

        public PacienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Paciente>> GetAllAsync()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente?> GetByCpfAsync(string cpf)
        {
            return await _context.Pacientes
                .Include(p => p.Consultas)
                .FirstOrDefaultAsync(p => p.Cpf == cpf);
        }

        public async Task<List<Paciente>> GetByDateAsync(DateTime data)
        {
            var inicio = data.Date;
            var fim = inicio.AddDays(1);
            inicio = DateTime.SpecifyKind(inicio, DateTimeKind.Utc);
            fim = DateTime.SpecifyKind(fim, DateTimeKind.Utc);

            return await _context.Pacientes
                .Where(p => p.Nascimento >= inicio && p.Nascimento < fim)
                .ToListAsync();
        }

        public async Task AddAsync(Paciente paciente)
        {
             _context.ChangeTracker.Clear();
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string cpf)
        {
            var paciente = await GetByCpfAsync(cpf);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
