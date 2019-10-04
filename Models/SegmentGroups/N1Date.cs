using EdiFileProcess.Attributes;
using EdiFileProcess.Models.Segments;


namespace EdiFileProcess.Models.SegmentGroups
{
    public class N1Date
    {
        [EdiSegment(Path = "N1", Order = 0)]
        public N1Segment N1 { get; set; }

        [EdiSegment(Path = "G62", Order = 1)]
        public G62Segment G62 { get; set; }
    }
}