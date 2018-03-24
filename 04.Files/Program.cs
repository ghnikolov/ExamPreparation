using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Files
{
    class File
    {
        public string root { get; set; }

        public string name { get; set; }

        public long size { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var filesPerRoot = new Dictionary<string, List<File>>();

            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine().Split(new[] { '\\', ';' }, StringSplitOptions.RemoveEmptyEntries);

                string rootFile = inputData[0];
                string fileName = inputData[inputData.Length - 2];
                long sizeFile = long.Parse(inputData[inputData.Length - 1]);

                if (!filesPerRoot.ContainsKey(rootFile))
                {
                    filesPerRoot[rootFile] = new List<File>();
                }

                var currentFileRoot = filesPerRoot[rootFile];

                var existingFile = currentFileRoot.FirstOrDefault(f => f.name == fileName);

                if (existingFile == null)
                {
                    var file = new File
                    {
                        root = rootFile,
                        name = fileName,
                        size = sizeFile
                    };
                    currentFileRoot.Add(file);
                }
                else existingFile.size = sizeFile;
            }
            string[] query = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string ext = query[0];
            string root = query[2];

            if (!filesPerRoot.ContainsKey(root))
            {
                Console.WriteLine("No");
                return;
            }

            var result = filesPerRoot[root].Where(f => f.name.EndsWith(ext)).OrderByDescending(f => f.size).ThenBy(f => f.name).ToList();

            if (!result.Any()) Console.WriteLine("No");
            else
            {
                foreach (var file in result)
                {
                    Console.WriteLine($"{file.name} - {file.size} KB");
                }
            }
        }
    }
}
