using EdiFileProcess.Attributes;


namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// Beginning Segment for Shipment Information Transaction
    /// </summary>
    [EdiSegment(Path = "B2")]
    public class B2Segment
    {
        [EdiValue("X(50)", Order = 0, Path = "B2", Description = "")]
        public string Unknow1 { get; set; }

        [EdiValue("X(50)", Order = 0, Path = "B2", Description = "")]
        public string StandardCarrierAlphaCode { get; set; }

        [EdiValue("X(50)", Order = 0, Path = "B2", Description = "")]
        public string Unknow3 { get; set; }

        [EdiValue("X(50)", Order = 0, Path = "B2", Description = "")]
        public string ShipmentIdentificationNumber { get; set; }

        [EdiValue("X(50)", Order = 0, Path = "B2", Description = "")]
        public string Unknow5 { get; set; }

        [EdiValue("X(50)", Order = 0, Path = "B2", Description = "")]
        public string ShipmentMethodOfPayment { get; set; }
    }
}