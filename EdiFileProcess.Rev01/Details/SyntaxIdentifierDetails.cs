
using EdiFileProcess.Rev01.Attributes;

namespace EdiFileProcess.Rev01.Details {
    public class SyntaxIdentifierDetails {       
        [EdiOrder(Order = 0)]
        public string SyntaxIdentifier { get; set; }        
        [EdiOrder(Order = 1)]
        public string SyntaxVersionNumber { get; set; }
    }
}