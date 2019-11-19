using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments
{
    /// <summary>
    /// Transaction Set Trailer
    /// </summary>
    [EdiSegment(Path = "SE")]
    public class SESegment
    {
        [EdiValue("X(10)", Order = 0, Description = "Total number of segments included in a transaction set including ST and SE segments.")]
        public string NumberOfIncludedSegments { get; set; }

        [EdiValue("9(9)", Order = 1, Description = "Identifying control number that must be unique within the transaction set functional group assigned by the originator for a transaction set.")]
        public int NumberTransactionSetControlNumber { get; set; }
    }
}