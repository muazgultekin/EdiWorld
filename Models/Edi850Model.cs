﻿using EdiFileProcess.Attributes;
using EdiFileProcess.Enums;
using EdiFileProcess.Models.Edi850;
using EdiFileProcess.Models.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models
{
    [Edi(EdiType = EdiTypes.Edi850)]
    public class Edi850Model
    {
        [EdiSegment(Order = 0)]
        public ISASegment ISA { get; set; }

        [EdiSegment(Order = 1)]
        public GSSegment GS { get; set; }

        [EdiSegment(Path = "ST", Order = 2, IsCollection = true, SequenceEnd = "SE")]
        public List<PurchaseOrder> PurchaseOrders { get; set; }

        [EdiSegment(Order = 3)]
        public GESegment GE { get; set; }

        [EdiSegment(Order = 4)]
        public IEASegment IEA { get; set; }
    }
}