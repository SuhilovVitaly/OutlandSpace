using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OutlandSpace.Universe.Tools
{
    public class FilesFactory
    {
        private const int BufferSize = 4096;

        public static List<string> GetFilesContentFromDirectory(string rootFolder, string fileExtention = "*.json")
        {
            var resultCollection = new List<string>();

            var rootScenarioPath = Path.Combine(rootFolder);

            if (!Directory.Exists(rootScenarioPath))
            {
                return new List<string>();
            }

            try
            {
                var rootPath = Path.Combine(Environment.CurrentDirectory, rootFolder);
                var allFiles = Directory.GetFiles(rootPath, fileExtention, SearchOption.AllDirectories);

                resultCollection.AddRange(allFiles.Select(File.ReadAllText));
                //var tasks = GetFilesContentFromDirectoryAsync(rootFolder, fileExtention);

                //foreach (var fileContent in tasks.GetAwaiter().GetResult())
                //{
                //    resultCollection.Add(fileContent);
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return resultCollection;
        }

        private static async Task<string[]> GetFilesContentFromDirectoryAsync(string rootFolder, string fileExtention )
        {
            var rootPath = Path.Combine(Environment.CurrentDirectory, rootFolder);
            var allFiles = Directory.GetFiles(rootPath, fileExtention, SearchOption.AllDirectories);

            Task<string>[] readTasks = new Task<string>[allFiles.Length];

            for (var i = 0; i < allFiles.Length; i++)
            {
                try
                {
                    readTasks[i] = ReadFileContentAsync(allFiles[i]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return await Task.WhenAll(readTasks);
        }

        private static async Task<string> ReadFileContentAsync(string fileName)
        {
            using var stream = new FileStream(
                fileName,
                FileMode.Open,
                FileAccess.Read,
                FileShare.None,
                BufferSize,
                FileOptions.Asynchronous);

            using var sr = new StreamReader(stream);

            string fileContent = "";

            while (sr.Peek() > -1)
            {
                try
                {
                    fileContent += await sr.ReadLineAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
            }

            return fileContent;
        }
    }
}
