using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    [EdiSegment(Path = "N4")]
    public class N4Segment
    {
        [EdiValue("X(200)", Order = 0, Path = "N4", Description = "")]
        public string CityName { get; set; }

        [EdiValue("X(200)", Order = 1, Path = "N4", Description = "")]
        public string StateOrProvinceCode { get; set; }

        [EdiValue("X(200)", Order = 2, Path = "N4", Description = "")]
        public string PostalCode { get; set; }

        [EdiValue("X(200)", Order = 3, Path = "N4", Description = "")]
        public string CountryCode { get; set; }
    }
}
