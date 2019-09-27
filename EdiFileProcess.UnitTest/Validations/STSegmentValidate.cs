using EdiFileProcess.Models.Segments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EdiFileProcess.UnitTest.Validations
{
    public class STSegmentValidate
    {
        public static void Validate(STSegment STSerializer, STSegment STDeserializer)
        {
            Assert.AreEqual(STSerializer.TransactionSetIdentifierCode, STDeserializer.TransactionSetIdentifierCode);
            Assert.AreEqual(STSerializer.TransactionSetControlNumber, STDeserializer.TransactionSetControlNumber);
        }
    }
}