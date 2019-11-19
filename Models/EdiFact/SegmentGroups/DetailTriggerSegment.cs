using EdiFileProcess.Attributes;
using EdiFileProcess.Models.EdiFact.Segments;

namespace EdiFileProcess.Models.EdiFact.SegmentGroups {
    public class DetailTriggerSegment {
        [EdiSegment(Order = 0)]
        public CPSSegment CPS { get; set; }

        [EdiSegment(Order = 1)]
        public PACSegment PAC { get; set; }

        [EdiSegment(Order = 2)]
        public LineItem LIN { get; set; }
    }
}
