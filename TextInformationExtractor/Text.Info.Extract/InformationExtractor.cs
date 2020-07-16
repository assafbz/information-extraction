using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Text.Info.Extract
{
    public class InformationExtractor : IExtractor
    {
        private IEnumerable<IExtractor> extractors;
        private ConcurrentBag<InfoItem> results;

        public InformationExtractor()
        {
            extractors = new List<IExtractor>() 
            {
                new VisaExtractor(),
                //new EmailExtractor(),
                //new PhoneExtractor(),
                new IPv4Extractor(),
                new UriExtractor()
            };
        }

        public IEnumerable<InfoItem> ExtractInfo(string input)
        {
            results = new ConcurrentBag<InfoItem>();
            Parallel.ForEach(extractors, (extractor) => 
            {
                IEnumerable<InfoItem> infoItems = extractor.ExtractInfo(input);
                foreach (InfoItem item in infoItems)
                {
                    results.Add(item);
                }
            });
            return results.ToArray();
        }
    }
}
