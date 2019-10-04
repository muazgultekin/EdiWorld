using EdiFileProcess.Attributes;
using EdiFileProcess.Models.Segments;

namespace EdiFileProcess.Models {
    public class EdiModelBase {
        [EdiSegment(Order = 0)]
        public ISASegment ISA { get; set; }

        [EdiSegment(Order = 1)]
        public GSSegment GS { get; set; }

        [EdiSegment(Order = 3)]
        public GESegment GE { get; set; }

        [EdiSegment(Order = 4)]
        public IEASegment IEA { get; set; }
    }
}
