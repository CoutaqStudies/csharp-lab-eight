using System;

namespace LabSeven
{
    public class OsHelper
    {
        /// <summary>
        /// Formats the filepath string according to your os.
        /// </summary>
        /// <returns>
        /// A formatted string.
        /// </returns>
        /// <param name="filepath">The string that will be formatted.</param>
        /// <param name="relativePath">Is filepath relative to the executive or absolute.</param>
        public static String CompatiblePath(String filepath, Boolean relativePath)
        {
            String newFilePath = filepath;
            Boolean Unix = System.Environment.OSVersion.ToString().Contains("Unix");
            if (Unix)
                newFilePath = newFilePath.Replace('\\','/');
            else
                newFilePath = newFilePath.Replace('/', '\\');
            //TODO: come up with a better name for "relative path"
            if (relativePath)
                if (!Unix)
                    newFilePath = ".\\" + newFilePath;
            return newFilePath;
        }
    }
}