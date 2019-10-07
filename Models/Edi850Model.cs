using EdiFileProcess.Attributes;
using EdiFileProcess.Enums;
using EdiFileProcess.Models.Edi850;
using System.Collections.Generic;

namespace EdiFileProcess.Models
{
    [Edi(EdiType = EdiTypes.Edi850)]
    public class Edi850Model : EdiModelBase
    {
        [EdiSegment(Path = "ST", Order = 2, IsCollection = true, SequenceEnd = "SE", IsWithSequenceEnd = true)]
        public List<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
