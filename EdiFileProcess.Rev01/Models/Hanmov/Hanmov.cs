using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Segments.EdiFact;
using System.Collections.Generic;

namespace EdiFileProcess.Rev01.Models.Hanmov {
    public class HanmovClass {
        [EdiSegment(Order = 0)]
        public UNHSegment UNH { get; set; }

        [EdiSegment(Order = 1)]
        public BGMSegment BGM { get; set; }

        [EdiSegment(Order = 2)]
        public List<DTMSegment> DTMs { get; set; }
    }
}