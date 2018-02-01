using System.IO;

namespace SkillMatrix.Common
{
    public static partial class Utilities
    {
        public static string EnsureDirectoryExists(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            return directoryPath;
        }
        public static bool FileEnsureOrDelete(string directoryPath)
        {
            if (File.Exists(directoryPath))
            {
                File.Delete(directoryPath);
                return true;
            }
            return false;

        }

        public static bool FileEnsure(string directoryPath)
        {
            return File.Exists(directoryPath);
        }

    }
}
