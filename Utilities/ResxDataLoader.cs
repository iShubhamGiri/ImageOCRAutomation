using System.Collections.Generic;
using System.Resources;
using System.Collections;

namespace ImageOCRAutomation.Utilities
{
    public static class ResxDataLoader
    {
        public static Dictionary<string, string> LoadResxFile(string resourceFileName)
        {
            var data = new Dictionary<string, string>();

            using (ResXResourceReader resxReader = new($@"Resources\{resourceFileName}.resx"))
            {
                resxReader.UseResXDataNodes = true;

                foreach (DictionaryEntry entry in resxReader)
                {
                    if (entry.Key is string key && entry.Value is string value)
                    {
                        data[key] = value;
                    }
                }
            }

            return data;
        }
    }
}
