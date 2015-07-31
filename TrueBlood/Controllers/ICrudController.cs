using System.Collections.Generic;
using System.Web.Http;
using TrueBlood.Models;

namespace TrueBlood.Controllers
{
    public interface ICrudController<T> where T : BaseModel
    {
        T Get(uint id);
        T Post([FromBody]T model);
        bool Put([FromBody] T model);
        bool Delete(uint id);
    }
}