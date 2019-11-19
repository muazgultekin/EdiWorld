using EdiFileProcess.Attributes;
using EdiFileProcess.Models.X12.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.X12.Edi204 {
    public class MarksAndNumber
    {
        [EdiSegment(Order = 0)]
        public L5Segment L5 { get; set; }

        [EdiSegment(Order = 1)]
        public List<G61Segment> G61s { get; set; }
    }
}