using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Text.Info.Extract
{
    public interface IExtractor
    {
        IEnumerable<InfoItem> ExtractInfo(string input);
    }
}