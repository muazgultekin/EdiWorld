using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Segments.EdiFact;
using System.Collections.Generic;

namespace EdiFileProcess.Rev01.Models.EdiFact.Hanmov.SegmentGroups {
    public class SegmentGroup07 {
        [EdiSegment(Order = 0)]
        public LINSegment LIN { get; set; }

        [EdiSegment(Order = 1)]
        public QTYSegment QTY { get; set; }

        [EdiSegment(Order = 2)]
        public List<SegmentGroup11> SegmentGroup11s { get; set; }
    }
}