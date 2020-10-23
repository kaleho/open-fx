using System.Linq;

namespace System.IO
{
    public static class DirectoryExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="path"></param>
        /// <param name="extensions">With or without the initial (.)</param>
        /// <returns></returns>
        public static string[] GetFilesWithExtensions(
            this string path,
            params string[] extensions)
        {
            if (extensions == null || extensions.Length <= 0)
            {
                throw new ArgumentException("The list of extensions is missing or invalid.");
            }

            var fileExtensions = extensions.Select(x => x.StartsWith(".") ? x : $".{x}");

            var returnValue =
                Directory
                    .GetFiles(path)
                    .Where(x => fileExtensions.Contains(Path.GetExtension(x)))
                    .ToArray();

            return returnValue;
        }

        public static string ParentDirectory(
            this string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("The location is missing or invalid.");
            }

            if (!Directory.Exists(path) && !File.Exists(path))
            {
                throw new ArgumentException($"The file or directory specified ({path}) is missing or invalid.");
            }

            var returnValue = Path.GetDirectoryName(path);

            return returnValue;
        }
    }
}