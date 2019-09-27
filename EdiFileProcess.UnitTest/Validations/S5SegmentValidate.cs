using EdiFileProcess.Models.Segments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EdiFileProcess.UnitTest.Validations
{
    public class S5SegmentValidate
    {
        public static void Validate(S5Segment S5Serializer, S5Segment S5Deserializer)
        {
            Assert.AreEqual(S5Serializer.Description, S5Deserializer.Description);
            Assert.AreEqual(S5Serializer.StopReasonCode, S5Deserializer.StopReasonCode);
            Assert.AreEqual(S5Serializer.StopSequenceNumber, S5Deserializer.StopSequenceNumber);
            Assert.AreEqual(S5Serializer.Unknow1, S5Deserializer.Unknow1);
            Assert.AreEqual(S5Serializer.Unknow2, S5Deserializer.Unknow2);
            Assert.AreEqual(S5Serializer.Unknow3, S5Deserializer.Unknow3);
            Assert.AreEqual(S5Serializer.Unknow4, S5Deserializer.Unknow4);
            Assert.AreEqual(S5Serializer.Unknow5, S5Deserializer.Unknow5);
            Assert.AreEqual(S5Serializer.Unknow6, S5Deserializer.Unknow6);
        }
    }
}