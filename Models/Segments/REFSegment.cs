using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// Reference Numbers
    /// REF*BM*1234~
    /// </summary>
    [EdiSegment(Path = "REF")]
    public class REFSegment 
    {
        [EdiValue("X(22)", Order = 0, Path = "REF")]
        public string ReferenceNumberQualifier { get; set; }

        [EdiValue("X(30)", Order = 1, Path = "REF")]
        public string ReferenceNumber { get; set; }
    }
}
