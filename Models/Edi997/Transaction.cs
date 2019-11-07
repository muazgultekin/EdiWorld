using EdiFileProcess.Attributes;
using EdiFileProcess.Models.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.Edi997 {
    public class Transaction {
        [EdiSegment(Order = 0)]
        public AK2Segment AK2 { get; set; }

        [EdiSegment(Path = "AK3", Order = 1, IsCollection = true)]
        public List<DataSegmentNote> DataSegmentNotes { get; set; }

        [EdiSegment(Order = 2)]
        public AK5Segment AK5 { get; set; }
    }
}
