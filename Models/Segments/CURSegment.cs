using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    [EdiSegment(Path = "CUR")]
    public class CURSegment 
    {
        [EdiValue(Order = 0, Path = "CUR", Description ="")]
        public string EntityIdentifierCode { get; set; }

        [EdiValue(Order = 1, Path = "CUR", Description = "")]
        public string CurrencyCode { get; set; }
    }
}