using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Details;

namespace EdiFileProcess.Rev01.Segments.EdiFact {
    [EdiSegment(Path = "UNH")]
    public class UNHSegment {
        [EdiOrder(Order = 0)]
        public string MessageReferenceNumber { get; set; }

        [EdiOrder(Order = 1, IsDetail = true)]
        public MessageIdentifierDetails MessageIdentifierDetail { get; set; }
    }
}