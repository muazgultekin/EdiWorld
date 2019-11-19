using EdiFileProcess.Attributes;
using EdiFileProcess.Models.EdiFacts.SegmentGroups;

namespace EdiFileProcess.Models.EdiFacts.Segments {
    [EdiSegment(Path = "UNH")]
    public class UNHSegment {
        [EdiValue("X(20)", Order = 0)]
        public string MessageReferenceNumber { get; set; }
        [EdiSegment(Order = 1)]
        public MessageIdentifierDetails MessageIdentifierDetail { get; set; }
    }
}
