using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TrueBlood.Models
{
    public class Hospital
    {
        [Key]
        public int HospitalId { get; set; }
        public string Nome { get; set; }
        public virtual IEnumerable<Paciente> Pacientes { get; set; }
    }
}