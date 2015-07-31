using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TrueBlood.Models;
using TrueBlood.Repositories;

namespace TrueBlood.Controllers
{
    [RoutePrefix("api/paciente")]
    public class PacienteController : CrudController<Paciente>
    {
        private static IRepository<Paciente> _repository;

        public override IRepository<Paciente> GetRepository()
        {
            return _repository = _repository ?? new PacienteRepository(); //TODO: utilizar intetor de dependência
        }

        [HttpGet]
        [Route("list/{page:int}/{pageSize:int}")]
        public IEnumerable<Paciente> List(int page, int pageSize)
        {
            page = page > 0 ? page - 1 : 0;
            pageSize = pageSize > 0 ? pageSize : 10;
            return Repository.List()?.Skip(page * pageSize).Take(pageSize);
        }
    }
}