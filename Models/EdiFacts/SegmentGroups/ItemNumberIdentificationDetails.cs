using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFacts.SegmentGroups {
    public class ItemNumberIdentificationDetails {
        [EdiValue("X(35)", Order = 0)]
        public string ItemNumber { get; set; }
        [EdiValue("X(3)", Order = 0)]
        public string ItemNumberTypeCoded { get; set; }
    }
}
