using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// Carrier Details—Routing Sequence/Transit Time
    /// TD5*B*02*SCAC*M~
    /// </summary>
    [EdiSegment(Path = "TD5")]
    public class TD5Segment
    {
        [EdiValue("X(1)", Order =0, Path = "TD5")]
        public string RoutingSequenceCode { get; set; }

        [EdiValue("X(2)", Order = 1, Path = "TD5")]
        public string IDCodeQualifier { get; set; }

        [EdiValue("X(4)", Order = 2, Path = "TD5")]
        public string IDCode { get; set; }

        [EdiValue("X(2)", Order = 3, Path = "TD5")]
        public string TransportationMethodMode { get; set; }
    }
}
