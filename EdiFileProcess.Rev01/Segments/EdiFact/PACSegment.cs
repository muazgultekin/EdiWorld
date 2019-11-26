using EdiFileProcess.Rev01.Attributes;

namespace EdiFileProcess.Rev01.Segments.EdiFact {
    [EdiSegment(Path = "PAC")]
    public class PACSegment {
        [EdiOrder(Order = 0)]
        public string NumberOfPackages { get; set; }
    }    
}