using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFact.Segments {
    [EdiSegment(Path = "UNT")]
    public class UNTSegment {
        /// <summary>
        /// Control count of the number of segments in the message, including UNH and UNT.       
        /// </summary>
        [EdiValue("X(20)", Order = 0)]
        [EdiOrder(Order = 0)]
        public string NumberOfSegmentsInTheMessage { get; set; }

        /// <summary>
        /// Number must be identical to UNH - tag 006
        /// </summary>
        [EdiValue("X(20)", Order = 1)]
        [EdiOrder(Order = 1)]
        public string MessageReferenceNumber { get; set; }
    }
}