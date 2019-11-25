using System;
using EdiFileProcess.Rev01.Attributes;

namespace EdiFileProcess.Rev01.Details {
    public class DateTimePperiodDetails {
        [EdiOrder(Order = 0)]
        public string DateTimePeriodQualifier { get; set; }

        [EdiOrder(Order = 1, Format = "yyyyMMddHHmm")]
        public DateTime DatePeriodQualifie { get; set; }

        [EdiOrder(Order = 2)]
        public string DateTimePeriodFormatQualifier { get; set; }
    }
}