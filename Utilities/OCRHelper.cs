using System;
using ImageOCRAutomation.Models;

namespace ImageOCRAutomation.Utilities
{
    public static class OCRHelper
    {
        public static T PopulateModelFromResx<T>(string resxFileName, string alias) where T : new()
        {
            var model = new T();
            var resxData = ResxDataLoader.LoadResxFile(resxFileName);

            var modelProps = typeof(T).GetProperties();

            foreach (var prop in modelProps)
            {
                string key = $"{alias}.{prop.Name}";
                if (resxData.TryGetValue(key, out string value))
                {
                    prop.SetValue(model, Convert.ChangeType(value, prop.PropertyType));
                }
            }

            return model;
        }
    }
}
