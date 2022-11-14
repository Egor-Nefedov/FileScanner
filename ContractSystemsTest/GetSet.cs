using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractSystemsTest
{
     class GetSet
    {
        public static List<string> GetRecursFiles(string Path)  //рекурсивно находим все папки и файлы
        {
            List<string> Set = new List<string>();

            string[] Directories = Directory.GetDirectories(Path);
            foreach (string Directory in Directories)
            {
                Set.Add("Папка: " + Directory);
                Set.AddRange(GetRecursFiles(Directory));
            }
            string[] files = Directory.GetFiles(Path);
            foreach (string filename in files)
            {
                Set.Add("Файл: " + filename);
            }
           
        return Set;
        }
    }
}
