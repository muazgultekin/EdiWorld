using EdiFileProcess.Models.Segments;

namespace EdiFileProcess.UnitTest.MainClasses
{
    internal class IEAClass
    {
        public static IEASegment Get()
        {
            return new IEASegment
            {
                NumberOfIncludedFunctionalGroups = "1",
                QuantityInterchangeControlNumber = 14
            };
        }
    }
}
