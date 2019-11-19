using EdiFileProcess.Attributes;
using EdiFileProcess.Models.X12.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.X12.Edi204
{
    public class OrderIdentificationDetail
    {
        [EdiSegment(Order = 0)]
        public OIDSegment OID { get; set; }

        [EdiSegment(Order = 1, IsCollection = true)]
        public List<MarksAndNumber> MarksAndNumbers { get; set; }
    }
}
