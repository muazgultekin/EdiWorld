using EdiFileProcess.Attributes;
using System;

namespace EdiFileProcess.Models.X12.Segments
{
    /// <summary>
    /// 
    /// </summary>
    [EdiSegment(Path = "B1")]
    public class B1Segment
    {
        [EdiValue("X(4)", Order = 0, Description ="")]
        public string StandardCarrierAlphaCode { get; set; }

        [EdiValue("X(30)", Order = 1, Description = "")]
        public string ShipmentIdentificationNumber { get; set; }

        [EdiValue("9(8)", Order = 2, Format = "yyyyMMdd")]        
        public DateTime Date { get; set; }

        [EdiValue("X(1)", Order = 3, Description = "")]
        public string ReservationActionCode { get; set; }
    }

}
