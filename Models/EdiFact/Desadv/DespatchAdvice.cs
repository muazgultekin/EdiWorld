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

        [EdiSegment(Order = 2)]
        public List<DateTimePeriodDetail> DTMs  { get; set; }

        [EdiSegment(Order = 3)]
        public List<NADSegment> NADs { get; set; }

        [EdiSegment(Order = 4)]
        public List<DetailTriggerSegment> CPSs { get; set; }
    }
}
