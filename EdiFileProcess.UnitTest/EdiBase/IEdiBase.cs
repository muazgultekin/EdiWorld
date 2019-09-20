using EdiFileProcess.Models;

namespace EdiFileProcess.UnitTest.EdiBase
{
    internal interface IEdiBase
    {
        void Serializer(object objectType);
        object Deserialize();
    }
}
