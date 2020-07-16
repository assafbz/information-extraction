using System;
using System.Text.RegularExpressions;

namespace Text.Info.Extract
{
    public class EmailExtractor : BaseExtractor
    {
        private const string EmailRegex = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        public EmailExtractor()
            :base(EmailRegex)
        {
        }

        protected override InfoTypes InfoType => InfoTypes.Email;

        protected override InfoSubTypes InfoSubType => InfoSubTypes.None;
    }
}
