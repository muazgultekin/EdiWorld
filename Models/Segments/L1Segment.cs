﻿using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// Rate and Charges
    /// </summary>
    [EdiSegment(Path = "L1")]
    public class L1Segment
    {
        [EdiValue("X(3)", Order = 0, Path = "L1", Description = "")]
        public string LadingLineItemNumber  { get; set; }

        [EdiValue("X(9)", Order = 1, Path = "L1", Description = "")]
        public string FreightRate  { get; set; }

        [EdiValue("X(2)", Order = 2, Path = "L1", Description = "")]
        public string RateValueQualifier { get; set; }

        [EdiValue("X(12)", Order = 3, Path = "L1", Description = "")]
        public string Charge  { get; set; }

        [EdiValue("X(9)", Order = 4, Path = "L1", Description = "")]
        public string Advances { get; set; }

        [EdiValue("X(50)", Order = 5, Path = "L1", Description = "")]
        public string Unknow5 { get; set; }

        [EdiValue("X(50)", Order = 6, Path = "L1", Description = "")]
        public string Unknow6 { get; set; }

        [EdiValue("X(50)", Order = 7, Path = "L1", Description = "")]
        public string Unknow7 { get; set; }

        [EdiValue("X(3)", Order = 8, Path = "L1", Description = "")]
        public string SpecialChargeOrAllowanceCode { get; set; }

        [EdiValue("X(50)", Order = 9, Path = "L1", Description = "")]
        public string Unknow9 { get; set; }

        [EdiValue("X(50)", Order = 10, Path = "L1", Description = "")]
        public string Unknow10 { get; set; }

        [EdiValue("X(50)", Order = 11, Path = "L1", Description = "")]
        public string Unknow11 { get; set; }

        [EdiValue("X(25)", Order = 12, Path = "L1", Description = "")]
        public string SpecialChargeDescription { get; set; }
    }
}