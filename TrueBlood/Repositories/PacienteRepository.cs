using System.Collections.Generic;
using TrueBlood.Models;

namespace TrueBlood.Repositories
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        IEnumerable<Paciente> Filter(string query);
    }

    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {
        public IEnumerable<Paciente> Filter(string query)
        {
            query = query.Trim().ToLower();
            return Filter(p =>
                          (p.Nome != null && p.Nome.ToLower().Contains(query)) ||
                          (p.Email != null && p.Email.ToLower().Contains(query)) ||
                          (p.Cidade != null && p.Cidade.Nome.ToLower().Contains(query)) ||
                          (p.Hospital?.Nome != null && p.Hospital.Nome.ToLower().Contains(query)));
        }
    }
}