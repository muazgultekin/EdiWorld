using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Segments.EdiFact;

namespace EdiFileProcess.Rev01.Models.EdiFact.Base {
    public abstract class EdiFactModelBase {
        [EdiSegment(Order = int.MinValue)]
        public UNBSegment UNB { get; set; }

        [EdiSegment(Order = int.MaxValue)]
        public UNZSegment UNZ { get; set; }
    }
}
