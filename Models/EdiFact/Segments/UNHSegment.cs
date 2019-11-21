using EdiFileProcess.Attributes;
using EdiFileProcess.Models.EdiFact.Details;

namespace EdiFileProcess.Models.EdiFact.Segments {
    [EdiSegment(Path = "UNH")]
    public class UNHSegment {
        [EdiValue("X(20)", Order = 0)]
        [EdiOrder(Order = 0)]
        public string MessageReferenceNumber { get; set; }

        [EdiSegment(Order = 1)]
        [EdiOrder(Order = 1)]
        public MessageIdentifierDetails MessageIdentifierDetail { get; set; }
    }
}
