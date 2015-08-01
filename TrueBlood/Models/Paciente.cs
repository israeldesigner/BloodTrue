using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TrueBlood.Models
{
    public class Paciente : BaseModel
    {
        [Key]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [DisplayName("Numero de Doadores ?")]
        public int NumeroDoadores { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Prazo { get; set; }

        public int HospitalId { get; set; }
        public int CidadeId { get; set; }

        public virtual Hospital Hospital { get; set; }
        public virtual Cidade Cidade { get; set; }


    }
}