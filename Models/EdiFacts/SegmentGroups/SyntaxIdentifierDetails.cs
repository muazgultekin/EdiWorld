using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFacts.SegmentGroups {
    public class SyntaxIdentifierDetails {
        [EdiValue("X(20)", Order = 0)]
        public string SyntaxIdentifier { get; set; }
        [EdiValue("X(20)", Order = 0)]
        public string SyntaxVersionNumber { get; set; }       
    }
}