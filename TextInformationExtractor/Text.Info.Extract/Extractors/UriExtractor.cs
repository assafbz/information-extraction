using System;
using System.Text.RegularExpressions;

namespace Text.Info.Extract
{
    public class UriExtractor : BaseExtractor
    {
        private const string UriRegex = @"([a-z]+:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?";
        public UriExtractor()
            :base(UriRegex)
        {
        }

        protected override InfoTypes InfoType => InfoTypes.Url;

        protected override InfoSubTypes InfoSubType => InfoSubTypes.None;
    }
}
