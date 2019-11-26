using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Details;

namespace EdiFileProcess.Rev01.Segments.EdiFact {
    [EdiSegment(Path = "RFF")]
    public class RFFSegment {
        [EdiOrder(Order = 0, IsDetail = true)]
        public ReferenceDetail ReferenceDetails { get; set; }
    }
}