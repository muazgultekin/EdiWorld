using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFact.Segments {
    [EdiSegment(Path = "GIN")]
    public class GINSegment {
        [EdiValue("X(20)", Order = 0)]
        [EdiOrder(Order = 0)]
        public string UnKnow01 { get; set; }

        [EdiValue("X(20)", Order = 1)]
        [EdiOrder(Order = 1)]
        public string UnKnow02 { get; set; }
    }    
}
