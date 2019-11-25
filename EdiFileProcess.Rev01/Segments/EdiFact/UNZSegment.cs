using EdiFileProcess.Rev01.Attributes;

namespace EdiFileProcess.Rev01.Segments.EdiFact {
    /// <summary>
    /// INTERCHANGE TRAILER 
    /// </summary>
    [EdiSegment(Path = "UNZ")]
    public class UNZSegment {
        /// <summary>
        /// Number of messages in an interchange. 
        /// </summary>        
        [EdiOrder(Order = 0)]
        public int InterchangeControlCount { get; set; }

        /// <summary>
        /// Value must be the same as 0020-Interchange Control Reference in UNB.
        /// </summary>       
        [EdiOrder(Order = 1, MaxLength = 20)]
        public string InterchangeControlReference { get; set; }
    }
}