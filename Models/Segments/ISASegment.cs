using EdiFileProcess.Attributes;
using System;

namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// Interchange Control Header
    /// </summary>
    [EdiSegment(Path = "ISA")]
    public class ISASegment
    {
        [EdiValue("9(2)", Order = 0, Description = "Code to identify the type of information in the Authorization Information.")]
        public int AuthorizationInformationQualifier { get; set; }

        [EdiValue("X(10)", Order = 1, IsTrim = false, Description = " Information used for additional identification or authorization of the interchange sender or the data in the interchange; the type of information is set by the Authorization Information Qualifier (I01).")]
        public string AuthorizationInformation { get; set; }

        [EdiValue("9(2)", Order = 2, Description = " Code to identify the type of information in the Security Information.")]
        public int SecurityInformationQualifier { get; set; }

        [EdiValue("X(10)", Order = 3, IsTrim = false, Description = "This is used for identifying the security information about the interchange sender or the data in the interchange; the type of information is set by the Security Information Qualifier (I03).")]
        public string SecurityInformation { get; set; }

        [EdiValue("X(2)", Order = 4, Description = "Qualifier to designate the system/method of code structure used to designate the sender or receiver ID element being qualified.")]
        public string SenderIDQualifier { get; set; }

        [EdiValue("X(15)", Order = 5, IsTrim = false, Description = "Identification code published by the sender for other parties to use as the receiver ID to route data to them; the sender always codes this value in the sender ID element.")]
        public string SenderID { get; set; }

        [EdiValue("X(2)", Order = 6, Description = "Qualifier to designate the system/method of code structure used to designate the sender or receiver ID element being qualified.")]
        public string ReceiverIDQualifier { get; set; }

        [EdiValue("X(15)", Order = 7, IsTrim = false, Description = "Identification code published by the receiver of the data; When sending, it is used by the sender as their sending ID, thus other parties sending to them will use this as a receiving ID to route data to them.")]
        public string ReceiverID { get; set; }

        [EdiValue("9(6)", Order = 8, Format = "yyMMdd", Description = "Date of the interchange.")]
        [EdiValue("9(4)", Order = 9, Format = "HHmm", Description = "Time of the interchange.")]
        public DateTime Date { get; set; }

        [EdiValue("X(1)", Order = 10, Description = "Code to identify the agency responsible for the control standard used by the message that is enclosed by the interchange header and trailer.")]
        public string ControlStandardsIdentifier { get; set; }

        [EdiValue("9(5)", Order = 11, Description = "Code specifying the version number of the interchange control segments.")]
        public int ControlVersionNumber { get; set; }

        [EdiValue("9(9)", Order = 12, Description = "A control number assigned by the interchange sender.")]
        public int ControlNumber { get; set; }

        [EdiValue("9(1)", Order = 13, Description = "Code sent by the sender to request an interchange acknowledgment (TA1).")]
        public bool? AcknowledgmentRequeste { get; set; }

        [EdiValue("X(1)", Order = 14, Description = "Code to indicate whether data enclosed by this interchange envelope is test, production or information.")]
        public string UsageIndicator { get; set; }

        [EdiValue("X(1)", Order = 15, Description = "Type is not applicable; the component element separator is a delimiter and not a data element; this field provides the delimiter used to separate component data elements within a composite data structure; this value must be different than the data element separator and the segment terminator.")]
        public char? ComponentElementSeparator { get; set; }
    }
}