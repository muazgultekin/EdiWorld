using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments
{
    [EdiSegment(Path ="N3")]
    public class N3Segment
    {
        [EdiValue("X(200)", Order = 0)]
        public string AddressInformation { get; set; }
    }
}