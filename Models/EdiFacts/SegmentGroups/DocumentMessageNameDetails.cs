using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFacts.SegmentGroups {
    public class DocumentMessageNameDetails {
        [EdiValue("X(20)", Order = 0)]
        public string DocumentMessageNameCoded { get; set; }
    }
}
