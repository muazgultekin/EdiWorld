using EdiFileProcess.Attributes;
using System;

namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// Beginning Segment for Purchase Order 
    /// </summary>
    [EdiSegment(Path = "BEG")]
    public class BEGSegment
    {
        [EdiValue("X(2)", Order = 0, Path = "BEG", Description = "Code identifying purpose of transaction set.")]
        public string TransactionSetPurposeCode { get; set; }

        [EdiValue("X(2)", Order = 1, Path = "BEG", Description = "Code specifying the type of Purchase Order.")]
        public string PurchaseOrderTypeCode { get; set; }

        [EdiValue("X(22)", Order = 2, Path = "BEG", Description = "Identifying number for Purchase Order assigned by the orderer/purchaser.")]
        public string PurchaseOrderNumber { get; set; }

        [EdiValue("X(30)", Order = 3, Path = "BEG", Description = "Number identifying a release against a Purchase Order previously placed by the parties involved in the transaction.")]
        public string ReleaseNumber { get; set; }        

        [EdiValue("9(8)", Order = 4, Format = "yyyyMMdd", Path = "BEG", Description = "Date expressed as CCYYMMDD.")]        
        public DateTime Date { get; set; }

        [EdiValue("X(30)", Order = 5, Path = "BEG", Description = "Contract number.")]
        public string ContractNumber { get; set; }
    }
}
