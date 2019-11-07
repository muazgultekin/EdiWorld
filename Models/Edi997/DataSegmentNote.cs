using EdiFileProcess.Attributes;
using EdiFileProcess.Models.Segments;

namespace EdiFileProcess.Models.Edi997 {
    public class DataSegmentNote {
        [EdiSegment(Order = 0)]
        public AK3Segment AK3 { get; set; }

        [EdiSegment(Order = 0)]
        public AK4Segment AK4 { get; set; }
    }
}