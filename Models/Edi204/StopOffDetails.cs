using EdiFileProcess.Attributes;
using EdiFileProcess.Models.SegmentGroups;
using EdiFileProcess.Models.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.Edi204
{
    public class StopOffDetail
    {
        [EdiSegment(Order = 0)]
        public S5Segment S5 { get; set; }

        [EdiSegment(Order = 1, IsCollection =true)]
        public List<L11Segment> L11s { get; set; }

        [EdiSegment(Order = 2, IsCollection = true)]
        public List<G62Segment> G62s { get; set; }

        [EdiSegment(Order = 3, IsCollection = true)]
        public List<NN> NNs { get; set; }

        [EdiSegment(Order = 4, IsCollection = true)]
        public List<OrderIdentificationDetail> OrderIdentificationDetails { get; set; }       
    }
}
