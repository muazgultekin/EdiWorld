using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// Set Purpose 
    /// </summary>
    [EdiSegment(Path = "B2A")]
    public class B2ASegment
    {
        [EdiValue("X(2)", Order = 0, Path = "B2A", Description = "Set Purpose")]
        public string TransactionSetPurposeCode  { get; set; }
    }
}