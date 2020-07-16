using System;
using System.Text.RegularExpressions;

namespace Text.Info.Extract
{
    public class VisaExtractor : BaseExtractor
    {
        private const string VisaRegex = @"4[0-9]{3}([ -]?)([0-9]{4}\1){2}[0-9]{4}";

        public VisaExtractor()
            :base(VisaRegex)
        {
            
        }

        protected override InfoTypes InfoType => InfoTypes.CreditCard;

        protected override InfoSubTypes InfoSubType => InfoSubTypes.Visa;
    }
}
