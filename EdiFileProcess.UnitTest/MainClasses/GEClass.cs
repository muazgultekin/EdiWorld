using EdiFileProcess.Models.Segments;

namespace EdiFileProcess.UnitTest.MainClasses
{
    internal class GEClass
    {
        public static GESegment Get()
        {
            return new GESegment
            {
                NumberOfTransactionsSetsIncluded = "1",
                NumberGroupControlNumber = "3"
            };
        }
    }
}
