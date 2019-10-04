using EdiFileProcess.Attributes;
using System;


namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// Shipment Status Details
    /// </summary>
    [EdiSegment(Path = "AT7")]
    public class AT7Segment
    {               
        [EdiValue("X(2)", Order = 0, Path = "AT7", Description = "Code indicating the status of a shipment")]
        public string ShipmentStatusCode { get; set; }

        [EdiValue("X(2)", Order = 1, Path = "AT7", Description = "Code indicating the reason a shipment status or appointment reason was transmitted")]
        public string ShipmentStatusOrAppointmentReasonCode { get; set; }

        [EdiValue("X(2)", Order = 2, Path = "AT7", Description = "")]
        public string ShipmentAppointmentStatusCode { get; set; }

        [EdiValue("X(2)", Order = 3, Path = "AT7", Description = "")]
        public string ShipmentStatusOrAppointmentReasonCode2 { get; set; }

        [EdiValue("9(8)", Order = 4, Format = "yyyyMMdd", Path = "AT7", Description = "Date of the interchange.")]
        public DateTime Date { get; set; }

        [EdiValue("9(4)", Order = 5, Format = "HHmm", Path = "AT7", Description = "Time of the interchange.")]
        public DateTime Time { get; set; }

        [EdiValue("X(2)", Order = 6, Path = "AT7", Description = "")]
        public string TimeCose { get; set; }
    }
}