using EdiFileProcess.Models.EdiFacts.SegmentGroups;

namespace EdiFileProcess.Models.EdiFacts.Segments {
    public class LINSegment {
        public string LineItemNumber { get; set; }
        public string UnKnow01 { get; set; }
        public ItemNumberIdentificationDetails ItemNumberIdentification { get; set; }
    }
}