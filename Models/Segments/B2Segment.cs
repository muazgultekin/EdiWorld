using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// Beginning Segment for Shipment Information Transaction
    /// </summary>
    [EdiSegment(Path = "B2")]
    public class B2Segment
    {
        public string Unknow1 { get; set; }
        public string StandardCarrierAlphaCode { get; set; }
        public string Unknow3 { get; set; }
        public string ShipmentIdentificationNumber { get; set; }
        public string Unknow5 { get; set; }
        public string ShipmentMethodOfPayment { get; set; }
    }
}