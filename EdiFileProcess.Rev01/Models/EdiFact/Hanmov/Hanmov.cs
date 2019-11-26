using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Models.EdiFact.Hanmov.SegmentGroups;
using EdiFileProcess.Rev01.Segments.EdiFact;
using System.Collections.Generic;

namespace EdiFileProcess.Rev01.Models.EdiFact.Hanmov {
    public class HanmovClass {
        [EdiSegment(Order = 0)]
        public UNHSegment UNH { get; set; }

        [EdiSegment(Order = 1)]
        public BGMSegment BGM { get; set; }

        [EdiSegment(Order = 2)]
        public List<DTMSegment> DTMs { get; set; }

        [EdiSegment(Order = 3)]        
        public List<SegmentGroup02> SegmentGroup02s { get; set; }

        [EdiSegment(Order = 4)]
        public List<SegmentGroup03> SegmentGroup03s { get; set; }

        [EdiSegment(Order = 5)]
        public List<SegmentGroup07> SegmentGroup07s { get; set; }

        [EdiSegment(Order = 6)]
        public UNTSegment UNT { get; set; }
    }
}