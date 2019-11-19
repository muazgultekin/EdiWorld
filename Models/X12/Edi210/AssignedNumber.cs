using EdiFileProcess.Attributes;
using EdiFileProcess.Models.X12.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.X12.Edi210
{
    public class AssignedNumber
    {
        [EdiSegment(Order = 0)]
        public LXSegment LX { get; set; }

        [EdiSegment(Order = 1, IsCollection = true)]
        public List<L1Segment> L1s { get; set; }
    }
}
