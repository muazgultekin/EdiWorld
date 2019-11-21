using EdiFileProcess.Attributes;
using System;

namespace EdiFileProcess.Models.EdiFact.Details {
    public class DateTimeOfPreparationDetails {
        [EdiValue("9(6)", Order = 0, Format = "yyMMdd")]
        [EdiOrder(Order = 0)]
        public DateTime Date { get; set; }

        [EdiValue("9(4)", Order = 1, Format = "hhmm")]
        [EdiOrder(Order = 1)]
        public TimeSpan Time { get; set; }
    }
}