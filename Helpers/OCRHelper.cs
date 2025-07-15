using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;
using System.Resources;
using ImageOCRAutomation.Models;

namespace ImageOCRAutomation.Helpers
{
    public static class OCRHelper
    {
        public static T PopulateModelFromResx<T>(string alias, string resxName) where T : new()
        {
            var model = new T();
            var type = typeof(T);
            var resourceManager = new ResourceManager($"ImageOCRAutomation.Resources.{resxName}", Assembly.GetExecutingAssembly());
            var properties = type.GetProperties();

            foreach (var prop in properties)
            {
                var key = $"{alias}.{prop.Name}";
                var value = resourceManager.GetString(key);
                if (value != null)
                    prop.SetValue(model, Convert.ChangeType(value, prop.PropertyType));
            }

            return model;
        }
    }
}
