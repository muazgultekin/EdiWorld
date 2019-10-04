using EdiFileProcess.Attributes;
using System;

namespace EdiFileProcess.Models.Segments
{
    [EdiSegment(Path = "G62")]
    public class G62Segment
    {
        [EdiValue("X(2)", Order = 0, Path = "G62", Description ="")]
        public string DateQualifier { get; set; }

        [EdiValue("9(8)", Order = 1, Format = "yyyyMMdd", Path = "G62", Description = "Date of the interchange.")]
        public DateTime Date { get; set; }

        [EdiValue("X(2)", Order = 2, Path = "G62", Description ="")]
        public string TimeQualifier { get; set; } 

        [EdiValue("9(4)", Order = 3, Format = "HHmm", Path = "G62", Description = "Time of the interchange.")]
        public DateTime Time { get; set; }                
    }
}