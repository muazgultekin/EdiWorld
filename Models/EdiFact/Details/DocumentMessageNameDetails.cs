using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFact.Details {
    public class DocumentMessageNameDetails {
        [EdiValue("X(20)", Order = 0)]
        [EdiOrder(Order = 0)]
        public string DocumentMessageNameCoded { get; set; }
    }
}
