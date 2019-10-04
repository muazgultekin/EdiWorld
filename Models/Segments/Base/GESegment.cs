using EdiFileProcess.Attributes;

namespace Edi850Model.Models.Segments.Base
{
    /// <summary>
    /// Functional Group Trailer
    /// </summary>
    [EdiSegment(Path = "GE")]
    public class GESegment
    {
        [EdiValue("X(6)", Order = 0, Description = "Total number of transaction sets included in the functional group or interchange (transmission) group terminated by the trailer containing this data element.")]
        public string NumberOfTransactionsSetsIncluded { get; set; }

        [EdiValue("X(9)", Order = 1, Description = "Assigned number originated and maintained by the sender.")]
        public string NumberGroupControlNumber { get; set; }
    }
}