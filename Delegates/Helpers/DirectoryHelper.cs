﻿using Delegates.Events;

namespace Delegates.Helpers
{
    public class DirectoryHelper
    {
        public event EventHandler<FileArgs> FileFound;

        public void FindDirectoryFiles(string directoryPath)
        {
            directoryPath = Path.GetFullPath(directoryPath);

            if (!Directory.Exists(directoryPath))
            {
                throw new ArgumentException($"Directory {directoryPath} does not exist.");
            }

            foreach (string filePath in Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories))
            {
                FileFound?.Invoke(this, new(filePath));
            }
        }
    }
}
