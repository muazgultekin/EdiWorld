using EdiFileProcess.Attributes;
using EdiFileProcess.Models.X12.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.X12.Edi210
{
    /// <summary>
    /// Motor Carrier Freight Details and Invoice
    /// </summary>
    public class MotorCarrierFreightInvoice
    {
        [EdiSegment(Order = 0)]
        public STSegment ST { get; set; }

        [EdiSegment(Order = 1)]
        public B3Segment B3 { get; set; }

        [EdiSegment(Order = 2, IsCollection =true)]
        public List<R3Segment> R3 { get; set; }

        [EdiSegment(Order = 3, IsCollection = true)]
        public List<Equipment> Equipments { get; set; }

        [EdiSegment(Order = 4, IsCollection = true)]
        public List<MotorCarrierFreight> MotorCarrierFreights { get; set; }

        [EdiSegment(Order = 1)]
        public L3Segment L3 { get; set; }
    }
}
