using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    [EdiSegment(Path = "N4")]
    public class N4Segment
    {
        [EdiValue("X(200)", Order = 0)]
        public string CityName { get; set; }

        [EdiValue("X(200)", Order = 1)]
        public string StateOrProvinceCode { get; set; }

        [EdiValue("X(200)", Order = 2)]
        public string PostalCode { get; set; }

        [EdiValue("X(200)", Order = 3)]
        public string CountryCode { get; set; }
    }
}
