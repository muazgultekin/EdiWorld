using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Segments.EdiFact;
using System.Collections.Generic;

namespace EdiFileProcess.Rev01.Models.Hanmov.SegmentGroups {
    public class SegmentGroup03 {
        [EdiSegment(Order = 0)]
        public NADSegment NAD { get; set; }

        [EdiSegment(Order = 1)]
        public List<LOCSegment> LOCs { get; set; }

        [EdiSegment(Order = 2)]
        public List<SegmentGroup04> SegmentGroup04s { get; set; }
    }
}