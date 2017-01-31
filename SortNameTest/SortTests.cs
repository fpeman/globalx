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
           
           var result = @"BAKER, THEODORE
KENT, MADISON
SMITH, ANDREW
SMITH, FREDRICK";//SortNames.Util.SortNames( System.IO.Directory.GetCurrentDirectory()+@"\names.txt");
            var expected = @"BAKER, THEODORE
KENT, MADISON
SMITH, ANDREW
SMITH, FREDRICK";

                //File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + @"\sorted.txt");

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
