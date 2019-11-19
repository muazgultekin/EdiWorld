using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments
{
    /// <summary>
    /// Transaction Totals
    /// </summary>
    [EdiSegment(Path = "CTT")]
    public class CTTSegment
    {
        /// <summary>
        /// Transaction Totals
        /// </summary>
        [EdiValue("X(6)", Order = 0, Description = "")]
        public string NumberOfLineItems { get; set; }
    }
}
