using EdiFileProcess.Attributes;
using EdiFileProcess.Models.EdiFact.Details;
using EdiFileProcess.Models.EdiFact.Segments;

namespace EdiFileProcess.Models.EdiFact.SegmentGroups {
    public class LineItem {
        [EdiSegment(Order = 0)]
        public LINSegment LIN { get; set; }

        [EdiSegment(Order = 1)]
        public QuantityDetails QTY { get; set; }

        [EdiSegment(Order = 2)]
        public RFFSegment RFF { get; set; }
    }
}