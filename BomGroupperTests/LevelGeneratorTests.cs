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
        [DataRow(2, ".1")]
        [DataRow(4, "...3")]
        [DataRow(7, "......6")]
        [DataRow(0, "")]
        public void GetLevelStringTest(int input, string expected)
        {
            string actual = LevelGenerator.GetLevelString(input);
            Assert.AreEqual(expected, actual);
        }
    }
}