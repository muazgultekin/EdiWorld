using EdiFileProcess.Models.Segments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EdiFileProcess.UnitTest.Validations
{
    public class ISASegmentValidate
    {
        public static void Validate(ISASegment ISASerializer, ISASegment ISADeserializer)
        {
            Assert.AreEqual(ISASerializer.AuthorizationInformationQualifier, ISADeserializer.AuthorizationInformationQualifier);
            Assert.AreEqual(ISASerializer.AuthorizationInformation, ISADeserializer.AuthorizationInformation);
            Assert.AreEqual(ISASerializer.SecurityInformationQualifier, ISADeserializer.SecurityInformationQualifier);
            Assert.AreEqual(ISASerializer.SecurityInformation, ISADeserializer.SecurityInformation.Trim());
            Assert.AreEqual(ISASerializer.SenderIDQualifier, ISADeserializer.SenderIDQualifier);
            Assert.AreEqual(ISASerializer.SenderID, ISADeserializer.SenderID.Trim());
            Assert.AreEqual(ISASerializer.ReceiverIDQualifier, ISADeserializer.ReceiverIDQualifier);
            Assert.AreEqual(ISASerializer.ReceiverID, ISADeserializer.ReceiverID);
            Assert.AreEqual(ISASerializer.Date, ISADeserializer.Date);
            Assert.AreEqual(ISASerializer.ControlStandardsIdentifier, ISADeserializer.ControlStandardsIdentifier);
            Assert.AreEqual(ISASerializer.ControlVersionNumber, ISADeserializer.ControlVersionNumber);
            Assert.AreEqual(ISASerializer.ControlNumber, ISADeserializer.ControlNumber);
            Assert.AreEqual(ISASerializer.AcknowledgmentRequeste, ISADeserializer.AcknowledgmentRequeste);
            Assert.AreEqual(ISASerializer.UsageIndicator, ISADeserializer.UsageIndicator);            
        }
    }
}