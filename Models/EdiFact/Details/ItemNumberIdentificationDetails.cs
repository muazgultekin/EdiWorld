using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFact.Details {
    public class ItemNumberIdentificationDetails {
        [EdiValue("X(35)", Order = 0)]
        [EdiOrder(Order = 1)]
        public string ItemNumber { get; set; }

        [EdiValue("X(3)", Order = 1)]
        [EdiOrder(Order = 2)]
        public string ItemNumberTypeCoded { get; set; }
    }
}
