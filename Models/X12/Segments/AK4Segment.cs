using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments {
    [EdiSegment(Path = "AK4")]
    public class AK4Segment {
        [EdiValue("X(50)", Order = 0)]
        public string PositionInSegment { get; set; }
        [EdiValue("X(2)", Order = 1)]
        public string ElementPositionInSegment { get; set; }
        [EdiValue("X(2)", Order = 2)]
        public string ComponentDataElementPositionInComposite { get; set; }
        [EdiValue("X(4)", Order = 3)]
        public string DataElementReferenceNumber { get; set; }
        [EdiValue("X(3)", Order = 4)]
        public string DataElementSyntaxErrorCode { get; set; }
        [EdiValue("X(99)", Order = 5)]
        public string CopyOfBadDataElement { get; set; }
    }
}