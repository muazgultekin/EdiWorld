using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFact.Details {
    public class QuantityDetails {
        [EdiValue(Order = 0)]
        public string QuantityQualifier { get; set; }

        [EdiValue(Order = 1)]
        public decimal Quantity { get; set; }

        [EdiValue(Order = 2)]
        public string MeasureUnitQualifier { get; set; }
    }
}
