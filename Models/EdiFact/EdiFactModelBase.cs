/// https://www.eberspaecher.com/fileadmin/data/corporatesite/pdf/de/8_lieferanten/DESADV_D97A_EBE_EN.pdf
/// https://www.faurecia.com/sites/groupe/files/paradocfournisseurs/faurecia_edi_guideline_desadv_d97a_v6r2.pdf

using EdiFileProcess.Attributes;
using EdiFileProcess.Enums;
using EdiFileProcess.Models.EdiFact.Desadv;
using EdiFileProcess.Models.EdiFact.Segments;
using System.Collections.Generic;

namespace EdiFileProcess.Models.EdiFact {
    /// <summary>
    /// DESADV - Dispatch advice message
    /// </summary>
    [EdiFact(EdiFactType = EdiFactTypes.DESADV)]
    public class EdiFactDesadvModel : EdiFactModelBase {       
        [EdiSegment(Path = "UNH", Order = 1, IsCollection = true, SequenceEnd = "UNT", IsWithSequenceEnd = true)]
        public List<DespatchAdvice> DespatchAdvices { get; set; }        
    }
}
