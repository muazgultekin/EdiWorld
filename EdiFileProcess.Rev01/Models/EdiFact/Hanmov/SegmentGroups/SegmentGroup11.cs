using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Segments.EdiFact;
using System.Collections.Generic;

namespace EdiFileProcess.Rev01.Models.EdiFact.Hanmov.SegmentGroups {
    public class SegmentGroup11 {
        [EdiSegment(Order = 0)]
        public PACSegment PAC { get; set; }

        [EdiSegment(Order = 1)]
        public QTYSegment QTY { get; set; }

        [EdiSegment(Order = 2)]
        public List<SegmentGroup12> SegmentGroup12s { get; set; }
    }
}