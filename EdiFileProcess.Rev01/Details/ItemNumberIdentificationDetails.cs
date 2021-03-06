﻿using EdiFileProcess.Rev01.Attributes;

namespace EdiFileProcess.Rev01.Details {
    public class ItemNumberIdentificationDetails {
        [EdiOrder(Order = 0)]
        public string ItemNumber { get; set; }

        [EdiOrder(Order = 1)]
        public string ItemNumberTypeCoded { get; set; }

        [EdiOrder(Order = 2)]
        public string CodeListQualifier { get; set; }

        [EdiOrder(Order = 3)]
        public string CodeListResponsibleAgencyCoded { get; set; }
    }
}