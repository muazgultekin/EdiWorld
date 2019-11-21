using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFact.Details {
    public class PartyIdentificationDetails {

        [EdiValue("X(20)", Order = 0)]
        [EdiOrder(Order = 0)]
        public string PartyIdIdentification { get; set; }

        [EdiValue("X(20)", Order = 1)]
        [EdiOrder(Order = 1)]
        public string CodeListQualifie { get; set; }

        [EdiValue("X(20)", Order = 2)]
        [EdiOrder(Order = 2)]
        public string CodeListResponsibleAgencyCoded { get; set; }
    }
}