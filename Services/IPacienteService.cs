using SistemaPacientesBlazor.Models;

namespace SistemaPacientesBlazor.Services
{
    public interface IPacienteService
    {
        Task<List<Paciente>> GetAllAsync();
        Task<Paciente?> GetByCpfAsync(string cpf);

        Task<List<Paciente>> GetByDateAsync(DateTime data);
        Task AddAsync(Paciente paciente);
        Task UpdateAsync(Paciente paciente);
        Task DeleteAsync(string cpf);
    }
}