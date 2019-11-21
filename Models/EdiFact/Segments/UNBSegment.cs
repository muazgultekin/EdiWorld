using EdiFileProcess.Attributes;
using EdiFileProcess.Models.EdiFact.Details;

namespace EdiFileProcess.Models.EdiFact.Segments {
    [EdiSegment(Path = "UNB")]
    public class UNBSegment {
        [EdiSegment(Order = 0)]
        [EdiOrder(Order =0)]
        public SyntaxIdentifierDetails SyntaxIdentifierDetail { get; set; }
        [EdiSegment(Order = 1)]
        [EdiOrder(Order = 1)]
        public InterchangeSenderDetails InterchangeSenderDetail { get; set; }
        [EdiSegment(Order = 2)]
        [EdiOrder(Order = 2)]
        public InterchangeRecipientDetails InterchangeRecipientDetail { get; set; }
        [EdiSegment(Order = 3)]
        [EdiOrder(Order = 3)]
        public DateTimeOfPreparationDetails DateTimeOfPreparationDetail { get; set; }
        [EdiValue(Order = 4)]
        [EdiOrder(Order = 4)]
        public string InterchangeControlReference { get; set; }
        [EdiValue(Order = 5)]
        [EdiOrder(Order = 5)]
        public string UnUsed01 { get; set; }
        [EdiValue(Order = 6)]
        [EdiOrder(Order = 6)]
        public string ApplicationReference { get; set; }
    }
}