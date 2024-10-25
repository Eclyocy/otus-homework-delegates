using Delegates.Events;
using Delegates.Helpers;

namespace Delegates
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Data");

            DirectoryHelper directoryHelper = new();
            directoryHelper.FileFound += EventHandlers.OnFileFound;

            directoryHelper.FindDirectoryFiles(directoryPath);
        }
    }
}
