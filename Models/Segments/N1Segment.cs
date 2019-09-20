using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    [EdiSegment(Path = "N1")]
    public class N1Segment
    {
        [EdiValue("X(2)", Order = 0)]
        public string EntityIdentifierCode { get; set; }

        [EdiValue("X(50)", Order = 1)]
        public string Name { get; set; }

        [EdiValue("X(2)", Order = 2)]
        public string IdentificationCodeQualifier { get; set; }

        [EdiValue("X(6)", Order = 3)]
        public string IdentificationCode { get; set; }
    }
}