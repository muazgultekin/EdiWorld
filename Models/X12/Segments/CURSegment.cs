using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments
{
    [EdiSegment(Path = "CUR")]
    public class CURSegment
    {
        [EdiValue(Order = 0)]
        public string EntityIdentifierCode { get; set; }

        [EdiValue(Order = 1)]
        public string CurrencyCode { get; set; }
    }
}