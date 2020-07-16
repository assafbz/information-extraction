using System.Collections.Generic;
using System.Linq;
using Text.Info.Extract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System;
using System.IO;

namespace Text.Info.Extract.UnitTest
{
    [TestClass]
    public class InformationExtractorUnitTest
    {
        private InformationExtractor informationExtractor = new InformationExtractor();   
        public InformationExtractorUnitTest()
        {
        }

        [TestMethod]
        public void InformationExtractorSimpleTest()
        {
            string text = File.ReadAllText("../../../Texts/alice29.txt");
            for (int i = 0; i < 5; i++)
            {
                DateTime startTime = DateTime.Now;
                IEnumerable<InfoItem> infoItems = informationExtractor.ExtractInfo(text);
                DateTime endTime = DateTime.Now;
                TimeSpan timeDiff = endTime-startTime;
                Assert.IsTrue(timeDiff.TotalMilliseconds < 130);
            }
            

        }
    }
}
