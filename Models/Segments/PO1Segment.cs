using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    [EdiSegment(Path = "PO1")]
    public class PO1Segment
    {
        [EdiValue("X(50)", Order = 0, Path = "PO1", Description ="")]
        public string OrderLineNumber { get; set; }

        [EdiValue("X(50)", Order = 1, Path = "PO1", Description = "")]
        public decimal QuantityOrdered { get; set; }

        [EdiValue("X(50)", Order = 2, Path = "PO1", Description = "")]
        public string UnitOfMeasurement { get; set; }

        [EdiValue("X(50)", Order = 3, Path = "PO1", Description = "")]
        public decimal UnitPrice { get; set; }

        [EdiValue("X(50)", Order = 4, Path = "PO1", Description = "")]
        public string BuyersPartno { get; set; }

        [EdiValue("X(50)", Order = 5, Path = "PO1", Description = "")]
        public string VendorsPartno { get; set; }

        [EdiValue("X(50)", Order = 6, Path = "PO1", Description = "")]
        public string Unknow1 { get; set; }
    }
}
