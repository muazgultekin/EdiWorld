using EdiFileProcess.Attributes;
using EdiFileProcess.Enums;
using EdiFileProcess.Models.X12.Edi204;
using System.Collections.Generic;

namespace EdiFileProcess.Models.X12 {
    [Edi(EdiType = EdiTypes.Edi204)]
    public class Edi204Model: EdiModelBase {        
        [EdiSegment(Path = "ST", Order = 2, IsCollection = true, SequenceEnd = "SE")]
        public List<MotorCarrierLoadTender> MotorCarrierLoadTenders { get; set; }        
    }
}
