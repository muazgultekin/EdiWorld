using EdiFileProcess.Attributes;
using EdiFileProcess.Models.EdiFact.Details;
using EdiFileProcess.Models.EdiFact.Segments;

namespace EdiFileProcess.Models.EdiFact.SegmentGroups {
    public class DetailTriggerSegment {
        [EdiSegment(Path ="CPS", Order = 0)]
        public CPSSegment CPS { get; set; }

        [EdiSegment(Path = "PAC", Order = 1)]
        public PACSegment PAC { get; set; }

        [EdiSegment(Path = "PCI", Order = 2)]
        public PCISegment PCI { get; set; }
       
        [EdiSegment(Path = "LIN", Order = 3)]
        public LINSegment LIN { get; set; }

        [EdiSegment(Path = "PCI", Order = 4)]
        public PCISegment PCI2 { get; set; }

        [EdiSegment(Path = "QTY", Order = 5)]
        public QTYSegment QTY { get; set; }

        [EdiSegment(Path = "RFF", Order = 6)]
        public RFFSegment RFF { get; set; }

        [EdiSegment(Path = "GIN", Order = 7)]
        public GINSegment GIN { get; set; }


    }
}
