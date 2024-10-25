using Delegates.Events;
using Delegates.Extensions;
using Delegates.Helpers;

namespace Delegates
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<FileArgs> files = [];

            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            DirectoryHelper directoryHelper = new();

            // Add common handler.
            directoryHelper.FileFound += (sender, e) =>
            {
                Console.WriteLine($"File found: {e}");
            };

            // Add handler for files accumulating.
            directoryHelper.FileFound += (sender, e) =>
            {
                files.Add(e);

                // Halting the program after third file for test purposes.
                if (files.Count >= 3)
                {
                    e.Cancel = true;
                }
            };

            directoryHelper.FindDirectoryFiles(directoryPath);

            FileArgs? largestFile = files.GetMax(x => x.FileSize);
            Console.WriteLine($"Largest file is: {largestFile}");
        }
    }
}
