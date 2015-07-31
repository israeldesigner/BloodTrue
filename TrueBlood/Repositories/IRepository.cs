using System.Collections.Generic;
using TrueBlood.Models;

namespace TrueBlood.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        T Create(T model);
        T Read(uint id);
        bool Update(T model);
        bool Delete(uint id);
        IList<T> List();
    }
}