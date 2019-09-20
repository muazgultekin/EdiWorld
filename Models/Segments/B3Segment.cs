using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// Beginning Segment for Carrier's Invoice 
    /// </summary>
    [EdiSegment(Path = "B3")]
    public class B3Segment
    {
        [EdiValue("X(50)", Order = 0, Description = "")]
        public string Unknow1 { get; set; }

        [EdiValue("X(22)", Order = 1, Description = "")]
        public string InvoiceNumber { get; set; }

        [EdiValue("X(20)", Order = 2, Description = "")]
        public string ShipmentIdentificationNumber { get; set; }

        [EdiValue("X(2)", Order = 3, Description = "")]
        public string ShipmentMethodOfPayment { get; set; }

        [EdiValue("X(50)", Order = 4, Description = "")]
        public string Unknow2 { get; set; }

        [EdiValue("X(8)", Order = 5, Description = "")]
        public string Date { get; set; }

        [EdiValue("X(12)", Order = 6, Description = "")]
        public string NetAmountDue { get; set; }

        [EdiValue("X(2)", Order = 7, Description = "")]
        public string CorrectionIndicator { get; set; }

        [EdiValue("X(8)", Order = 8, Description = "")]
        public string DeliveryDate { get; set; }

        [EdiValue("X(3)", Order = 9, Description = "")]
        public string DateTimeQualifier { get; set; }

        [EdiValue("X(4)", Order = 10, Description = "")]
        public string StandardCarrierAlphaCode { get; set; }
    }
}
