using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments
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