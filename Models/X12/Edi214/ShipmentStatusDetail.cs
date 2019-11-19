using EdiFileProcess.Attributes;
using EdiFileProcess.Models.X12.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.X12.Edi214
{
    public class ShipmentStatusDetail
    {
        [EdiSegment(Order = 0)]
        public AT7Segment AT7 { get; set; }

        [EdiSegment(Order = 1, IsCollection =true)]
        public List<L11Segment> L11s { get; set; }

        [EdiSegment(Order = 2, IsCollection = true)]
        public List<Q7Segment> Q7s { get; set; }

        [EdiSegment(Order = 3, IsCollection = true)]
        public List<AT8Segment> AT8s { get; set; }

        [EdiSegment(Order = 3, IsCollection = true)]
        public List<CartonPackage> CartonPackages { get; set; }
    }
}
