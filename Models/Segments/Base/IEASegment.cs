using EdiFileProcess.Attributes;

namespace Edi850Model.Models.Segments.Base
{
    /// <summary>
    /// Interchange Control Trailer
    /// </summary>
    [EdiSegment(Path = "IEA")]
    public class IEASegment
    {
        [EdiValue("X(5)", Order = 0, Description = "A count of the number of functional groups included in an interchange.")]
        public string NumberOfIncludedFunctionalGroups { get; set; }

        [EdiValue("9(9)", Order = 1, Description = "A control number assigned by the interchange sender.")]
        public int QuantityInterchangeControlNumber { get; set; }
    }
}
