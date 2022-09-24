using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace OutlandSpace.Universe.Tools
{
    public class FilesFactory
    {
        const int BUFFER_SIZE = 4096;

        public static List<string> GetFilesContentFromDirectory(string rootFolder, string fileExtention = "*.json")
        {
            var resultCollection = new List<string>();

            var rootScenarioPath = Path.Combine(rootFolder);

            if (!Directory.Exists(rootScenarioPath))
            {
                return new List<string>();
            }

            var tasks = GetFilesContentFromDirectoryAsync(rootFolder, fileExtention);

            foreach (var fileContent in tasks.GetAwaiter().GetResult())
            {
                resultCollection.Add(fileContent);
            }

            return resultCollection;
        }

        async static Task<string[]> GetFilesContentFromDirectoryAsync(string rootFolder, string fileExtention )
        {
            //"/Users/vitalysushilov/Projects/OutlandSpace/OutlandSpace.Tests/bin/Debug/netcoreapp3.1/TestsData/Scenarios/7045d54c-412b-429e-b1ed-43e62dcc10e6/Dialogs"
            //"/Users/vitalysushilov/Projects/OutlandSpace/OutlandSpace.Tests/bin/Debug/netcoreapp3.1/TestsData/Scenarios/7045d54c-412b-429e-b1ed-43e62dcc10e6/Dialogs"
            var rootPath = Path.Combine(Environment.CurrentDirectory, rootFolder);
            var allfiles = Directory.GetFiles(rootPath, fileExtention, SearchOption.AllDirectories);

            Task<string>[] readTasks = new Task<string>[allfiles.Length];

            for (int i = 0; i < allfiles.Length; i++)
            {
                readTasks[i] = ReadFileContentAsync(allfiles[i]);
            }
           

            return await Task.WhenAll(readTasks);
        }

        async static Task<string> ReadFileContentAsync(string fileName)
        {
            using var stream = new FileStream(
                fileName,
                FileMode.Open,
                FileAccess.Read,
                FileShare.None,
                BUFFER_SIZE,
                FileOptions.Asynchronous);

            using var sr = new StreamReader(stream);

            string fileContent = "";

            while (sr.Peek() > -1)
            {
                fileContent += await sr.ReadLineAsync();
            }

            return fileContent;
        }
    }
}
