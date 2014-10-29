using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using SharedClasses.Data.Attributes;

namespace SharedClasses.Data.AbstractClasses
{
    public abstract class DataModel
    {
        public static Database Instance;

        public static IEnumerable<T> Select<T>() where T : DataModel
        {
            if (Instance == null) throw new DataException("Instance of database was not set.");

            return Enumerable.Empty<T>();
        }

        public PropertyInfo GetKeyProperty()
        {
            return GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(prop => prop.GetCustomAttributes<KeyAttribute>(true).Any());
        }
    }
}