using EdiFileProcess.Attributes;
using EdiFileProcess.Enums;
using EdiFileProcess.Models.X12.Edi990;
using System.Collections.Generic;

namespace EdiFileProcess.Models.X12 {
    /// <summary>
    /// Response to a Load Tender
    /// </summary>
    [Edi(EdiType = EdiTypes.Edi990)]
    public class Edi990Model : EdiModelBase
    {               
        [EdiSegment(Path = "ST", Order = 2, IsCollection = true, SequenceEnd = "SE", IsWithSequenceEnd = true)]
        public List<ResponseToLoadTender> ResponseToLoadTenders { get; set; }        
    }
}