using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments
{
    [EdiSegment(Path = "PER")]
    public class PERSegment
    {
        [EdiValue("X(50)", Order = 0)]
        public string Unknow1 { get; set; }

        [EdiValue("X(50)", Order = 1)]
        public string Unknow2 { get; set; }
    }
}
