using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments
{
    [EdiSegment(Path = "PO1")]
    public class PO1Segment
    {
        [EdiValue("X(50)", Order = 0)]
        public string OrderLineNumber { get; set; }

        [EdiValue("X(50)", Order = 1)]
        public decimal QuantityOrdered { get; set; }

        [EdiValue("X(50)", Order = 2)]
        public string UnitOfMeasurement { get; set; }

        [EdiValue("X(50)", Order = 3)]
        public decimal UnitPrice { get; set; }

        [EdiValue("X(50)", Order = 4)]
        public string BuyersPartno { get; set; }

        [EdiValue("X(50)", Order = 5)]
        public string VendorsPartno { get; set; }

        [EdiValue("X(50)", Order = 6)]
        public string Unknow1 { get; set; }
    }
}
