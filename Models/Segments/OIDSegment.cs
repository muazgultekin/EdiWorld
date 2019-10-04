using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    [EdiSegment(Path = "OID")]
    public class OIDSegment
    {
        [EdiValue("X(50)", Order = 0, Path = "OID", Description = "")]
        public string Unknow1 { get; set; }

        [EdiValue("X(50)", Order = 1, Path = "OID", Description = "")]
        public string Unknow2 { get; set; }

        [EdiValue("X(50)", Order = 2, Path = "OID", Description = "")]
        public string Unknow3 { get; set; }

        [EdiValue("X(50)", Order = 3, Path = "OID", Description = "")]
        public string Unknow4{ get; set; }

        [EdiValue("X(50)", Order = 4, Path = "OID", Description = "")]
        public string Unknow5 { get; set; }

        [EdiValue("X(50)", Order = 5, Path = "OID", Description = "")]
        public string Unknow6 { get; set; }

        [EdiValue("X(50)", Order = 6, Path = "OID", Description = "")]
        public string Unknow7 { get; set; }

        [EdiValue("X(50)", Order = 7, Path = "OID", Description = "")]
        public string Unknow8 { get; set; }
    }
}
