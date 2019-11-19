using EdiFileProcess.Attributes;
using EdiFileProcess.Models.X12.Segments;

namespace EdiFileProcess.Models.X12.Edi990
{
    public class StopOffDetail
    {
        [EdiSegment(Order = 0)]
        public S5Segment S5 { get; set; }

        [EdiSegment(Order = 1, IsCollection =true)]
        public N9Segment N9 { get; set; }
    }
}
