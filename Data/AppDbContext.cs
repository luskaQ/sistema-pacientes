using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SistemaPacientesBlazor.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SistemaPacientesBlazor.Identity;

namespace SistemaPacientesBlazor.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Paciente> Pacientes => Set<Paciente>();
        public DbSet<Consulta> Consultas => Set<Consulta>();
    }
}