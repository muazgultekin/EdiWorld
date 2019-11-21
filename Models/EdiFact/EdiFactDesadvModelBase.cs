using EdiFileProcess.Attributes;
using EdiFileProcess.Models.EdiFact.Segments;

namespace EdiFileProcess.Models.EdiFact {
    public abstract class EdiFactModelBase {
        [EdiSegment(Order = 0)]
        public UNBSegment UNB { get; set; }

        [EdiSegment(Order = 2)]
        public UNZSegment UNZ { get; set; }
    }
}
