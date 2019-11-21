using EdiFileProcess.Utilities;
using System;

namespace EdiFileProcess {
    public class DESADVDeserialize {
        internal static object DeserializeInternal(string[] readToEndLines, Type objectType) {
            object dataObject = Activator.CreateInstance(objectType);
            readToEndLines = EdiFactPropertyClass.IsNotGenericType(readToEndLines, dataObject);
            readToEndLines = EdiFactPropertyClass.IsGenericType(readToEndLines, dataObject);
            return dataObject;            
        }
    }
}
