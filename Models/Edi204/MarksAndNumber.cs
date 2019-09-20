using EdiFileProcess.Attributes;
using EdiFileProcess.Models.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.Edi204
{
    public class MarksAndNumber
    {
        [EdiSegment(Order = 0)]
        public L5Segment L5 { get; set; }

        [EdiSegment(Order = 1)]
        public List<G61Segment> G61s { get; set; }
    }
}