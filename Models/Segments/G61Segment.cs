using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    [EdiSegment(Path = "G61")]
    public class G61Segment
    {
        [EdiValue("X(2)", Order = 0, Path = "G61", Description = "")]
        public string ContactFunctionCode { get; set; }

        [EdiValue("X(60)", Order = 1, Path = "G61", Description = "")]
        public string Name { get; set; }

        [EdiValue("X(2)", Order = 2, Path = "G61", Description = "")]
        public string CommunicationNumberQualifier { get; set; } 

        [EdiValue("X(80)", Order = 3, Path = "G61", Description = "")]
        public string CommunicationNumber  { get; set; }
    }
}
