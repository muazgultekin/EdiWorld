using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFact.Segments {
    [EdiSegment(Path = "RFF")]
    public class RFFSegment {
        [EdiValue("X(20)", Order = 0)]
        [EdiOrder(Order = 0)]
        public string ReferenceQualifier { get; set; }

        [EdiValue("X(20)", Order = 1)]
        [EdiOrder(Order = 1)]
        public string ReferenceNumber  { get; set; }

        [EdiValue("X(20)", Order = 2)]
        [EdiOrder(Order = 2)]
        public int LineNumber  { get; set; }
    }
}