using EdiFileProcess.Attributes;
using EdiFileProcess.Models.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.Edi210
{
    public class AssignedNumber
    {
        [EdiSegment(Order = 0)]
        public LXSegment LX { get; set; }

        [EdiSegment(Order = 1, IsCollection = true)]
        public List<L1Segment> L1s { get; set; }
    }
}
