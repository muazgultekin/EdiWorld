using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments {
    [EdiSegment(Path = "AK3")]
    public class AK3Segment {
        [EdiValue("X(3)", Order = 0)]
        public string TransactionSetControlNumber { get; set; }
        [EdiValue("X(6)", Order = 1)]
        public string SegmentPositionInTransactionSet { get; set; }
        [EdiValue("X(6)", Order = 2)]
        public string LoopIdentifierCode { get; set; }
        [EdiValue("X(3)", Order = 3)]
        public string SegmentSyntaxErrorCode { get; set; }
    }
}