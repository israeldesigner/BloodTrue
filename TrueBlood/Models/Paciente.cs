using System;

namespace TrueBlood.Models
{
    public class Paciente : BaseModel
    {
        public string Nome { get; set; }
        public string Hospital { get; set; }
        public int NumeroDoadores { get; set; }
        public DateTime Prazo { get; set; }
        public Cidade Cidade { get; set; }
        public string Email { get; set; }
    }
}