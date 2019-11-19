using EdiFileProcess.Models.X12;
using EdiFileProcess.UnitTest.EdiBase;
using System.IO;

namespace EdiFileProcess.UnitTest.E990 {
    internal class E990Class : IEdiBase
    {
        public void Serializer(object objectType)
        {
            using (StreamWriter streamWriter = new StreamWriter("E990.edi"))
            {
                new EdiSerializer().Serialize(streamWriter, objectType);
                streamWriter.Close();
            }                
        }
        public object Deserialize()
        {
            Edi990Model objectType = null;
            using (Stream fs = File.OpenRead("E990.edi"))
            {
                objectType = new EdiDeserialize().Deserialize<Edi990Model>(new StreamReader(fs));
            }
            return objectType;
        }        
    }
}
