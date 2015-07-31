using System;
using System.Collections.Generic;
using System.Linq;
using TrueBlood.Models;

namespace TrueBlood.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : BaseModel
    {
        protected readonly IList<T> Table;

        protected Repository()
        {
            Table = new List<T>();
        }

        public T Create(T model)
        {
            var newModel = model.Copy() as T;
            if (newModel != null)
            {
                newModel.Id = Table.Any() ? Table.Max(t => t.Id) + 1 : 1;
                Table.Add(newModel);
            }
            return newModel;
        }

        public T Read(uint id)
        {
            return Table.FirstOrDefault(t => t.Id == id);
        }

        public bool Update(T model)
        {
            if (model.Id > 0)
            {
                var oldModel = Table.FirstOrDefault(t => t.Id == model.Id);
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
            var model = Table.FirstOrDefault(t => t.Id == id);
            if (model != null)
            {
                Table.Remove(model);
                return true;
            }
            return false;
        }

        public IList<T> List()
        {
            return Table.Select(t => (T) t.Copy()).ToList();
        }

        public IEnumerable<T> Filter(Func<T, bool> condition)
        {
            return Table.Where(condition);
        }
    }
}