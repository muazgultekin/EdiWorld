using EdiFileProcess.Models.Segments;
using System;

namespace EdiFileProcess.UnitTest.MainClasses
{
    internal class GSClass
    {
        public static GSSegment Get()
        {
            //*****1730*3*X*004010~
            GSSegment gSSegment = new GSSegment
            {
                FunctionalIdentifierCode = "GF",
                ApplicationSenderCode = "UFLB",
                ApplicationReceiverCode = "006922827TEST1",
                Date = new DateTime(2019, 04, 18, 17, 30, 0),
                GroupControlNumber = "3",
                ResponsibleAgencyCode = "X",
                VersionReleaseIndustryIdentifierCode = "004010"
            };
            return gSSegment;
        }
    }    
}
