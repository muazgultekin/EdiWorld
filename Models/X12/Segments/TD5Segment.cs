using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments
{
    /// <summary>
    /// Carrier Details—Routing Sequence/Transit Time
    /// TD5*B*02*SCAC*M~
    /// </summary>
    [EdiSegment(Path = "TD5")]
    public class TD5Segment
    {
        [EdiValue("X(1)", Order =0)]
        public string RoutingSequenceCode { get; set; }

        [EdiValue("X(2)", Order = 1)]
        public string IDCodeQualifier { get; set; }

        [EdiValue("X(4)", Order = 2)]
        public string IDCode { get; set; }

        [EdiValue("X(2)", Order = 3)]
        public string TransportationMethodMode { get; set; }
    }
}
