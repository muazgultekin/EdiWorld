using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Segments.EdiFact;

namespace EdiFileProcess.Rev01.Models.Hanmov.SegmentGroups {
    public class SegmentGroup12 {
        [EdiSegment(Order = 0)]
        public PCISegment PCI { get; set; }

        [EdiSegment(Order = 1)]
        public GINSegment GIN { get; set; }
    }
}