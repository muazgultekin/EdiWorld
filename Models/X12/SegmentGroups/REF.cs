using EdiFileProcess.Attributes;
using EdiFileProcess.Models.X12.Segments;

namespace EdiFileProcess.Models.X12.SegmentGroups
{
    public class REF
    {
        [EdiSegment(Path = "REF", Order = 0)]
        public REFSegment REFSeg { get; set; }
    }
}
