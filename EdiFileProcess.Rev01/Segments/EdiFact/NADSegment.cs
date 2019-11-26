using EdiFileProcess.Rev01.Attributes;

namespace EdiFileProcess.Rev01.Segments.EdiFact {
    [EdiSegment(Path = "NAD")]
    public class NADSegment {
        [EdiOrder(Order = 0)]
        public string PartyQualifier { get; set; }
    }        
}