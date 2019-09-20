using EdiFileProcess.Attributes;
using EdiFileProcess.Models.Segments;

namespace EdiFileProcess.Models.Edi210
{
    public class Equipment
    {
        [EdiSegment(Order = 0)]
        public N7Segment N7 { get; set; }
    }
}
