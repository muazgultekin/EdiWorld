using EdiFileProcess.Rev01.Attributes;

namespace EdiFileProcess.Rev01.Details {
    public class ReferenceDetail {
        [EdiOrder(Order = 0)]
        public string ReferenceQualifier { get; set; }
        [EdiOrder(Order = 1)]
        public string ReferenceNumber { get; set; }
        [EdiOrder(Order = 2)]
        public string LineNumber { get; set; }
        [EdiOrder(Order = 3)]
        public string ReferenceVversionNumber { get; set; }
    }
}