using EdiFileProcess.Models.X12.Segments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EdiFileProcess.UnitTest.Validations
{
    public class N9SegmentValidate
    {
        public static void Validate(N9Segment N9Serializer, N9Segment N9Deserializer)
        {
            Assert.AreEqual(N9Serializer.ReferenceIdentification, N9Deserializer.ReferenceIdentification);
            Assert.AreEqual(N9Serializer.ReferenceIdentificationQualifier, N9Deserializer.ReferenceIdentificationQualifier);            
        }
    }
}