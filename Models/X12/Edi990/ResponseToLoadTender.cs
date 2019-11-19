using EdiFileProcess.Attributes;
using EdiFileProcess.Models.X12.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.X12.Edi990
{
    /// <summary>
    /// 
    /// </summary>
    public class ResponseToLoadTender
    {
        [EdiSegment(Order = 0)]
        public STSegment ST { get; set; }

        [EdiSegment(Order = 1)]
        public B1Segment B1 { get; set; }

        [EdiSegment(Order = 2, Path = "S5")]
        public N9Segment N9 { get; set; }

        [EdiSegment(Order = 3, Path = "S5")]
        public N7Segment N7 { get; set; }

        [EdiSegment(Path = "S5", Order = 4, IsCollection = true)]
        public List<StopOffDetail> StopOffDetails { get; set; }

        [EdiSegment(Order = 5)]
        public SESegment SE { get; set; }
    }
}