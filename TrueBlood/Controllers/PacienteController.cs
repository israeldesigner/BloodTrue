using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TrueBlood.Models;
using TrueBlood.Repositories;

namespace TrueBlood.Controllers
{
    [RoutePrefix("api/paciente")]
    public class PacienteController : CrudController<Paciente>
    {
        private static IPacienteRepository _repository;

        public override IRepository<Paciente> GetRepository()
        {
            return _repository = _repository ?? new PacienteRepository(); //TODO: utilizar intetor de dependência
        }

        [HttpGet]
        [Route("list/{page:int?}/{pageSize:int?}")]
        public IEnumerable<Paciente> List(int page = 0, int pageSize = 10)
        {
            page = page > 0 ? page - 1 : 0;
            pageSize = pageSize > 0 ? pageSize : 10;
            var query = HttpUtility.ParseQueryString(Request.RequestUri.Query)["q"];
            IEnumerable<Paciente> result;

            if (string.IsNullOrWhiteSpace(query))
                result = Repository.List();
            else
                result = (Repository as IPacienteRepository).Filter(query);

            return result.Skip(page*pageSize).Take(pageSize);
        }
    }
}