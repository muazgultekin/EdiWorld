using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFact.Segments {
    public class RFFSegment {
        [EdiValue("X(20)", Order = 0)]
        public string ReferenceQualifier { get; set; }

        [EdiValue("X(20)", Order = 1)]
        public string ReferenceNumber  { get; set; }

        [EdiValue("X(20)", Order = 2)]
        public int LineNumber  { get; set; }
    }
}