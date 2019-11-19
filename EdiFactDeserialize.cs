using EdiFileProcess.Attributes;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EdiFileProcess {
    public class EdiFactDeserialize {
        public T Deserialize<T>(StreamReader reader) {
            return (T)Deserialize(reader, typeof(T));
        }

        public object Deserialize(StreamReader reader, Type objectType) {
            string ReadToEnd = reader.ReadToEnd();
            string[] ReadToEndLines = ReadToEnd.Replace("\r", string.Empty).Replace("\n", string.Empty).Split('\'');
            ReadToEndLines = ReadToEndLines.Where(w => w != string.Empty).ToArray();
            EdiFactAttribute ediAttribute = objectType.GetCustomAttribute<EdiFactAttribute>();
            if (ediAttribute == null)
                throw new Exception("Deserialize edilecek obje Modeli hangi Edi dosyası için işlem tyapılacağı tanımlanmamış!");
            switch (ediAttribute.EdiFactType) {
                case Enums.EdiFactTypes.DESADV:
                    return DESADVDeserialize.DeserializeInternal(ReadToEndLines, objectType);
                default:
                    throw new Exception("EdiFactTypes tanımlanmamış");
            }
        }
    }
}