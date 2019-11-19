using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments
{
    [EdiSegment(Path = "G61")]
    public class G61Segment
    {
        [EdiValue("X(2)", Order = 0, Description = "")]
        public string ContactFunctionCode { get; set; }

        [EdiValue("X(60)", Order = 1, Description = "")]
        public string Name { get; set; }

        [EdiValue("X(2)", Order = 2, Description = "")]
        public string CommunicationNumberQualifier { get; set; }

        [EdiValue("X(80)", Order = 3, Description = "")]
        public string CommunicationNumber  { get; set; }
    }
}
