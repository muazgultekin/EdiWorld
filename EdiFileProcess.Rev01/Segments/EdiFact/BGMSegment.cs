using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Details.BGM;

namespace EdiFileProcess.Rev01.Segments.EdiFact {
    [EdiSegment(Path = "BGM")]
    public class BGMSegment {
        [EdiOrder(Order = 0, IsDetail = true)]
        public DocumentMessageNameDetails DocumentMessageNameDetail { get; set; }
        [EdiOrder(Order = 1)]
        public string DocumentMessageNumber { get; set; }
        [EdiOrder(Order = 2)]
        public string MessageFunctionCoded { get; set; }
        [EdiOrder(Order = 3)]
        public string ResponseTypeCoded { get; set; }
    }

    [EdiSegment(Path = "UNT")]
    public class UNTSegment {
        [EdiOrder(Order = 0)]
        public string NumberOfSegmentsInAMessage { get; set; }

        [EdiOrder(Order = 1)]
        public string MessageReferenceNumber { get; set; }

    }
}