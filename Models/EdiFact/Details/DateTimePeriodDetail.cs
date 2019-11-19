using EdiFileProcess.Attributes;
using System;

namespace EdiFileProcess.Models.EdiFact.Details {
    public class DateTimePeriodDetail {
        [EdiValue("X(20)", Order = 0)]
        public string DateTimePeriodQualifier { get; set; }

        [EdiValue("9(8)", Order = 1, Format = "yyyyMMdd")]
        public DateTime DatePeriodQualifie { get; set; }

        [EdiValue("9(4)", Order = 2, Format = "HHmm")]
        public DateTime TimePeriodQualifie { get; set; }
        
        [EdiValue("X(20)", Order = 3)]
        public string DateTimePeriodFormatQualifier { get; set; }
    }
}