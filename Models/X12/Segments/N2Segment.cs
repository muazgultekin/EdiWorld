using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments
{
    /// <summary>
    /// Additional Name Information 
    /// </summary>
    [EdiSegment(Path = "N1")]
    public class N2Segment
    {
        [EdiValue("X(60)", Order = 0, Description = "Free-form name")]
        public string Name { get; set; }
    }
}