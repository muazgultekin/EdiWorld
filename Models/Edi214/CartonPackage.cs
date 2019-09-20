using EdiFileProcess.Attributes;
using EdiFileProcess.Models.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.Edi214
{
    public class CartonPackage
    {
        [EdiSegment(Order = 0)]
        public CD3Segment CD3 { get; set; }

        [EdiSegment(Order = 1, IsCollection = true)]
        public List<L11Segment> L11s { get; set; }
    }
}
