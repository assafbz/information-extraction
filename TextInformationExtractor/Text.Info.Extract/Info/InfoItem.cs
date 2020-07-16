using System;
using System.Text.RegularExpressions;

namespace Text.Info.Extract
{
    public class InfoItem
    {
       public InfoTypes InfoType { get; set; }

       public InfoSubTypes InfoSubType { get; set; }

       public int Offset { get; set; }

       public string Value { get; set; }

       public InfoItem(
           InfoTypes infoType,
           InfoSubTypes infoSubType, 
           int offset, 
           string value)
       {
           this.InfoType = infoType;
           this.InfoSubType = infoSubType;
           this.Offset = offset;
           this.Value = value;
       }
    }
}
