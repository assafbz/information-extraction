using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Text.Info.Extract
{
    public abstract class BaseExtractor : IExtractor
    {
        private readonly TimeSpan timeWaitForRegex = TimeSpan.FromMilliseconds(150);
        private readonly Regex regex;

        protected abstract InfoTypes InfoType { get; }

        protected abstract InfoSubTypes InfoSubType { get; }

        public BaseExtractor(string pattern)
        {
            regex = new Regex(pattern, RegexOptions.Compiled, timeWaitForRegex);
        }

        public IEnumerable<InfoItem> ExtractInfo(string input)
        {
            IList<InfoItem> infoItems = new List<InfoItem>();
            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                infoItems.Add(new InfoItem(InfoType, InfoSubType, match.Index, match.Value));
            }
            return infoItems;
        }
    }
}
