using EdiFileProcess.Models.Segments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EdiFileProcess.UnitTest.Validations
{
    public class GSSegmentValidate
    {
        public  static void Validate(GSSegment GSSerializer, GSSegment GSDeserializer)
        {
            Assert.AreEqual(GSSerializer.FunctionalIdentifierCode, GSDeserializer.FunctionalIdentifierCode);
            Assert.AreEqual(GSSerializer.ApplicationSenderCode, GSDeserializer.ApplicationSenderCode);
            Assert.AreEqual(GSSerializer.ApplicationReceiverCode, GSDeserializer.ApplicationReceiverCode);
            Assert.AreEqual(GSSerializer.Date, GSDeserializer.Date);
            Assert.AreEqual(GSSerializer.GroupControlNumber, GSDeserializer.GroupControlNumber);
            Assert.AreEqual(GSSerializer.ResponsibleAgencyCode, GSDeserializer.ResponsibleAgencyCode);
            Assert.AreEqual(GSSerializer.VersionReleaseIndustryIdentifierCode, GSDeserializer.VersionReleaseIndustryIdentifierCode);
        }
    }
}