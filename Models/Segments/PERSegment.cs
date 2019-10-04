using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    [EdiSegment(Path = "PER")]
    public class PERSegment
    {
        [EdiValue("X(50)", Order = 0, Path = "PER", Description ="")]
        public string Unknow1 { get; set; }

        [EdiValue("X(50)", Order = 1, Path = "PER", Description = "")]
        public string Unknow2 { get; set; }
    }
}
