using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments {
    [EdiSegment(Path = "AK1")]
    public class AK1Segment {
        [EdiValue("X(2)", Order = 0)]
        public string FunctionalIdentifierCode { get; set; }
        [EdiValue("X(9)", Order = 1)]
        public string GroupControlNumber { get; set; }
    }    
}