using EdiFileProcess.Models;
using EdiFileProcess.Models.Edi990;
using EdiFileProcess.UnitTest.E990;
using EdiFileProcess.UnitTest.MainClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EdiFileProcess.UnitTest
{
    [TestClass]
    public class UnitTestE990
    {
        [TestMethod]
        public void TestE990()
        {
            Edi990Model serializer = new Edi990Model
            {
                ISA = ISAClass.Get(),
                GS = GSClass.Get(),
                ResponseToLoadTenders = ResponseToLoadTendersClass.Get(),
                GE = GEClass.Get(),
                IEA = IEAClass.Get()
            };

            E990Class e990Class = new E990Class();
            e990Class.Serializer(serializer);

            Edi990Model deserializer = new Edi990Model();
            deserializer = (Edi990Model)e990Class.Deserialize();

            /// ISA test complited 
            Assert.AreEqual(serializer.ISA.AuthorizationInformationQualifier, deserializer.ISA.AuthorizationInformationQualifier);
            Assert.AreEqual(serializer.ISA.AuthorizationInformation, deserializer.ISA.AuthorizationInformation);
            Assert.AreEqual(serializer.ISA.SecurityInformationQualifier, deserializer.ISA.SecurityInformationQualifier);
            Assert.AreEqual(serializer.ISA.SecurityInformation, deserializer.ISA.SecurityInformation.Trim());
            Assert.AreEqual(serializer.ISA.SenderIDQualifier, deserializer.ISA.SenderIDQualifier);
            Assert.AreEqual(serializer.ISA.SenderID, deserializer.ISA.SenderID.Trim());
            Assert.AreEqual(serializer.ISA.ReceiverIDQualifier, deserializer.ISA.ReceiverIDQualifier);
            Assert.AreEqual(serializer.ISA.ReceiverID, deserializer.ISA.ReceiverID);
            Assert.AreEqual(serializer.ISA.Date, deserializer.ISA.Date);
            Assert.AreEqual(serializer.ISA.ControlStandardsIdentifier, deserializer.ISA.ControlStandardsIdentifier);
            Assert.AreEqual(serializer.ISA.ControlVersionNumber, deserializer.ISA.ControlVersionNumber);
            Assert.AreEqual(serializer.ISA.ControlNumber, deserializer.ISA.ControlNumber);
            Assert.AreEqual(serializer.ISA.AcknowledgmentRequeste, deserializer.ISA.AcknowledgmentRequeste);
            Assert.AreEqual(serializer.ISA.UsageIndicator, deserializer.ISA.UsageIndicator);
            Assert.AreEqual(serializer.ISA.ComponentElementSeparator, serializer.ISA.ComponentElementSeparator);

            // GS test complited
            Assert.AreEqual(serializer.GS.FunctionalIdentifierCode, deserializer.GS.FunctionalIdentifierCode);
            Assert.AreEqual(serializer.GS.ApplicationSenderCode, deserializer.GS.ApplicationSenderCode);
            Assert.AreEqual(serializer.GS.ApplicationReceiverCode, deserializer.GS.ApplicationReceiverCode);
            Assert.AreEqual(serializer.GS.Date, deserializer.GS.Date);
            Assert.AreEqual(serializer.GS.GroupControlNumber, deserializer.GS.GroupControlNumber);
            Assert.AreEqual(serializer.GS.ResponsibleAgencyCode, deserializer.GS.ResponsibleAgencyCode);
            Assert.AreEqual(serializer.GS.VersionReleaseIndustryIdentifierCode, deserializer.GS.VersionReleaseIndustryIdentifierCode);
           

            // GEC test complited
            Assert.AreEqual(serializer.GE.NumberOfTransactionsSetsIncluded, deserializer.GE.NumberOfTransactionsSetsIncluded);
            Assert.AreEqual(serializer.GE.NumberGroupControlNumber, deserializer.GE.NumberGroupControlNumber);

            // IEA test complited
            Assert.AreEqual(serializer.IEA.NumberOfIncludedFunctionalGroups, deserializer.IEA.NumberOfIncludedFunctionalGroups);
            Assert.AreEqual(serializer.IEA.QuantityInterchangeControlNumber, deserializer.IEA.QuantityInterchangeControlNumber);



        }
    }
}