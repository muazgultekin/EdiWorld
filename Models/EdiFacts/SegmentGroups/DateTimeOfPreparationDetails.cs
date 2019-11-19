using EdiFileProcess.Attributes;
using System;

namespace EdiFileProcess.Models.EdiFacts.SegmentGroups {
    public class DateTimeOfPreparationDetails {
        [EdiValue("9(8)", Order = 4, Format = "yyyyMMdd")]
        public DateTime Date { get; set; }

        [EdiValue("9(4)", Order = 5, Format = "HHmm")]
        public DateTime Time { get; set; }
    }
}
