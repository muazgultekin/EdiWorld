using EdiFileProcess.Attributes;
using System;

namespace EdiFileProcess.Models.Segments
{
    [EdiSegment(Path = "G62")]
    public class G62Segment
    {
        [EdiValue("X(2)", Order = 0)]
        public string DateQualifier { get; set; }

        [EdiValue("9(8)", Order = 1, Format = "yyyyMMdd", Description = "Date of the interchange.")]
        public DateTime Date { get; set; }

        [EdiValue("X(2)", Order = 2)]
        public string TimeQualifier { get; set; }

        [EdiValue("9(4)", Order = 3, Format = "HHmm", Description = "Time of the interchange.")]
        public DateTime Time { get; set; }                
    }
}