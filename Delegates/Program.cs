using Delegates.Helpers;

namespace Delegates
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Data");

            DirectoryHelper.Blah(directoryPath);
        }
    }
}
