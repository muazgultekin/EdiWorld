﻿using EdiFileProcess.Attributes;
using System;

namespace EdiFileProcess.Models.Segments
{
    [EdiSegment(Path = "DTM")]
    public class DTMSegment 
    {
        [EdiValue("X(50)", Order = 0, Path = "DTM")]
        public string DateTimeQualifier { get; set; }

        [EdiValue("9(8)", Order = 1, Format = "yyyyMMdd", Path = "DTM")]
        public DateTime Date { get; set; }
    }
}