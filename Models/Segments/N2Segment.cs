using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// Additional Name Information 
    /// </summary>
    [EdiSegment(Path = "N2")]
    public class N2Segment
    {
        [EdiValue("X(60)", Order = 0, Path = "N2", Description = "Free-form name")]
        public string Name { get; set; }
    }
}