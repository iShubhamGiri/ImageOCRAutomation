using System.Collections.Generic;

namespace ImageOCRAutomation.Utilities
{
    public static class ContextManager
    {
        private static readonly Dictionary<string, object> Collection = new();

        public static void AddToCollection(string alias, object data)
        {
            Collection[alias] = data;
        }

        public static T GetFromCollection<T>(string alias)
        {
            return (T)Collection[alias];
        }

        public static void ClearContext()
        {
            Collection.Clear();
        }
    }
}
