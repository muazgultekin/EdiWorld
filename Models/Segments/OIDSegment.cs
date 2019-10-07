﻿using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    [EdiSegment(Path = "OID")]
    public class OIDSegment
    {
        [EdiValue("X(50)", Order = 0, Description = "")]
        public string Unknow1 { get; set; }

        [EdiValue("X(50)", Order = 1, Description = "")]
        public string Unknow2 { get; set; }

        [EdiValue("X(50)", Order = 2, Description = "")]
        public string Unknow3 { get; set; }

        [EdiValue("X(50)", Order = 3, Description = "")]
        public string Unknow4{ get; set; }

        [EdiValue("X(50)", Order = 4, Description = "")]
        public string Unknow5 { get; set; }

        [EdiValue("X(50)", Order = 5, Description = "")]
        public string Unknow6 { get; set; }

        [EdiValue("X(50)", Order = 6, Description = "")]
        public string Unknow7 { get; set; }

        [EdiValue("X(50)", Order = 7, Description = "")]
        public string Unknow8 { get; set; }
    }
}
