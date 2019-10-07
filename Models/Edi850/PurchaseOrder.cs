using EdiFileProcess.Attributes;
using EdiFileProcess.Models.SegmentGroups;
using EdiFileProcess.Models.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.Edi850
{
    public class PurchaseOrder
    {
        [EdiSegment(Order = 0)]
        public STSegment ST { get; set; }

        [EdiSegment(Order = 1)]
        public BEGSegment BEGT { get; set; }

        [EdiSegment(Order = 2, SequenceEnd = "PO1")]
        public REFSegment REF { get; set; }

        [EdiSegment(Order = 3)]
        public PERSegment PER { get; set; }

        [EdiSegment(Order = 4)]
        public FOBSegment FOB { get; set; }

        [EdiSegment(Order = 5, SequenceEnd = "PO1")]
        public DTMSegment DTM { get; set; }

        [EdiSegment(Order = 6)]
        public TD5Segment TD5 { get; set; }

        [EdiSegment(Path = "N1", Order = 7, IsCollection = true, SequenceEnd = "PO1", IsWithSequenceEnd = false)]
        public List<NN> NNs { get; set; }

        [EdiSegment(Path = "PO1", Order = 8, IsCollection = true, SequenceEnd = "CTT", IsWithSequenceEnd = false)]
        public List<Order> Orders { get; set; }

        [EdiSegment(Order = 9)]
        public CTTSegment CTT { get; set; }

        [EdiSegment(Order = 10)]
        public SESegment SE { get; set; }
    }
}