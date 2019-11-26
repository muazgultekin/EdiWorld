using EdiFileProcess.Rev01.Attributes;

namespace EdiFileProcess.Rev01.Segments.EdiFact {
    /// <summary>
    /// Package identification
    /// </summary>
    [EdiSegment(Path = "PCI")]
    public class PCISegment {
        [EdiOrder(Order = 0)]
        public string MarkingInstructionsCoded { get; set; }
    }
}