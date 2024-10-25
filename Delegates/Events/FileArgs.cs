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

        protected string FileName { get; } = Path.GetFileName(filePath);

        protected string FilePath { get; } = Path.GetFullPath(filePath);

        protected long FileSize { get; } = new FileInfo(filePath).Length;
    }
}
