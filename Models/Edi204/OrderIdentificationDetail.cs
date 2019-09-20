using EdiFileProcess.Attributes;
using EdiFileProcess.Models.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.Edi204
{
    public class OrderIdentificationDetail
    {
        [EdiSegment(Order = 0)]
        public OIDSegment OID { get; set; }

        [EdiSegment(Order = 1, IsCollection = true)]
        public List<MarksAndNumber> MarksAndNumbers { get; set; }
    }
}
