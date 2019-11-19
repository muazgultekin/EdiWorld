using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFacts.Segments {
    [EdiSegment(Path = "PAC")]
    public class PACSegment {
        [EdiValue("9(2)", Order = 0)]
        public int NumberOfPackages { get; set; }
        [EdiValue("X(20)", Order = 1)]
        public string Unknow01 { get; set; }
        [EdiValue("X(20)", Order = 2)]
        public int PackageType { get; set; }
    }
}