using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    [EdiSegment(Path ="N3")]
    public class N3Segment
    {
        [EdiValue("X(200)", Order = 0, Path = "N3", Description = "")]
        public string AddressInformation { get; set; }
    }
}