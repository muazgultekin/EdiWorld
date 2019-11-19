using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments
{
    /// <summary>
    /// Interline Information 
    /// </summary>
    [EdiSegment(Path = "MS3")]
    public class MS3Segment
    {
        [EdiValue("X(4)", Order = 0, Description = "")]
        public string StandardCarrierAlphaCode  { get; set; }
        [EdiValue("X(2)", Order = 1, Description = "")]
        public string RoutingSequenceCode{ get; set; }
        [EdiValue("X(50)", Order = 2, Description = "")]
        public string Unknow3 { get; set; }
        [EdiValue("X(2)", Order = 3, Description = "")]
        public string TransportationMethodTypeCode { get; set; }
    }
}