using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Details;

namespace EdiFileProcess.Rev01.Segments.EdiFact {
    [EdiSegment(Path = "QTY")]
    public class QTYSegment {
        [EdiOrder(Order = 0, IsDetail = true)]
        public QuantityDetails QuantityDetail { get; set; }
    }
}