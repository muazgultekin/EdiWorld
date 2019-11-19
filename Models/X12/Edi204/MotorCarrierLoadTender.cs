using EdiFileProcess.Attributes;
using EdiFileProcess.Models.X12.SegmentGroups;
using EdiFileProcess.Models.X12.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.X12.Edi204
{
    public class MotorCarrierLoadTender
    {
        [EdiSegment(Order = 0)]
        public STSegment ST { get; set; }

        [EdiSegment(Order = 1)]
        public B2Segment B2 { get; set; }

        [EdiSegment(Order = 2)]
        public B2ASegment B2A { get; set; }

        [EdiSegment(Order = 3)]
        public MS3Segment MS3 { get; set; }

        [EdiSegment(Order = 4, IsCollection =true)]
        public List<NN> NNs { get; set; }

        [EdiSegment(Order = 5, IsCollection = true)]
        public List<Equipment> Equipments { get; set; }

        [EdiSegment(Order = 6, IsCollection = true)]
        public List<StopOffDetail> StopOffDetails { get; set; }        
    }
}
