using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// Description, Marks and Numbers 
    /// </summary>
    [EdiSegment(Path = "L5")]
    public class L5Segment
    {
        [EdiValue("X(50)", Order = 0, Path = "L5", Description = "")]
        public string Unknow1 { get; set; }

        [EdiValue("X(50)", Order = 1, Path = "L5", Description = "")]
        public string LadingDescription  { get; set; }

        [EdiValue("X(50)", Order = 2, Path = "L5", Description = "")]
        public string Unknow3 { get; set; }

        [EdiValue("X(50)", Order = 3, Path = "L5", Description = "")]
        public string Unknow4 { get; set; }

        [EdiValue("X(50)", Order = 4, Path = "L5", Description = "")]
        public string Unknow5 { get; set; }

        [EdiValue("X(50)", Order = 5, Path = "L5", Description = "")]
        public string Unknow6 { get; set; }

        [EdiValue("X(50)", Order = 6, Path = "L5", Description = "")]
        public string Unknow7 { get; set; }

        [EdiValue("X(50)", Order = 7, Path = "L5", Description = "")]
        public string Unknow8 { get; set; }

        [EdiValue("X(50)", Order = 8, Path = "L5", Description = "")]
        public string Unknow9 { get; set; }
    }
}