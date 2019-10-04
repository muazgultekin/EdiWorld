using EdiFileProcess.Attributes;
using EdiFileProcess.Models.Segments;
using System.Collections.Generic;


namespace EdiFileProcess.Models.SegmentGroups
{
    public class NN
    {
        [EdiSegment(Path = "N1", Order = 0)]
        public N1Segment N1 { get; set; }

        [EdiSegment(Path = "N2", Order = 1)]
        public N2Segment N2 { get; set; }

        [EdiSegment(Path = "N3", Order = 2, IsCollection = true)]
        public List<N3Segment> N3 { get; set; }

        [EdiSegment(Path = "N4", Order = 3)]
        public N4Segment N4 { get; set; }
    }
}