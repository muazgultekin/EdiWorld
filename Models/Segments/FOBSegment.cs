using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// F.O.B. Related Instruction
    /// </summary>
    [EdiSegment(Path = "FOB")]
    public class FOBSegment
    {
        [EdiValue("X(2)", Order = 0, Description ="")]
        public string ShipmentMethodOfPayment  { get; set; }

        [EdiValue("X(2)", Order = 1, Description = "")]
        public string LocationQualifier   { get; set; }

        [EdiValue("X(80)", Order = 2, Description = "")]
        public string Description { get; set; }

        [EdiValue("X(2)", Order = 3, Description = "")]
        public string TransportationTermsQualifierCode { get; set; }

        [EdiValue("X(3)", Order = 4, Description = "")]
        public int TransportationTermsCode { get; set; }

        [EdiValue("X(2)", Order = 5, Description = "")]
        public int LocationQualifier2 { get; set; }

        [EdiValue("X(80)", Order = 6, Description = "")]
        public int Description2 { get; set; }        
    }
}