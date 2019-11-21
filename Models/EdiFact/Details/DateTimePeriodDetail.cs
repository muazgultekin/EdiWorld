using EdiFileProcess.Attributes;
using System;

namespace EdiFileProcess.Models.EdiFact.Details {
    [EdiSegment(Path = "DTM")]
    public class DateTimePeriodDetail {
        [EdiValue(Format = "X(20)", Order = 0, Path = "DTM")]
        [EdiOrder(Order = 0)]
        public string DateTimePeriodQualifier { get; set; }

        [EdiValue("9(12)", Order = 1, Format = "yyyyMMddHHmm", Path = "DTM")]
        [EdiOrder(Order = 1)]
        public DateTime DatePeriodQualifie { get; set; }
       
        [EdiValue("X(20)", Order = 2, Path = "DTM")]
        [EdiOrder(Order = 3)]
        public string DateTimePeriodFormatQualifier { get; set; }
    }
}