using System;
using System.IO;

namespace Solid03.LSP
{
    public abstract class PersistedSettingsBase: IPersistedSettings
    {
        static PersistedSettingsBase()
        {
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
        }

        protected string FilePath => Path.Combine(DirectoryPath, FileName);

        protected abstract string FileName { get; }

        protected static string DirectoryPath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "solid-03-lsp");

        public abstract void Load();

        public abstract void Persist();
    }
}
