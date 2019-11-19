/// https://www.eberspaecher.com/fileadmin/data/corporatesite/pdf/de/8_lieferanten/DESADV_D97A_EBE_EN.pdf

using EdiFileProcess.Attributes;
using EdiFileProcess.Models.EdiFacts.Desadv;
using EdiFileProcess.Models.EdiFacts.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.EdiFacts {
    /// <summary>
    /// DESADV - Dispatch advice message
    /// </summary>
    public class EdiFactDesadvModel {
        [EdiSegment(Order = 0)]
        public UNBSegment UNB { get; set; }
        
        [EdiSegment(Path = "UNH", Order = 1, IsCollection = true, SequenceEnd = "UNT", IsWithSequenceEnd = true)]
        public List<DespatchAdvice> DespatchAdvices { get; set; }

        [EdiSegment(Order = 2)]
        public UNZSegment IEA { get; set; }
    }
}
