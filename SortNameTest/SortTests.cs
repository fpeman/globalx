using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortNameTest
{
    [TestClass]
    public class SortTests
    {
        [TestMethod]
        public void ReadFileTest()
        {
           
           var result =   SortNames.Util.SortNames( System.IO.Directory.GetCurrentDirectory()+@"\names.txt");
           var expected = File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + @"\sorted.txt");
            Console.WriteLine("result:"+result);
            Console.WriteLine("expected:" + expected);
            if (result==expected)
                Console.WriteLine("pass");

           Assert.AreEqual<string>(expected, result);


        }


        [TestMethod]
        public void ReadAndWriteTest()
        {
            var result = SortNames.Util.SortNames(System.IO.Directory.GetCurrentDirectory() + @"\names.txt");
            var filePath = SortNames.Util.SaveToFile(System.IO.Directory.GetCurrentDirectory() + @"\names.txt", result);

            var fileResult =  File.ReadAllText(filePath);
            var expected = File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + @"\sorted.txt");
            if (fileResult == expected)
                Console.WriteLine("pass");
            Assert.AreEqual<string>(expected, fileResult);
        }
    }
}
