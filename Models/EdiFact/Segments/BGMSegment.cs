using EdiFileProcess.Attributes;
using EdiFileProcess.Models.EdiFact.Details;

namespace EdiFileProcess.Models.EdiFact.Segments {
    [EdiSegment(Path = "BGM")]
    public class BGMSegment {
        [EdiSegment(Order = 0)]
        [EdiOrder(Order = 0)]
        public DocumentMessageNameDetails DocumentMessageNameDetail { get; set; }

        [EdiSegment(Order = 1)]
        [EdiOrder(Order = 1)]
        public DocumentMessageIdentificationDetails DocumentMessageIdentificationDetail { get; set; }

        [EdiValue("X(20)", Order = 2)]
        [EdiOrder(Order = 2)]
        public string MessageFunctionCoded { get; set; }
    }    
}