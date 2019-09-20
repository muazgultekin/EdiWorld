using EdiFileProcess.Attributes;
using EdiFileProcess.Models.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.Edi214
{
    public class AssignedNumber
    {
        [EdiSegment(Order = 0)]
        public LXSegment LX { get; set; }

        [EdiSegment(Path = "AT7", Order = 1, IsCollection = true, SequenceEnd = "SE")]
        public List<ShipmentStatusDetail> ShipmentStatusDetails { get; set; }
    }
}
