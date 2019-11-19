using EdiFileProcess.Attributes;
using EdiFileProcess.Models.X12.Segments;

namespace EdiFileProcess.Models.X12.SegmentGroups
{
    public class N1Date
    {
        [EdiSegment(Path = "N1", Order = 0)]
        public N1Segment N1 { get; set; }

        [EdiSegment(Path = "G62", Order = 1)]
        public G62Segment G62 { get; set; }
    }
}
