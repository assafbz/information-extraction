using System.Collections.Generic;
using System.Linq;
using Text.Info.Extract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System;

namespace Text.Info.Extract.UnitTest
{
    [TestClass]
    public class ExtractorUnitTests
    {
        private PhoneExtractor phoneExtractor = new PhoneExtractor();
        private EmailExtractor emailExtractor = new EmailExtractor();
        private IPv4Extractor ipv4Extractor = new IPv4Extractor();
        private UriExtractor uriExtractor = new UriExtractor();

        private VisaExtractor visaExtractor = new VisaExtractor();

        public ExtractorUnitTests()
        {
            phoneExtractor.ExtractInfo("aaa");
        }

        private void TestExtractor(
            string input, 
            IExtractor extractor, 
            int maxMilliseconds,
            string valueToValidate)
        {
            DateTime startTime = DateTime.Now;
            IEnumerable<InfoItem> infoItems = extractor.ExtractInfo(input);
            DateTime endTime = DateTime.Now;
            Assert.IsNotNull(infoItems);
            Assert.IsTrue(infoItems.Count() > 0);
            Assert.IsTrue((endTime-startTime).TotalMilliseconds < maxMilliseconds);
            Assert.AreEqual(infoItems.First().Value, valueToValidate);

        }

        [TestMethod]
        public void PhoneExtractorSimpleTests()
        {
            for (int i = 0; i < 5; i++)
            {
                string input = "Hey Buddy let's call 077-1234567 and wait for the tone.";
                TestExtractor(input, phoneExtractor, 15, "077-1234567");

                input = "Hey Buddy let's call 077.123.4567 and wait for the tone.";
                TestExtractor(input, phoneExtractor, 15, "077.123.4567");
            }
        }

        [TestMethod]
        public void EmailExtractorSimpleTests()
        {
            for (int i = 0; i < 5; i++)
            {
                string input = "Hey Buddy let's mail aaa@bbb.com and wait for the tone.";
                TestExtractor(input, emailExtractor, 20, "aaa@bbb.com");

                input = "Hey Buddy let's mail a1d2@gmail.co.uk and wait for the tone.";
                TestExtractor(input, emailExtractor, 20, "a1d2@gmail.co.uk");
            }
        }

        [TestMethod]
        public void IPv4ExtractorSimpleTests()
        {
            for (int i = 0; i < 5; i++)
            {
                string input = "Hey Buddy let's ip 192.168.2.1 and wait for the tone.";
                TestExtractor(input, ipv4Extractor, 15, "192.168.2.1");

                input = "Hey Buddy let's ip 255.255.1.1 and wait for the tone.";
                TestExtractor(input, ipv4Extractor, 15, "255.255.1.1");
            }
        }

        [TestMethod]
        public void UriExtractorSimpleTests()
        {
            for (int i = 0; i < 5; i++)
            {
                string input = "Hey Buddy let's url http://www.google.com and wait for the tone.";
                TestExtractor(input, uriExtractor, 20, "http://www.google.com");

                input = "Hey Buddy let's url https://www.yahoo.co.uk and wait for the tone.";
                TestExtractor(input, uriExtractor, 20, "https://www.yahoo.co.uk");
            }
        }

        [TestMethod]
        public void VisaExtractorSimpleTests()
        {
            for (int i = 0; i < 5; i++)
            {
                string input = "Hey Buddy let's 4580111122223333 and wait for the tone.";
                TestExtractor(input, visaExtractor, 10, "4580111122223333");

                input = "Hey Buddy let's pay 4580-1111-2222-3333 and wait for the tone.";
                TestExtractor(input, visaExtractor, 10, "4580-1111-2222-3333");
            }
        }
    }
}
