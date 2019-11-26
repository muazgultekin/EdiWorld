using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Details;

namespace EdiFileProcess.Rev01.Segments.EdiFact {
    /// <summary>
    /// Goods identity number
    /// </summary>
    [EdiSegment(Path = "GIN")]
    public class GINSegment {
        [EdiOrder(Order = 0)]
        public string IdentityNumberQualifier { get; set; }
        [EdiOrder(Order = 1, IsDetail = true)]
        public IdentityNumberRangeDetails IdentityNumberRangeDetail { get; set; }
    }
}