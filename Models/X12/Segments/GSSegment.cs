using System;

using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments
{
    /// <summary>
    /// Functional Group Header 
    /// </summary>
    [EdiSegment(Path = "GS")]
    public class GSSegment
    {
        [EdiValue("X(2)", Order = 0, Description = "Code identifying a group of application related transaction sets.")]
        public string FunctionalIdentifierCode { get; set; }

        [EdiValue("X(15)", Order = 1, Description = "Code identifying a group of application related transaction sets.")]
        public string ApplicationSenderCode { get; set; }

        [EdiValue("X(15)", Order = 2, Description = "Code identifying party receiving transmission; codes agreed to by trading partners.")]
        public string ApplicationReceiverCode { get; set; }

        [EdiValue("9(8)", Order = 3, Format = "yyyyMMdd", Description = "Date expressed as CCYYMMDD.")]
        [EdiValue("9(4)", Order = 4, Format = "HHmm", Description = "Time expressed in 24-hour clock time as follows: HHMM, or HHMMSS, or HHMMSSD, or HHMMSSDD, where H = hours (00-23), M = minutes (00-59), S = integer seconds (00-59) and DD = decimal seconds; decimal seconds are expressed as follows: D = tenths (0-9) and DD = hundredths (00-99).")]
        public DateTime Date { get; set; }

        [EdiValue("X(9)", Order = 5, Description = "Assigned number originated and maintained by the sender")]
        public string GroupControlNumber { get; set; }

        [EdiValue("X(2)", Order = 6, Description = "Code identifying the issuer of the standard; this code is used in conjunction with Data Element 480.")]
        public string ResponsibleAgencyCode { get; set; }

        [EdiValue("X(12)", Order = 7, Description = "Code indicating the version, release, subrelease, and industry identifier of the EDI standard being used, including the GS and GE segments; if code in DE455 in GS segment is X, then in DE 480 positions 13 are the version number; positions 4-6 are the release and subrelease, level of the version; and positions 7-12 are the industry or trade association identifiers (optionally assigned by user); if code in DE455 in GS segment is T, then other formats are allowed.")]
        public string VersionReleaseIndustryIdentifierCode { get; set; }
    }
}