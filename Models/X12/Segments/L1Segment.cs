using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments
{
    /// <summary>
    /// Rate and Charges
    /// </summary>
    [EdiSegment(Path = "L1")]
    public class L1Segment
    {
        [EdiValue("X(3)", Order = 0, Description = "")]
        public string LadingLineItemNumber  { get; set; }

        [EdiValue("X(9)", Order = 1, Description = "")]
        public string FreightRate  { get; set; }

        [EdiValue("X(2)", Order = 2, Description = "")]
        public string RateValueQualifier { get; set; }

        [EdiValue("X(12)", Order = 3, Description = "")]
        public string Charge  { get; set; }

        [EdiValue("X(9)", Order = 4, Description = "")]
        public string Advances { get; set; }

        [EdiValue("X(50)", Order = 5, Description = "")]
        public string Unknow5 { get; set; }

        [EdiValue("X(50)", Order = 6, Description = "")]
        public string Unknow6 { get; set; }

        [EdiValue("X(50)", Order = 7, Description = "")]
        public string Unknow7 { get; set; }

        [EdiValue("X(3)", Order = 8, Description = "")]
        public string SpecialChargeOrAllowanceCode { get; set; }

        [EdiValue("X(50)", Order = 9, Description = "")]
        public string Unknow9 { get; set; }

        [EdiValue("X(50)", Order = 10, Description = "")]
        public string Unknow10 { get; set; }

        [EdiValue("X(50)", Order = 11, Description = "")]
        public string Unknow11 { get; set; }

        [EdiValue("X(25)", Order = 12, Description = "")]
        public string SpecialChargeDescription { get; set; }
    }
}