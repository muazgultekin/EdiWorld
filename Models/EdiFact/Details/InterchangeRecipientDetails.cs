using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFact.Details {
    public class InterchangeRecipientDetails {
        [EdiValue("X(20)", Order = 0)]
        [EdiOrder(Order = 0)]
        public string RecipientIdentification { get; set; }

        [EdiValue("X(20)", Order = 1)]
        [EdiOrder(Order = 1)]
        public string IdentificationCodeQualifier { get; set; }
    }
}