using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNames
{
    public class Util
    {
        /// <summary>
        /// get the file paths from arguments, return empty list if file path not correct
        /// </summary>
        /// <param name="args"></param>
        /// <returns>list of file path</returns>
        public static List<string> GetFileList(string[] args)
        {
            List<string> result = new List<string>();
            //no argument
            if (args == null || !args.Any())
            {
                return result;
            }

            foreach (var path in args)
            {
                //empty arugment
                if (string.IsNullOrEmpty(path))
                    return result;
                //not a txt file
                if (!path.ToLower().EndsWith(".txt"))
                    return result;
                //if in the current path
                var fullPath = Path.GetFullPath(path);
                if (File.Exists(fullPath))
                {
                    //add to the list
                    result.Add(fullPath);
                }

            }

            return result;


        }

        /// <summary>
        /// sort the name
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>sorted name string</returns>
        public static string SortNames(string path)
        {
               
            var fileExists = File.Exists(path);
             //check if file existed 
            if (!fileExists)
                throw new FileNotFoundException("File Not Found");

            var result  = File.ReadLines(path)
                // sort by the name
                .OrderBy(name => name);
            var strSorted =   string.Join(Environment.NewLine, result.ToArray());
            return strSorted;

        }

        /// <summary>
        /// save string to the file and return the new file name
        /// </summary>
        /// <param name="path">original file name</param>
        /// <param name="text">oringal file string</param>
        /// <returns>saved file name</returns>
        public static string SaveToFile(string path, string text)
        {
            var fileExists = File.Exists(path);

            if (!fileExists) throw new FileNotFoundException("File Not Found");

            //make new file name
            var strNewFileName = Path.GetFileNameWithoutExtension(path) + "-sorted.txt";

            var strNewPath = Path.GetDirectoryName(path) +@"\" +strNewFileName;

            //write to the new file
            File.WriteAllText(strNewPath, text);

            return strNewFileName;
        }

    }
}
