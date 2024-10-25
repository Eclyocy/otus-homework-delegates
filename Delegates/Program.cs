using Delegates.Events;
using Delegates.Extensions;
using Delegates.Helpers;

namespace Delegates
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");

            DirectoryHelper directoryHelper = new();
            directoryHelper.FileFound += OnFileFound;

            List<FileArgs> files = [];
            directoryHelper.FileFound += (sender, e) =>
            {
                files.Add(e);

                if (files.Count >= 3)
                {
                    e.Cancel = true;
                }
            };

            directoryHelper.FindDirectoryFiles(directoryPath);

            FileArgs? largestFile = files.GetMax(x => x.FileSize);
            Console.WriteLine($"Largest file is: {largestFile}");
        }

        private static void OnFileFound(object sender, FileArgs e)
        {
            Console.WriteLine($"File found: {e}");
        }
    }
}
