using EdiFileProcess.Attributes;
using EdiFileProcess.Models.EdiFact.Details;

namespace EdiFileProcess.Models.EdiFact.Segments {
    [EdiSegment(Path = "LIN")]
    public class LINSegment {
        [EdiValue("X(20)", Order = 0)]
        [EdiOrder(Order = 0)]
        public string LineItemNumber { get; set; }

        [EdiValue("X(20)", Order = 1)]
        [EdiOrder(Order = 1)]
        public string UnKnow01 { get; set; }

        [EdiSegment(Order = 2)]
        [EdiOrder(Order = 2)]
        public ItemNumberIdentificationDetails ItemNumberIdentification { get; set; }
    }
    
}