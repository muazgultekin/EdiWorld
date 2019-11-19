using EdiFileProcess.Attributes;
using EdiFileProcess.Models.X12.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.X12.Edi850
{
    public class OrderDetail
    {
        [EdiSegment(Path = "PO4", Order = 0)]
        public PO4Segment PO4 { get; set; }

        [EdiSegment(Path = "REF", Order = 1, IsCollection = true)]
        public List<REFSegment> REFs { get; set; }

        [EdiSegment(Path = "DTM", Order = 2, IsCollection = true)]
        public List<DTMSegment> DTMs { get; set; }
    }
}
