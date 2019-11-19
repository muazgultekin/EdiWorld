using EdiFileProcess.Attributes;
using EdiFileProcess.Models.EdiFacts.SegmentGroups;

namespace EdiFileProcess.Models.EdiFacts.Segments {
    [EdiSegment(Path = "UNB")]
    public class UNBSegment {
        [EdiSegment(Order = 0)]
        public SyntaxIdentifierDetails SyntaxIdentifierDetail { get; set; }
        [EdiSegment(Order = 1)]
        public InterchangeSenderDetails InterchangeSenderDetail { get; set; }
        [EdiSegment(Order = 2)]
        public InterchangeRecipientDetails InterchangeRecipientDetail { get; set; }
        [EdiSegment(Order = 3)]
        public DateTimeOfPreparationDetails DateTimeOfPreparationDetail { get; set; }
        [EdiValue(Order = 4)]
        public string InterchangeControlReference { get; set; }
        [EdiValue(Order = 5)]
        public string Unknow01 { get; set; }
        [EdiValue(Order = 6)]
        public string ApplicationReference { get; set; }
    }
}