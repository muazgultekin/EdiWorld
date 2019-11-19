using EdiFileProcess.Attributes;
using EdiFileProcess.Enums;
using EdiFileProcess.Models.X12.Edi210;
using System.Collections.Generic;

namespace EdiFileProcess.Models.X12 {
    [Edi(EdiType = EdiTypes.Edi210)]
    public class Edi210Model: EdiModelBase {      
        [EdiSegment(Path = "ST", Order = 2, IsCollection = true, SequenceEnd = "SE")]
        public List<MotorCarrierFreightInvoice> MotorCarrierFreightInvoices { get; set; }        
    }
}
