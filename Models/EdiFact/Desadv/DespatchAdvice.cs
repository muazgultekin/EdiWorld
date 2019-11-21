using EdiFileProcess.Attributes;
using EdiFileProcess.Models.EdiFact.Details;
using EdiFileProcess.Models.EdiFact.SegmentGroups;
using EdiFileProcess.Models.EdiFact.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.EdiFact.Desadv {
    public class DespatchAdvice {
        [EdiSegment(Order = 0)]
        public UNHSegment UNH { get; set; }

        [EdiSegment(Order = 1)]
        public BGMSegment BGM { get; set; }
        
        [EdiSegment(Path = "DTM", Order = 2, IsCollection = true)]
        public List<DateTimePeriodDetail> DTMs  { get; set; }

        [EdiSegment(Path = "NAD", Order = 3, IsCollection = true, SequenceEnd ="CPS")]
        public List<NADSegment> NADs { get; set; }

        [EdiSegment(Path = "CPS", Order = 4, IsCollection = true, SequenceEnd = "UNT")]
        public List<DetailTriggerSegment> CPSs { get; set; }

        [EdiSegment(Order = 5)]
        public UNTSegment UNT { get; set; }
    }
}
