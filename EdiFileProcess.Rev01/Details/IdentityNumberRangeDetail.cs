using EdiFileProcess.Rev01.Attributes;

namespace EdiFileProcess.Rev01.Details {
    public class IdentityNumberRangeDetails {
        [EdiOrder(Order = 0)]
        public string IdentityNumber01 { get; set; }
        [EdiOrder(Order = 1)]
        public string IdentityNumber02 { get; set; }
    }
}