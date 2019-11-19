using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments
{
    [EdiSegment(Path = "PO4")]
    public class PO4Segment    
    {
        [EdiValue("X(50)", Order = 0)]
        public string Unknow1 { get; set; }

        [EdiValue("9(6)", Order = 1)]
        public decimal Unknow2 { get; set; }

        [EdiValue("X(50)", Order = 2)]
        public string Unknow3 { get; set; }
    }
}
