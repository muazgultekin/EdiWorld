using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments {
    [EdiSegment(Path = "AK2")]
    public class AK2Segment {
        [EdiValue("X(3)", Order = 0)]
        public string TransactionSetIdentifierCode { get; set; }
        [EdiValue("X(9)", Order = 1)]
        public string TransactionSetControlNumber  { get; set; }
    }
}
