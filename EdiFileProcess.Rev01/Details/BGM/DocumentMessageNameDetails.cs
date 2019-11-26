using EdiFileProcess.Rev01.Attributes;

namespace EdiFileProcess.Rev01.Details.BGM {
    public class DocumentMessageNameDetails {
        [EdiOrder(Order = 0)]
        public string DocumentMessageNameC002 { get; set; }
        [EdiOrder(Order = 1)]
        public string DocumentMessageNameCoded { get; set; }
        [EdiOrder(Order = 3)]
        public string CodeListQualifier { get; set; }
        [EdiOrder(Order = 4)]
        public string CodeListResponsibleAgencyCoded { get; set; }
        [EdiOrder(Order = 5)]
        public string DocumentMessageName1000 { get; set; }
    }
}