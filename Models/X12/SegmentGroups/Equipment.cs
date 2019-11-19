using EdiFileProcess.Attributes;
using EdiFileProcess.Models.X12.Segments;

namespace EdiFileProcess.Models.X12.SegmentGroups
{
    public class Equipment
    {
        [EdiSegment(Order = 0)]
        public N7Segment N7 { get; set; }
    }
}
