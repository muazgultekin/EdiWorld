using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Details;

namespace EdiFileProcess.Rev01.Segments.EdiFact {
    [EdiSegment(Path = "UNB")]
    public class UNBSegment {
        [EdiOrder(Order = 0, IsDetail = true)]
        public SyntaxIdentifierDetails SyntaxIdentifierDetail { get; set; }

        [EdiOrder(Order = 1, IsDetail = true)]
        public InterchangeSenderDetails InterchangeSenderDetail { get; set; }

        [EdiOrder(Order = 2, IsDetail = true)]
        public InterchangeRecipientDetails InterchangeRecipientDetail { get; set; }

        [EdiOrder(Order = 3, IsDetail = true)]
        public DateTimeOfPreparationDetails DateTimeOfPreparationDetail { get; set; }

        [EdiOrder(Order = 4)]
        public string InterchangeControlReference { get; set; }

        [EdiOrder(Order = 5)]
        public string UnUsed01 { get; set; }

        [EdiOrder(Order = 6)]
        public string ApplicationReference { get; set; }
    }
}
