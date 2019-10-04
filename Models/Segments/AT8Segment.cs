using EdiFileProcess.Attributes;
namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// 
    /// </summary>
    [EdiSegment(Path = "AT8")]
    public class AT8Segment
    {
        [EdiValue("X(2)", Order = 0, Path = "AT8", Description = "")]
        public string WeightQualifier  { get; set; }

        [EdiValue("X(1)", Order = 1, Path = "AT8", Description = "")]
        public string WeightUnitCode { get; set; }

        [EdiValue("X(10)", Order = 2, Path = "AT8", Description = "")]
        public string Weight { get; set; }

        [EdiValue("X(7)", Order = 3, Path = "AT8", Description = "")]
        public string LadingQuantity1 { get; set; }

        [EdiValue("X(7)", Order = 4, Path = "AT8", Description = "")]
        public string LadingQuantity2 { get; set; }
    }
}