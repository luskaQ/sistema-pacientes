using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPacientesBlazor.Models
{
    public class Consulta
    {
        [Key]
        public int Id { get; set; } //chave primaria

        public string Desc { get; set; } = "";
        public string Motivo { get; set; } = "";
        public DateTime Data { get; set; }
        [Required]
        [MaxLength(11)]
        public string CpfPaciente {get;set;} = ""; //chave estrangeira

        [ForeignKey(nameof(CpfPaciente))]
        public Paciente? Paciente{get;set;}

    }
}   