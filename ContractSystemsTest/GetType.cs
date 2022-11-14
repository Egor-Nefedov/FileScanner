using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractSystemsTest
{
    internal class GetType
    {
        public Set GetSetType(Set Set)
        {
            for (int i = 0; i < Set.List.Count; i++)
            {
                
                if (Set.List[i].Contains("Файл"))
                {
                    Set.Amount++;
                    var Files = Set.List[i].Split("  S"); 
                    var File = Files[0];
                    FileInfo file = new FileInfo(Files[0].Substring(6));
                    long Size = file.Length;
                    
                    string MimeType = file.Extension;
                    Set.List[i] = Set.List[i] + "  MimeType: " + MimeType + ";";
                    
                    try
                    {
                        Set.MidSize.Add(MimeType, Size);  
                        Set.Types.Add(MimeType, 1); 
                    }
                    catch
                    {
                        Set.MidSize[MimeType] = Set.MidSize[MimeType] + Size;
                        Set.Types[MimeType] = Set.Types[MimeType] + 1;
                    }

                }
            }
            return Set;
        }
    }
}
