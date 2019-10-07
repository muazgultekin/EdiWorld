using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    [EdiSegment(Path = "TD1")]
    public class TD1Segment
    {
        [EdiValue("X(5)", Order =0)]
        public string PackagingCode { get; set; }

        [EdiValue("X(7)", Order = 1)]
        public string LadingQuantity { get; set; }

        [EdiValue("X(1)", Order = 2)]
        public string CommodityCodeQualifier { get; set; }

        [EdiValue("X(30)", Order = 3)]
        public string CommodityCode { get; set; }

        [EdiValue("X(50)", Order = 4)]
        public string LadingDescription { get; set; }

        [EdiValue("X(2)", Order = 5)]
        public string WeightQualifier { get; set; }

        [EdiValue("X(10)", Order = 6)]
        public string Weight { get; set; }

        [EdiValue("X(2)", Order = 7)]
        public string UnitOrBasisForMeasurementCode { get; set; }

        [EdiValue("X(10)", Order = 8)]
        public string Unknown1 { get; set; }

        [EdiValue("X(10)", Order = 9)]
        public string Unknown2 { get; set; }
    }
}
