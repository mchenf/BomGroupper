using Microsoft.VisualStudio.TestTools.UnitTesting;
using BomGroupper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomGroupper.Tests
{
    [TestClass()]
    public class LevelGeneratorTests
    {
        [TestMethod()]
        [DataRow(1, ".1")]
        [DataRow(3, "...3")]
        [DataRow(6, "......6")]
        [DataRow(0, "")]
        [DataRow(13, ".............13")]
        [DataRow(113, ".................................................................................................................113")]
        public void GetLevelStringTest(int input, string expected)
        {
            string actual = LevelGenerator.GetLevelString(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(1, ".1")]
        [DataRow(3, "...3")]
        [DataRow(6, "......6")]
        [DataRow(0, "")]
        [DataRow(13, ".............13")]
        [DataRow(113, ".................................................................................................................113")]
        public void TryParseLevelTest(int expected, string input)
        {
            if(LevelGenerator.TryParseLevel(input, out int actual))
            {
                Assert.AreEqual(expected, actual);
            }
        }
    }
}