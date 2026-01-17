using SistemaPacientesBlazor.Models;

namespace SistemaPacientesBlazor.Services
{
    public interface IConsultaService
    {
        Task<List<Consulta>> GetAllAsync();
        Task<List<Consulta>> GetByCpfAsync(string cpf);
        Task<Consulta?> GetByIdAsync(int id);
        Task AddAsync(Consulta consulta);
        Task UpdateAsync(Consulta consulta);
        Task DeleteAsync(int id);
        Task DeleteAllAsync(string cpf);
    }
}