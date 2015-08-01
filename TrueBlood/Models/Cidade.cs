using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrueBlood.Models
{
    public class Cidade
    {
        [Key]
        public int CidadeId { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }

        public virtual IEnumerable<Paciente> Pacientes { get; set; }
    }
}