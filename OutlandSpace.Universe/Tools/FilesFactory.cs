﻿using System;
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

            var tasks = GetFilesContentFromDirectoryAsync(rootFolder, fileExtention);

            foreach (var fileContent in tasks.GetAwaiter().GetResult())
            {
                resultCollection.Add(fileContent);
            }

            return resultCollection;
        }

        async static Task<string[]> GetFilesContentFromDirectoryAsync(string rootFolder, string fileExtention )
        {
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