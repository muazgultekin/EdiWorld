using EdiFileProcess.Attributes;
using EdiFileProcess.Models.X12.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.X12.Edi850
{
    public class Order
    {
        [EdiSegment(Path = "PO1", Order = 0)]
        public PO1Segment PO1 { get; set; }

        [EdiSegment(Path = "CUR", Order = 1)]
        public CURSegment CUR { get; set; }

        [EdiSegment(Path = "PID", Order = 2)]
        public PIDSegment PID { get; set; }

        [EdiSegment(Path = "PO4", Order = 7, IsCollection = true)]
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
