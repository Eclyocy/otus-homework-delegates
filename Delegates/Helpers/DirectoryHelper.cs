using Delegates.Events;

namespace Delegates.Helpers
{
    public static class DirectoryHelper
    {
        public static void Blah(string directoryPath)
        {
            directoryPath = Path.GetFullPath(directoryPath);

            if (!Directory.Exists(directoryPath))
            {
                throw new ArgumentException($"Directory {directoryPath} does not exist.");
            }

            foreach (string filePath in Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories))
            {
                FileArgs fileArgs = new(filePath);
                Console.WriteLine(fileArgs);
            }
        }
    }
}
