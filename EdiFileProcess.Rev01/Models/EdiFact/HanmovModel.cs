/// <summary>
/// Author          : Mehmet CINCI
/// Create Date     : 2019-11-23
/// Explanation     : Hanmov is first edifact class.
/// Source Document : https://www.stylusstudio.com/edifact/D96A/HANMOV.htm
/// </summary>      

using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Enums;
using EdiFileProcess.Rev01.Models.EdiFact.Base;
using EdiFileProcess.Rev01.Models.EdiFact.Hanmov;
using System.Collections.Generic;

namespace EdiFileProcess.Rev01.Models.EdiFact {
    [EdiFact(EdiFactType = EdiFactTypes.HANMOV)]
    public class HanmovModel : EdiFactModelBase {
        [EdiSegment(Order = 0)]
        public List<HanmovClass> Hanmovs { get; set; }
    }
}