using EdiFileProcess.Attributes;
using EdiFileProcess.Enums;
using EdiFileProcess.Models.X12.Edi214;
using System.Collections.Generic;

namespace EdiFileProcess.Models.X12 {
    [Edi(EdiType = EdiTypes.Edi214)]
    public class Edi214Model : EdiModelBase {        
        [EdiSegment(Path = "ST", Order = 2, IsCollection = true, SequenceEnd = "SE")]
        public List<ShipmentStatusMessage> ShipmentStatusMessages { get; set; }      
    }
}
