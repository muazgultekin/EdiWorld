using EdiFileProcess.Rev01.Attributes;
using System;

namespace EdiFileProcess.Rev01.Details {
    public class DateTimeOfPreparationDetails {
        [EdiOrder(Order = 0, MaxLength = 6, Format = "yyMMdd")]
        public DateTime Date { get; set; }

        [EdiOrder(Order = 1, MaxLength = 4, Format = "hhmm")]
        public TimeSpan Time { get; set; }
    }
}