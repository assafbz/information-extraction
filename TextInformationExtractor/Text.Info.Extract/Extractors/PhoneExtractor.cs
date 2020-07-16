using System;
using System.Text.RegularExpressions;

namespace Text.Info.Extract
{
    public class PhoneExtractor : BaseExtractor
    {
        private const string PhoneRegex = @"\(?([0-9]{3})\)?([ .-]?)[0-9]{3}\2?[0-9]{4}";
        public PhoneExtractor()
            :base(PhoneRegex)
        {
        }

        protected override InfoTypes InfoType => InfoTypes.Phone;

        protected override InfoSubTypes InfoSubType => InfoSubTypes.International;
    }
}
