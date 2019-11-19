using EdiFileProcess.Attributes;
using EdiFileProcess.Models.X12.SegmentGroups;
using EdiFileProcess.Models.X12.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.X12.Edi210
{    
    public class MotorCarrierFreight
    {
        [EdiSegment(Order = 0)]
        public S5Segment S5 {get;set;}

        [EdiSegment(Order = 1)]
        public G62Segment G62 { get; set; }

        [EdiSegment(Order = 2)]
        public OIDSegment OID { get; set; }

        [EdiSegment(Order = 3, IsCollection =true)]
        public List<NN> NNs { get; set; }
    }
}
