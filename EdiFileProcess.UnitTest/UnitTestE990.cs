using EdiFileProcess.Models;
using EdiFileProcess.Models.Segments;
using EdiFileProcess.UnitTest.E990;
using EdiFileProcess.UnitTest.MainClasses;
using EdiFileProcess.UnitTest.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

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

            // ResponseToLoadTender test complited
            Assert.AreEqual(serializer.ResponseToLoadTenders.Count, deserializer.ResponseToLoadTenders.Count);

            for (int i = 0; i < serializer.ResponseToLoadTenders.Count; i++)
            {
                // ST test complited
                Assert.AreEqual(serializer.ResponseToLoadTenders[i].ST.TransactionSetControlNumber, deserializer.ResponseToLoadTenders[i].ST.TransactionSetControlNumber);
                Assert.AreEqual(serializer.ResponseToLoadTenders[i].ST.TransactionSetIdentifierCode, deserializer.ResponseToLoadTenders[i].ST.TransactionSetIdentifierCode);

                // B1 test complited
                Assert.AreEqual(serializer.ResponseToLoadTenders[i].B1.Date, deserializer.ResponseToLoadTenders[i].B1.Date);
                Assert.AreEqual(serializer.ResponseToLoadTenders[i].B1.ReservationActionCode, deserializer.ResponseToLoadTenders[i].B1.ReservationActionCode);
                Assert.AreEqual(serializer.ResponseToLoadTenders[i].B1.ShipmentIdentificationNumber, deserializer.ResponseToLoadTenders[i].B1.ShipmentIdentificationNumber);
                Assert.AreEqual(serializer.ResponseToLoadTenders[i].B1.StandardCarrierAlphaCode, deserializer.ResponseToLoadTenders[i].B1.StandardCarrierAlphaCode);

                if (serializer.ResponseToLoadTenders[i].N9 != null)
                {
                    N9SegmentValidate.Validate(serializer.ResponseToLoadTenders[i].N9, deserializer.ResponseToLoadTenders[i].N9);
                }

                if (serializer.ResponseToLoadTenders[i].StopOffDetails != null)
                {
                    for (int j = 0; j < serializer.ResponseToLoadTenders[i].StopOffDetails.Count; j++)
                    {
                        N9Segment n9Segment = serializer.ResponseToLoadTenders[i].StopOffDetails[j].N9;
                        if (n9Segment != null)
                        {
                            N9SegmentValidate.Validate(serializer.ResponseToLoadTenders[i].StopOffDetails[j].N9, deserializer.ResponseToLoadTenders[i].StopOffDetails[j].N9);
                        }
                        S5Segment s5Segment = serializer.ResponseToLoadTenders[i].StopOffDetails[j].S5;
                        if (s5Segment != null)
                        {
                            S5SegmentValidate.Validate(s5Segment, deserializer.ResponseToLoadTenders[i].StopOffDetails[j].S5);
                        }
                    }
                }                

                if (serializer.ResponseToLoadTenders[i].N7 != null)
                {
                    Assert.AreEqual(serializer.ResponseToLoadTenders[i].N7.EquipmentInitial, deserializer.ResponseToLoadTenders[i].N7.EquipmentInitial);
                    Assert.AreEqual(serializer.ResponseToLoadTenders[i].N7.EquipmentNumber, deserializer.ResponseToLoadTenders[i].N7.EquipmentNumber);
                }

                // SE test complited
                Assert.AreEqual(serializer.ResponseToLoadTenders[i].SE.NumberOfIncludedSegments, deserializer.ResponseToLoadTenders[i].SE.NumberOfIncludedSegments);
                Assert.AreEqual(serializer.ResponseToLoadTenders[i].SE.NumberTransactionSetControlNumber, deserializer.ResponseToLoadTenders[i].SE.NumberTransactionSetControlNumber);

            }


            // GEC test complited
            Assert.AreEqual(serializer.GE.NumberOfTransactionsSetsIncluded, deserializer.GE.NumberOfTransactionsSetsIncluded);
            Assert.AreEqual(serializer.GE.NumberGroupControlNumber, deserializer.GE.NumberGroupControlNumber);

            // IEA test complited
            Assert.AreEqual(serializer.IEA.NumberOfIncludedFunctionalGroups, deserializer.IEA.NumberOfIncludedFunctionalGroups);
            Assert.AreEqual(serializer.IEA.QuantityInterchangeControlNumber, deserializer.IEA.QuantityInterchangeControlNumber);
        }

        [TestMethod]
        public void TestE990FromFile() {            
            Edi990Model edi990Model = default(Edi990Model);
            using (Stream reader = File.OpenRead("990sample.txt"))            
            {
                edi990Model = new EdiDeserialize().Deserialize<Edi990Model>(new StreamReader(reader));
            }

            Assert.AreEqual(edi990Model.ResponseToLoadTenders.Count, 1);
            Assert.AreEqual(edi990Model.ResponseToLoadTenders[0].N9.ReferenceIdentificationQualifier, "CN");
            Assert.AreEqual(edi990Model.ResponseToLoadTenders[0].N9.ReferenceIdentification, "5591245458");

            Assert.AreEqual(edi990Model.ResponseToLoadTenders[0].B1.StandardCarrierAlphaCode, "UFLB");
            Assert.AreEqual(edi990Model.ResponseToLoadTenders[0].B1.ShipmentIdentificationNumber, "43919999");
            Assert.AreEqual(edi990Model.ResponseToLoadTenders[0].B1.Date, new System.DateTime(2019, 04, 18).Date);
            Assert.AreEqual(edi990Model.ResponseToLoadTenders[0].B1.ReservationActionCode, "A");                   
        }

        [TestMethod]
        public void TestE850FromFile() {
            Edi850Model edi850Model = default(Edi850Model);
            using (Stream reader = File.OpenRead("850sample.txt")) {
                edi850Model = new EdiDeserialize().Deserialize<Edi850Model>(new StreamReader(reader));
            }

            /*Assert.AreEqual(edi850Model.ResponseToLoadTenders.Count, 1);
            Assert.AreEqual(edi850Model.ResponseToLoadTenders[0].N9.ReferenceIdentificationQualifier, "CN");
            Assert.AreEqual(edi850Model.ResponseToLoadTenders[0].N9.ReferenceIdentification, "5591245458");

            Assert.AreEqual(edi850Model.ResponseToLoadTenders[0].B1.StandardCarrierAlphaCode, "UFLB");
            Assert.AreEqual(edi850Model.ResponseToLoadTenders[0].B1.ShipmentIdentificationNumber, "43919999");
            Assert.AreEqual(edi850Model.ResponseToLoadTenders[0].B1.Date, new System.DateTime(2019, 04, 18).Date);
            Assert.AreEqual(edi850Model.ResponseToLoadTenders[0].B1.ReservationActionCode, "A");*/
        }
    }
}