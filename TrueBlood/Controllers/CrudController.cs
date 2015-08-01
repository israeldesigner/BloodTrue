using System.Web.Http;
using TrueBlood.Models;
using TrueBlood.Repositories;

namespace TrueBlood.Controllers
{
    public abstract class CrudController<T> : ApiController, ICrudController<T> where T : BaseModel
    {
        protected IRepository<T> Repository
        {
            get
            {
                return GetRepository(); //TODO: utilizar intetor de dependência
            }
        }

        public abstract IRepository<T> GetRepository();

        public virtual T Get(uint id)
        {
            return Repository.Read(id);
        }

        public virtual T Post(T model)
        {
            return Repository.Create(model);
        }

        public virtual bool Put(T model)
        {
            return Repository.Update(model);
        }

        public virtual bool Delete(uint id)
        {
            return Repository.Delete(id);
        }
    }
}