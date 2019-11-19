using EdiFileProcess.Attributes;
using EdiFileProcess.Models.EdiFact.Details;

namespace EdiFileProcess.Models.EdiFact.Segments {
    [EdiSegment(Path = "BGM")]
    public class BGMSegment {

        [EdiValue(Order = 0)]
        public DocumentMessageNameDetails DocumentMessageNameDetail { get; set; }

        [EdiValue(Order = 1)]
        public DocumentMessageIdentificationDetails DocumentMessageIdentificationDetail { get; set; }

        [EdiValue("X(20)", Order = 2)]
        public string MessageFunctionCoded { get; set; }
    }
}