using EdiFileProcess.Attributes;
using EdiFileProcess.Models.SegmentGroups;
using EdiFileProcess.Models.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.Edi214
{
    public class ShipmentStatusMessage
    {
        [EdiSegment(Order = 0)]
        public STSegment ST { get; set; }

        [EdiSegment(Order = 1)]
        public B10Segment B10 { get; set; }
        
        [EdiSegment(Path = "L11", Order = 2, IsCollection = true)]
        public List<L11Segment> L11s { get; set; }

        [EdiSegment(Path = "N1", Order = 3, IsCollection = true)]
        public List<N1Date> N1Dates { get; set; }

        [EdiSegment(Path = "ST", Order = 3, IsCollection = true, SequenceEnd = "SE")]
        public List<AssignedNumber> AssignedNumbers { get; set; }
    }
}
