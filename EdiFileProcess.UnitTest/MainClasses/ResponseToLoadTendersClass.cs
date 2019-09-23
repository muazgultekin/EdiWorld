using EdiFileProcess.Models.Edi990;
using EdiFileProcess.Models.Segments;
using System;
using System.Collections.Generic;

namespace EdiFileProcess.UnitTest.MainClasses
{
    internal class ResponseToLoadTendersClass
    {
        public static List<ResponseToLoadTender> Get()
        {
            List<ResponseToLoadTender> responseToLoadTenders = new List<ResponseToLoadTender>();
            responseToLoadTenders.Add(new ResponseToLoadTender
            {
                ST = GetST(),
                B1 = GetB1(),
                N9 = GetN9(),
                SE = GetSE()
            });
            return responseToLoadTenders;
        }        

        private static STSegment GetST()
        {
            return new STSegment
            {
                TransactionSetIdentifierCode = "990",
                TransactionSetControlNumber = "0001"
            };           
        }

        private static B1Segment GetB1()
        {           
            return new B1Segment
            {
                StandardCarrierAlphaCode = "UFLB",
                ShipmentIdentificationNumber = "43919999",
                Date = new DateTime(2019, 04, 18),
                ReservationActionCode = "A"
            };
        }

        private static N9Segment GetN9()
        {
            return new N9Segment
            {
                ReferenceIdentificationQualifier = "CN",
                ReferenceIdentification = "5591245458"
            };
        }

        private static SESegment GetSE()
        {
            return new SESegment
            {
                NumberOfIncludedSegments = "4",
                NumberTransactionSetControlNumber = 1
            };
        }
    }
}
