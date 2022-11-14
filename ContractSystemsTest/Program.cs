using System;
using System.Windows;


namespace ContractSystemsTest
{
    class ContractSystemsTest
    {
        static void Main()
        {
            string Path = Directory.GetCurrentDirectory();  // ищем путь до папки .dll
            
            Path = Path.Substring(0, Path.Length - 56);
            Console.WriteLine(Path);// путь до директории с папкой проекта
            Set Set = new Set();
            Set.Types = new Dictionary<string, int>();
            Set.TypesPercent = new Dictionary<string, double>();
            Set.MidSize = new Dictionary<string, long>();
            Set.Amount = 0;
            GetSet GetSet = new GetSet();
            GetSize GetSize = new GetSize();
            GetType GetType = new GetType();
            List<string> SetForType = new List<string>();
            
            SetForType = GetSet.GetRecursFiles(Path); // находим все папки и файлы в каталоге
            Set.List = SetForType;
             // добавили типы файлов
            Set = GetSize.GetDirectorySize(Set);  // добавили размер директорий

            Set = GetSize.GetFilesSize(Set);  // добавили размер файлов
            Set = GetType.GetSetType(Set);
            // Set = GetType.GetSetType(Set, SetForType);  // добавили типы файлов
            foreach (var Key in Set.MidSize.Keys)
            {
                Set.MidSize[Key] = (long)Set.MidSize[Key] / Set.Types[Key];
            }
            foreach (var Key in Set.Types.Keys)
            {
                Set.TypesPercent.Add(Key, (double)Set.Types[Key]/Set.Amount * 100);
            }

            using (var writer = new StreamWriter("../../../../Result.html"))
            {
                writer.WriteLine("<b>Список всех файлов и директорий (путь, размер, тип):</b>");
                for(int i = 0; i < Set.List.Count; i++)
                {
                    writer.WriteLine(Set.List[i]+ "<br>");
                }
                 writer.WriteLine(("<b>Список MimeTypes (тип - количество):</b>"));
                foreach (var Key in Set.Types.Keys)
                {
                    writer.WriteLine($"Тип: {Key}  Количество: {Set.Types[Key]}<br>");
                }
                writer.WriteLine("<b>Список MimeTypes (тип - количество(%):</b>");
                foreach (var Key in Set.TypesPercent.Keys)
                {
                    writer.WriteLine($"Тип: {Key}  Количество(%): {Set.TypesPercent[Key]}<br>");
                }
                writer.WriteLine("<b>Список MimeTypes (тип - средний размер):</b>");
                foreach (var Key in Set.MidSize.Keys)
                {
                    writer.WriteLine($"Тип: {Key}  размер: {Set.MidSize[Key]}<br>");
                }
            }

        }


    }
}
