using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFact.Details {
    public class DocumentMessageIdentificationDetails {
        [EdiValue("X(20)", Order = 0)]
        [EdiOrder(Order = 0)]
        public string DocumentMessageNumber { get; set; }
    }
}
