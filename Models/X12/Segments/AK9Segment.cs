using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments {
    [EdiSegment(Path = "AK9")]
    public class AK9Segment {
        [EdiValue("X(1)", Order = 0)]
        public string TransactionSetAcknowledgmentCode { get; set; }
        [EdiValue("X(3)", Order = 1)]
        public string TransactionSetSyntaxErrorCode { get; set; }
        [EdiValue("X(50)", Order = 2)]
        public string NumberOfTransactionSetsIncluded { get; set; }
        [EdiValue("X(50)", Order = 3)]
        public string NumberOfReceivedTransactionSets { get; set; }
    }
}