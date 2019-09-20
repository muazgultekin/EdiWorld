using EdiFileProcess.Models.Segments;
using System;

namespace EdiFileProcess.UnitTest.MainClasses
{
    internal class ISAClass
    {        
        public static ISASegment Get()
        {
            ISASegment iSAClass = new ISASegment();
            iSAClass.AuthorizationInformationQualifier = 0;
            iSAClass.AuthorizationInformation = "          ";
            iSAClass.SecurityInformationQualifier = 0;
            iSAClass.SecurityInformation = "";
            iSAClass.SenderIDQualifier = "02";
            iSAClass.SenderID = "UFLB";
            iSAClass.ReceiverIDQualifier = "14";
            iSAClass.ReceiverID = "006922827TEST1";
            iSAClass.Date = new DateTime(2019, 04, 18, 17, 30, 0);
            iSAClass.ControlStandardsIdentifier = "U";
            iSAClass.ControlVersionNumber = 401;
            iSAClass.ControlNumber = 14;
            iSAClass.AcknowledgmentRequeste = false;
            iSAClass.UsageIndicator = "P";
            iSAClass.ComponentElementSeparator = '|';
            return iSAClass;
        }
    }
}
