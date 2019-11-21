using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFact.Segments {
    [EdiSegment(Path = "PCI")]
    public class PCISegment {
        [EdiValue("X(20)", Order = 0)]
        [EdiOrder(Order = 0)]
        public string UnKnow01 { get; set; }
    }
}
