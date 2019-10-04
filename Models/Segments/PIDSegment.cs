using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    [EdiSegment(Path = "PID")]
    public class PIDSegment
    {
        [EdiValue("X(50)", Order = 0, Path = "PID", Description ="")]
        public string Unknow1 { get; set; }

        [EdiValue("X(50)", Order = 1, Path = "PID", Description = "")]
        public string Unknow2 { get; set; }

        [EdiValue("X(50)", Order = 2, Path = "PID", Description = "")]
        public string Unknow3 { get; set; }

        [EdiValue("X(50)", Order = 3, Path = "PID", Description = "")]
        public string Unknow4 { get; set; }

        [EdiValue("X(50)", Order = 4, Path = "PID", Description = "")]
        public string Destination { get; set; }
    }
}
