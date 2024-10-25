namespace Delegates.Events
{
    public class FileArgs(string filePath) : EventArgs
    {
        public override string ToString()
        {
            return string.Format(
                "File {0} with size {1} ({2})",
                FileName,
                FileSize,
                FilePath);
        }

        public string FileName { get; } = Path.GetFileName(filePath);

        public string FilePath { get; } = Path.GetFullPath(filePath);

        public long FileSize { get; } = new FileInfo(filePath).Length;

        public bool Cancel { get; set; } = false;
    }
}
