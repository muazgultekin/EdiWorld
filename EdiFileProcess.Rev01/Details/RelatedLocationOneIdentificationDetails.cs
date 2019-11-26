using EdiFileProcess.Rev01.Attributes;

namespace EdiFileProcess.Rev01.Details {
    public class RelatedLocationOneIdentificationDetails {
        [EdiOrder(Order = 0)]
        public string RelatedLocationOneIdentification { get; set; }
        [EdiOrder(Order = 1)]
        public string CodeListQualifier { get; set; }
        [EdiOrder(Order = 2)]
        public string CodeListResponsibleAgencyCoded { get; set; }
        [EdiOrder(Order = 3)]
        public string RelatedPlaceLocationOne { get; set; }
    }
}