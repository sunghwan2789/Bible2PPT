using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bible2PPT.Bibles
{
    class BookAliases
    {
        public static List<List<string>> Map = new List<List<string>>();

        static BookAliases()
        {
            using var s = Resources.GetStream(@"BibleBookAliases.csv");
            using var reader = new StreamReader(s);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Map.Add(line.Split(',').ToList());
            }
        }
    }
}
