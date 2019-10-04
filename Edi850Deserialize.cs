using EdiFileProcess.Attributes;
using EdiFileProcess.Utilities;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EdiFileProcess {
    internal class Edi850Deserialize {
        public T Deserialize<T>(StreamReader reader) {
            return (T)Deserialize(reader, typeof(T));
        }

        public object Deserialize(StreamReader reader, Type objectType) {
            string ReadToEnd = reader.ReadToEnd();
            string[] ReadToEndLines = ReadToEnd.Replace("\r", string.Empty).Replace("\n", string.Empty).Split('~');
            ReadToEndLines = ReadToEndLines.Where(w => w != string.Empty).ToArray();
            EdiAttribute ediAttribute = objectType.GetCustomAttribute<EdiAttribute>();
            if (ediAttribute == null)
                throw new Exception("Deserialize edilecek obje Modeli hangi Edi dosyası için işlem taypılacağı tanımlanmamış!");
            return DeserializeInternal(ReadToEndLines, objectType);
        }

        public static object DeserializeInternal(string[] readToEndLines, Type objectType) {
            object dataObject = Activator.CreateInstance(objectType);
            readToEndLines = PropertyClass.IsNotGenericType(readToEndLines, dataObject);
            readToEndLines = PropertyClass.IsGenericType(readToEndLines, dataObject);
            return dataObject;
        }
    }
}