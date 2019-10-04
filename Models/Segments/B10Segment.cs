using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments {
    [EdiSegment(Path = "B10")]
    public class B10Segment {
        [EdiValue("X(30)", Order = 0, Path = "B10", Description = "Carrier’s Pro Number")]
        public string ReferenceIdentification { get; set; }

        [EdiValue("X(30)", Order = 1, Path = "B10", Description = "Shipper’s Pro Number")]
        public string ShipmentIdentificationNumber { get; set; }

        [EdiValue("X(4)", Order = 2, Path = "B10", Description = "Standard Carrier Alpha Code")]
        public string StandardCarrierAlphaCode { get; set; }
    }
}