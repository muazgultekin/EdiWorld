using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    [EdiSegment(Path = "L3")]
    public class L3Segment
    {
        [EdiValue("X(10)", Order = 0, Path = "L3", Description = "")]
        public string Weight { get; set; }

        [EdiValue("X(2)", Order = 1, Path = "L3", Description = "")]
        public string WeightQualifier { get; set; }

        [EdiValue("X(9)", Order = 2, Path = "L3", Description = "")]
        public string FreightRate { get; set; }

        [EdiValue("X(2)", Order = 3, Path = "L3", Description = "")]
        public string ReteValueQualifier { get; set; }

        [EdiValue("X(12)", Order = 4, Path = "L3", Description = "")]
        public string Charge { get; set; }

        [EdiValue("X(50)", Order = 5, Path = "L3", Description = "")]
        public string UnUsed1 { get; set; }

        [EdiValue("X(50)", Order = 6, Path = "L3", Description = "")]
        public string UnUsed2 { get; set; }

        [EdiValue("X(3)", Order = 7, Path = "L3", Description = "")]
        public string SpecialChargeOrAllowanceCode { get; set; }

        [EdiValue("X(50)", Order = 8, Path = "L3", Description = "")]
        public string UnUsed3 { get; set; }

        [EdiValue("X(50)", Order = 9, Path = "L3", Description = "")]
        public string UnUsed4 { get; set; }

        [EdiValue("X(7)", Order = 10, Path = "L3", Description = "")]
        public string LadingQuantity { get; set; }
    }
}