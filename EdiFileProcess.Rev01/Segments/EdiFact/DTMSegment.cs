using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Details;

namespace EdiFileProcess.Rev01.Segments.EdiFact {
    [EdiSegment(Path = "DTM")]
    public class DTMSegment {
        [EdiOrder(Order = 0, IsDetail = true)]
        public DateTimePperiodDetails DateTimePperiodDetail { get; set; }
    }
}