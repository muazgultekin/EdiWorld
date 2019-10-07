using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    [EdiSegment(Path = "PID")]
    public class PIDSegment
    {
        [EdiValue("X(50)", Order = 0)]
        public string Unknow1 { get; set; }

        [EdiValue("X(50)", Order = 1)]
        public string Unknow2 { get; set; }

        [EdiValue("X(50)", Order = 2)]
        public string Unknow3 { get; set; }

        [EdiValue("X(50)", Order = 3)]
        public string Unknow4 { get; set; }

        [EdiValue("X(50)", Order = 4)]
        public string Destination { get; set; }
    }
}
