using EdiFileProcess.Attributes;
using EdiFileProcess.Enums;
using System.IO;
using System.Reflection;

namespace EdiFileProcess
{
    public class EdiSerializer
    {
        public void Serialize(StreamWriter streamWriter, object objectType)
        {            
            EdiAttribute ediAttribute = (EdiAttribute)objectType.GetType().GetCustomAttribute(typeof(EdiAttribute));
            switch (ediAttribute.EdiType)
            {
                case EdiTypes.Edi856WithEquipment:
                case EdiTypes.Edi856:                    
                    EdiWriteObject.Write(streamWriter, objectType);
                    break;
                default:
                    EdiWriteObject.Write(streamWriter, objectType);
                    break;
            }            
        }                                            
    }
}
