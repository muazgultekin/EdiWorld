using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Details;

namespace EdiFileProcess.Rev01.Segments.EdiFact {
    /// <summary>
    /// Line item
    /// </summary>
    [EdiSegment(Path = "LIN")]
    public class LINSegment {
        [EdiOrder(Order = 0)]
        public string LineItemNumber { get; set; }

        [EdiOrder(Order = 1)]
        public string ActionRequestNotificationCoded { get; set; }

        [EdiOrder(Order = 2, IsDetail = true)]
        public ItemNumberIdentificationDetails ItemNumberIdentificationDetail { get; set; }
    }
}