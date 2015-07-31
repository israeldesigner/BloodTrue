using System.Collections.Generic;
using System.Linq;
using TrueBlood.Models;

namespace TrueBlood.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly IList<T> _table;

        protected Repository()
        {
            _table = new List<T>();
        }

        public T Create(T model)
        {
            var newModel = model.Copy() as T;
            if (newModel != null)
            {
                newModel.Id = _table.Any() ? _table.Max(t => t.Id) + 1 : 1;
                _table.Add(newModel);
            }
            return newModel;
        }

        public T Read(uint id)
        {
            return _table.FirstOrDefault(t => t.Id == id);
        }

        public bool Update(T model)
        {
            if (model.Id > 0)
            {
                var oldModel = _table.FirstOrDefault(t => t.Id == model.Id);
                if (oldModel != null)
                {
                    var properties = GetType().GetProperties();
                    foreach (var property in properties)
                    {
                        property.SetValue(oldModel, property.GetValue(model));
                    }
                    return true;
                }
            }
            return false;
        }

        public bool Delete(uint id)
        {
            var model = _table.FirstOrDefault(t => t.Id == id);
            if (model != null)
            {
                _table.Remove(model);
                return true;
            }
            return false;
        }

        public IList<T> List()
        {
            return _table.Select(t => (T) t.Copy()).ToList();
        }
    }
}