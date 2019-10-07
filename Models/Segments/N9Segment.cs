using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// 
    /// </summary>
    [EdiSegment(Path = "N9")]
    public class N9Segment
    {
        [EdiValue("X(3)", Order = 0, Description = "")]
        public string ReferenceIdentificationQualifier { get; set; }

        [EdiValue("X(30)", Order = 1, Description = "")]
        public string ReferenceIdentification { get; set; }
    }
}
