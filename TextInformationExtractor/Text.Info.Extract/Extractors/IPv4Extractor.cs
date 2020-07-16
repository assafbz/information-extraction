using System;
using System.Text.RegularExpressions;

namespace Text.Info.Extract
{
    public class IPv4Extractor : BaseExtractor
    {
        private const string IPv4Regex = @"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";

        public IPv4Extractor()
            :base(IPv4Regex)
        {
            
        }

        protected override InfoTypes InfoType => InfoTypes.IP;

        protected override InfoSubTypes InfoSubType => InfoSubTypes.IPv4;
    }
}
