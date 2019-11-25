using EdiFileProcess.Rev01.Attributes;

namespace EdiFileProcess.Rev01.Details {
    public class DocumentMessageIdentificationDetails {        
        [EdiOrder(Order = 0, MaxLength =20)]
        public string DocumentMessageNumber { get; set; }
    }
}