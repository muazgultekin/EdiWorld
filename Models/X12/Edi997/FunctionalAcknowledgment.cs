using EdiFileProcess.Attributes;
using EdiFileProcess.Models.X12.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.X12.Edi997 {
    public class FunctionalAcknowledgment {
        [EdiSegment(Order = 0)]
        public AK1Segment AK1 { get; set; }

        [EdiSegment(Path = "AK2", Order = 1, IsCollection = true)]
        public List<Transaction> Transactions { get; set; }

        [EdiSegment(Order = 2)]
        public AK9Segment AK9 { get; set; }

    }
}
