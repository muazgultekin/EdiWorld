using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments
{
    /// <summary>
    /// Carton (Package) Detail
    /// </summary>
    [EdiSegment(Path = "CD3")]
    public class CD3Segment
    {
        [EdiValue("X(2)", Order = 0, Description = "")]
        public string WeightQualifier { get; set; }

        [EdiValue("X(10)", Order = 1, Description = "")]
        public string Weight { get; set; }

        [EdiValue("X(3)", Order = 2, Description = "")]
        public string Zone { get; set; }

        [EdiValue("X(4)", Order = 3, Description = "")]
        public string ServiceStandard  { get; set; }

        [EdiValue("X(2)", Order = 4, Description = "")]
        public string ServiceLevelCode { get; set; }

        [EdiValue("X(2)", Order = 5, Description = "")]
        public string PickUpOrDeliveryCode { get; set; }

        [EdiValue("X(2)", Order = 6, Description = "")]
        public string RateValueQualifier { get; set; }

        [EdiValue("X(12)", Order = 7, Description = "")]
        public string Charge { get; set; }

        [EdiValue("X(2)", Order = 8, Description = "")]
        public string RateValueQualifier2 { get; set; }

        [EdiValue("X(12)", Order = 9, Description = "")]
        public string Charge2 { get; set; }

        [EdiValue("X(2)", Order = 10, Description = "")]
        public string ServiceLevelCode2 { get; set; }

        [EdiValue("X(2)", Order = 11, Description = "")]
        public string ServiceLevelCode3 { get; set; }

        [EdiValue("X(3)", Order = 12, Description = "")]
        public string PaymentMethodCode { get; set; }

        [EdiValue("X(3)", Order = 13, Description = "")]
        public string CountryCode { get; set; }
    }
}
