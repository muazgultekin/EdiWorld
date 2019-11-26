using EdiFileProcess.Rev01.Attributes;

namespace EdiFileProcess.Rev01.Details {
    public class QuantityDetails {
        [EdiOrder(Order = 0)]
        public string QuantityQualifier { get; set; }
        [EdiOrder(Order = 1)]
        public string Quantity { get; set; }
        [EdiOrder(Order = 2)]
        public string MeasureUnitQualifier { get; set; }
    }
}
