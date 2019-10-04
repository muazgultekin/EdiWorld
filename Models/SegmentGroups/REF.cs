using EdiFileProcess.Attributes;
using EdiFileProcess.Models.Segments;


namespace EdiFileProcess.Models.SegmentGroups
{
    public class REF
    {
        [EdiSegment(Path = "REF", Order = 0)]
        public REFSegment REFSeg { get; set; }
    }
}