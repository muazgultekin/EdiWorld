using EdiFileProcess.Attributes;
using EdiFileProcess.Models.X12.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.X12.Edi214
{
    public class AssignedNumber
    {
        [EdiSegment(Order = 0)]
        public LXSegment LX { get; set; }

        [EdiSegment(Path = "AT7", Order = 1, IsCollection = true, SequenceEnd = "SE")]
        public List<ShipmentStatusDetail> ShipmentStatusDetails { get; set; }
    }
}
