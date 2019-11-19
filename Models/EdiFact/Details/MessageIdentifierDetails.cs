using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFact.Details {
    public class MessageIdentifierDetails {
        [EdiValue("X(6)", Order = 0)]
        public string MessageType  { get; set; }

        [EdiValue("X(3)", Order = 1)]
        public string MessageVersionNumber { get; set; }

        [EdiValue("X(3)", Order = 2)]
        public string MessageReleaseNumber { get; set; }

        [EdiValue("X(2)", Order = 3)]
        public string ControllingAgency { get; set; }
    }
}
