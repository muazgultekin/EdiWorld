using EdiFileProcess.Rev01.Attributes;

namespace EdiFileProcess.Rev01.Details {
    public class RelatedLocationTwoIdentificationDetails {
        [EdiOrder(Order = 0)]
        public string RelatedLocationTwoIdentification { get; set; }
        [EdiOrder(Order = 1)]
        public string CodeListQualifier { get; set; }
        [EdiOrder(Order = 2)]
        public string CodeListResponsibleAgencyCoded { get; set; }
        [EdiOrder(Order = 3)]
        public string RelatedPlaceLocationTwo { get; set; }
    }
}