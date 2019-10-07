using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// Business Instructions and Reference Number
    /// </summary>
    [EdiSegment(Path = "L11")]
    public class L11Segment
    {
        [EdiValue("X(30)", Order = 0, Description = "This element is used to specify the data needed to uniquely identify the shipment.")]
        public string ReferenceIdentification { get; set; }

        [EdiValue("X(3)", Order = 1, Description = "2I Tracking Numbe - CR Customer Reference Number ")]
        public string ReferenceIdentificationQualifier  { get; set; }
    }
}