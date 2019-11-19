using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFact.Details {
    public class InterchangeSenderDetails {
        [EdiValue("X(20)", Order = 0)]
        public string SenderIdentification { get; set; }

        [EdiValue("X(20)", Order = 1)]
        public string IdentificationCodeQualifier { get; set; }
    }
}
