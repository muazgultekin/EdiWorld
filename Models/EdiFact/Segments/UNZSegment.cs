using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFact.Segments {
    /// <summary>
    /// INTERCHANGE TRAILER 
    /// </summary>
    [EdiSegment(Path = "UNZ")]
    public class UNZSegment {
        /// <summary>
        /// Number of messages in an interchange. 
        /// </summary>
        [EdiValue("9(2)", Order = 0)]
        public int InterchangeControlCount { get; set; }

        /// <summary>
        /// Value must be the same as 0020-Interchange Control Reference in UNB.
        /// </summary>
        [EdiValue("X(20)", Order = 1)]
        public string InterchangeControlReference { get; set; }
    }
}