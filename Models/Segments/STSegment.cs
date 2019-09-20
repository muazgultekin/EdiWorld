using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// Transaction Set Header
    /// </summary>
    [EdiSegment(Path = "ST")]
    public class STSegment
    {        
        [EdiValue("X(3)", Order = 0, Description = "Code uniquely identifying a Transaction Set.")]
        public string TransactionSetIdentifierCode { get; set; }

        [EdiValue("X(4)", Order = 1, Description = "Identifying control number that must be unique within the transaction set functional group assigned by the originator for a transaction set.")]
        public string TransactionSetControlNumber  { get; set; }
    }
}
