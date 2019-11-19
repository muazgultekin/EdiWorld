using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFact.Segments {
    [EdiSegment(Path = "UNT")]
    public class UNTSegment {
        /// <summary>
        /// Control count of the number of segments in the message, including UNH and UNT.       
        /// </summary>
        [EdiValue("9(2)", Order = 0)]
        public int NumberOfSegmentsInTheMessage { get; set; }

        /// <summary>
        /// Number must be identical to UNH - tag 006
        /// </summary>
        [EdiValue("9(2)", Order = 1)]
        public int MessageReferenceNumber { get; set; }
    }
}