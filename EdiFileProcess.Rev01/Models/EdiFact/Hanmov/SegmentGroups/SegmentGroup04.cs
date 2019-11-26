using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Segments.EdiFact;

namespace EdiFileProcess.Rev01.Models.EdiFact.Hanmov.SegmentGroups {
    public class SegmentGroup04 {
        [EdiSegment(Order = 0)]
        public RFFSegment RFF { get; set; }
    }
}