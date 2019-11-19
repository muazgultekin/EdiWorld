using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFacts.SegmentGroups {
    public class DocumentMessageIdentificationDetails {
        [EdiValue("X(20)", Order = 0)]
        public string DocumentMessageNumber { get; set; }
    }
}
