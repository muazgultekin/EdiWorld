using EdiFileProcess.Rev01.Attributes;

namespace EdiFileProcess.Rev01.Details {
    public class ItemNumberIdentificationDetails {
        [EdiOrder(Order = 1, MaxLength = 35)]
        public string ItemNumber { get; set; }

        [EdiOrder(Order = 2, MaxLength = 3)]
        public string ItemNumberTypeCoded { get; set; }
    }
}