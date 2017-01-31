using System;

using System.Linq;


namespace SortNames
{
    class Program
    {
        public static void Main(string[] args)
        {
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            var paths = Util.GetFileList(args);
            if (paths == null || !paths.Any())
            {
                Console.WriteLine("sort-names usage: *.txt file within the current path or file with full path");
            }
            foreach (var path in paths)
            {
                Console.WriteLine("sort-names "+ path);
                var result =  Util.SortNames(path);
           
                Console.WriteLine(result);

                var fileName =Util.SaveToFile(path, result);
                Console.WriteLine("Finished: created "+ fileName);
            }
           
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
