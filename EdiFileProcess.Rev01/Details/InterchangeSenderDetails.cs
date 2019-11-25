using EdiFileProcess.Rev01.Attributes;

namespace EdiFileProcess.Rev01.Details {
    public class InterchangeSenderDetails {
        [EdiOrder(Order = 0, MaxLength = 20)]
        public string SenderIdentification { get; set; }

        [EdiOrder(Order = 1, MaxLength = 20)]
        public string IdentificationCodeQualifier { get; set; }
    }
}
