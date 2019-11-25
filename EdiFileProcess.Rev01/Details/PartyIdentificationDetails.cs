using EdiFileProcess.Rev01.Attributes;

namespace EdiFileProcess.Rev01.Details {
    public class PartyIdentificationDetails {        
        [EdiOrder(Order = 0)]
        public string PartyIdIdentification { get; set; }
       
        [EdiOrder(Order = 1)]
        public string CodeListQualifie { get; set; }

        [EdiOrder(Order = 2)]
        public string CodeListResponsibleAgencyCoded { get; set; }
    }
}