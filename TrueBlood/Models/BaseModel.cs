using System;

namespace TrueBlood.Models
{
    public class BaseModel
    {
        public uint Id { get; set; }

        public BaseModel Copy()
        {
            var type = GetType();
            var newBaseModel = Activator.CreateInstance(type);
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                property.SetValue(newBaseModel, property.GetValue(this));
            }

            return (BaseModel) newBaseModel;
        }
    }
}