using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments {
    [EdiSegment(Path = "AK5")]
    public class AK5Segment {
        [EdiValue("X(1)", Order = 0)]
        public string TransactionSetAcknowledgmentCode { get; set; }
        [EdiValue("X(3)", Order = 1)]
        public string TransactionSetSyntaxErrorCode { get; set; }
    }
}
