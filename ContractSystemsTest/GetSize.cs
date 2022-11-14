using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractSystemsTest
{
    internal class GetSize
    {
        public Set GetFilesSize(Set Set)
        {
            for(int i = 0; i < Set.List.Count; i++)
            {
                if (Set.List[i].Contains("Файл"))
                {
                    FileInfo file = new FileInfo(Set.List[i].Substring(6));
                    long Size = file.Length;
                    Set.List[i] = Set.List[i] +"  Size: "+ Size + ";";
                }
            }
            return Set;
        }
        public Set GetDirectorySize(Set Set)
        {
            for (int i = 0; i < Set.List.Count; i++)
            {
                long DirectorySize = 0;
                if (Set.List[i].Contains("Папка"))
                {
                    
                    for (int j = i; j < Set.List.Count; j++)
                    {
                        if ((Set.List[j].Contains("Файл")) && (Set.List[j].Contains(Set.List[i].Substring(11))))
                        {
                           // Console.WriteLine((Set[i].Substring(11)));
                            FileInfo file = new FileInfo(Set.List[j].Substring(6));
                            long Size = file.Length;
                            DirectorySize = DirectorySize + file.Length;
                        }
                    }
                    Set.List[i] = Set.List[i] + "  Size: " + DirectorySize + ";";
                }

            }
            return Set;
        }
    }
}
