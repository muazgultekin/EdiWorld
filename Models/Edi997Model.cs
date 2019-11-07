using EdiFileProcess.Attributes;
using EdiFileProcess.Enums;
using EdiFileProcess.Models.Edi997;
using System.Collections.Generic;

namespace EdiFileProcess.Models {    
    [Edi(EdiType = EdiTypes.Edi997)]
    public class Edi997Model : EdiModelBase {
        [EdiSegment(Path = "ST", Order = 2, IsCollection = true, SequenceEnd = "SE", IsWithSequenceEnd = true)]
        public List<FunctionalAcknowledgment> FunctionalAcknowledgments { get; set; }
    }
}