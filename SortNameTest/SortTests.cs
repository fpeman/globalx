using System;
using System.IO;
using System.Linq;
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
           
           var result = SortNames.Util.SortNames( System.IO.Directory.GetCurrentDirectory()+@"\names.txt");



           // var expected = File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + @"\sorted.txt");

            //re-parse the file for appveyor testing
            var expectFile = File.ReadLines(System.IO.Directory.GetCurrentDirectory() + @"\sorted.txt");
            var expected = string.Join(Environment.NewLine, expectFile.ToArray());


            Assert.AreEqual<string>(expected, result);


        }


        [TestMethod]
        public void ReadAndWriteTest()
        {
            var result = SortNames.Util.SortNames(System.IO.Directory.GetCurrentDirectory() + @"\names.txt");
            var filePath = SortNames.Util.SaveToFile(System.IO.Directory.GetCurrentDirectory() + @"\names.txt", result);

            var fileResult =  File.ReadAllText(filePath);
            var expected = @"BAKER, THEODORE
KENT, MADISON
SMITH, ANDREW
SMITH, FREDRICK";
            //File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + @"\sorted.txt");

            Assert.AreEqual<string>(expected, fileResult);
        }
    }
}
