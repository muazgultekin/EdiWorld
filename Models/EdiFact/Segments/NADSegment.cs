using EdiFileProcess.Attributes;
using EdiFileProcess.Models.EdiFact.Details;

namespace EdiFileProcess.Models.EdiFact.Segments {
    /// <summary>
    /// NAME OF ADDRESS
    /// </summary>
    [EdiSegment(Path = "NAD")]
    public class NADSegment {
        [EdiValue("X(2)", Order = 0)]
        public string PartyQualifier { get; set; }
        [EdiSegment(Order = 1)]
        public PartyIdentificationDetails PartyIdentificationDetail { get; set; }
    }
}