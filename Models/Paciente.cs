using System.ComponentModel.DataAnnotations;

namespace SistemaPacientesBlazor.Models
{
    public class Paciente
    {
        [Key]
        [MaxLength(11)]
        public string Cpf{get;set;} = ""; //chave primaria
        [Required]
        public string Nome{get;set;} = "";
        public DateTime Nascimento{get; set;}
        public string Contato{get;set;} = "";
        public string Endereco{get;set;} = "";

        public List<Consulta> Consultas{get;set;} = new(); //relacionamento
    }
}