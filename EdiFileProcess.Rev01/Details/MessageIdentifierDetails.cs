using EdiFileProcess.Rev01.Attributes;

namespace EdiFileProcess.Rev01.Details {
    public class MessageIdentifierDetails {
        [EdiOrder(Order = 0)]
        public string MessageIdentifier { get; set; }

        [EdiOrder(Order = 1)]
        public string MessageType { get; set; }

        [EdiOrder(Order = 2)]
        public string MessageVersionNumber { get; set; }

        [EdiOrder(Order = 3)]
        public string MessageReleaseNumber { get; set; }

        [EdiOrder(Order = 4)]
        public string ControllingAgency { get; set; }
    }
}