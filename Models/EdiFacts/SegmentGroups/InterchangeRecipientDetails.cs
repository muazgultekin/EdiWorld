﻿using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFacts.SegmentGroups {
    public class InterchangeRecipientDetails {
        [EdiValue("X(20)", Order = 0)]
        public int RecipientIdentification { get; set; }
        [EdiValue("X(20)", Order = 1)]
        public int IdentificationCodeQualifier { get; set; }
    }
}