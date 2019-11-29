using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Utilities;
using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EdiFileProcess.Rev01 {
    public class EdiFactDeserialize {
        public T Deserialize<T>(StreamReader reader) {
            return (T)Deserialize(reader, typeof(T));
        }
        public object Deserialize(StreamReader reader, Type objectType) {
            string ReadToEnd = reader.ReadToEnd();
            string[] ReadToEndLines = ReadToEnd.Replace("\r", string.Empty).Replace("\n", string.Empty).Split('\'');
            ReadToEndLines = ReadToEndLines.Where(where => where != string.Empty).ToArray();
            if (ReadToEndLines[0].Substring(0, 3) == "UNA")
                ReadToEndLines = ReadToEndLines.Skip(1).ToArray();
            EdiFactAttribute ediAttribute = objectType.GetCustomAttribute<EdiFactAttribute>();
            if (ediAttribute == null)
                throw new Exception("Deserialize edilecek obje Modeli hangi Edi dosyası için işlem tyapılacağı tanımlanmamış!");
            switch (ediAttribute.EdiFactType) {
                case Enums.EdiFactTypes.DESADV:
                case Enums.EdiFactTypes.HANMOV:
                    return DeserializeInternal(ref ReadToEndLines, objectType);
                default:
                    throw new Exception("EdiFactTypes are defined.");
            }
        }

        public object DeserializeInternal(ref string[] ReadToEndLines, Type objectType) {
            object dataObject = Activator.CreateInstance(objectType);
            PropertyInfo[] propertyInfos = PropertyClass.GetPropertyInfos(dataObject.GetType().GetProperties(), typeof(EdiSegmentAttribute));
            if (propertyInfos.Length == 0) {
                propertyInfos = PropertyClass.GetPropertyInfos(dataObject.GetType().GetProperties(), typeof(EdiOrderAttribute));
                for (int i = 0; i < propertyInfos.Length; i++) {
                    PropertyInfo propertyInfo = propertyInfos[i];
                    if (propertyInfo.PropertyType == typeof(string)) {
                        var a = ReadToEndLines[0].Split('+');
                        if (a.Length > i) {
                            propertyInfo.SetValue(dataObject, a[i]);
                        }
                    }
                    else {
                        object dataObject2 = Activator.CreateInstance(propertyInfo.PropertyType);
                        PropertyInfo[] PropertyInfoIsType = PropertyClass.GetPropertyInfos(dataObject2.GetType().GetProperties(), typeof(EdiOrderAttribute));
                        IsType(ReadToEndLines[0].Split('+')[1].Split(':'), dataObject2, PropertyInfoIsType);
                        propertyInfo.SetValue(dataObject, dataObject2, null);
                        ReadToEndLines = ReadToEndLines.Skip(1).ToArray();
                    }
                }
            }
            else {
                foreach (PropertyInfo propertyInfo in propertyInfos) {
                    if (propertyInfo.PropertyType.IsGenericType) {
                        object dataObject2 = Activator.CreateInstance(propertyInfo.PropertyType);
                        IList list = (IList)dataObject2;
                        Type GenericArgument = propertyInfo.PropertyType.GetGenericArguments()[0];
                        EdiSegmentAttribute ediSegmentAttribute = (EdiSegmentAttribute)GenericArgument.GetCustomAttribute(typeof(EdiSegmentAttribute));
                        if (ediSegmentAttribute == null) {
                            PropertyInfo[] propertyInfosGeneric = PropertyClass.GetPropertyInfos(GenericArgument.GetProperties(), typeof(EdiSegmentAttribute));
                            EdiSegmentAttribute ediSegmentAttributePropertyType = (EdiSegmentAttribute)propertyInfosGeneric[0].PropertyType.GetCustomAttribute(typeof(EdiSegmentAttribute));
                            if (ediSegmentAttributePropertyType.IsLoop) {
                                while (ReadToEndLines.Count() > 1) {
                                    object obj = DeserializeInternal(ref ReadToEndLines, GenericArgument);
                                    list.Add(obj);
                                }                                
                            }
                            else {
                                object obj = DeserializeInternal(ref ReadToEndLines, GenericArgument);
                                list.Add(obj);
                            }
                        }
                        else {
                            while (ediSegmentAttribute.Path == ReadToEndLines[0].Substring(0, 3)) {
                                object obj = DeserializeInternal(ref ReadToEndLines, GenericArgument);
                                list.Add(obj);                                
                            }
                        }
                        propertyInfo.SetValue(dataObject, list, null);
                    }
                    else {
                        object dataObject2 = Activator.CreateInstance(propertyInfo.PropertyType);
                        PropertyInfo[] PropertyInfoIsType = PropertyClass.GetPropertyInfos(dataObject2.GetType().GetProperties(), typeof(EdiOrderAttribute));
                        ReadToEndLines = IsType(ReadToEndLines, dataObject2, PropertyInfoIsType);
                        propertyInfo.SetValue(dataObject, dataObject2, null);
                    }
                }
            }
            return dataObject;
        }

        private string[] IsType(string[] ReadToEndLines, object dataObject, PropertyInfo[] PropertyInfos) {
            if (ReadToEndLines.Length == 0) return ReadToEndLines;
            EdiSegmentAttribute ediSegmentAttribute = (EdiSegmentAttribute)dataObject.GetType().GetCustomAttribute(typeof(EdiSegmentAttribute));
            if ((ediSegmentAttribute != null) &&(ediSegmentAttribute.Path != ReadToEndLines[0].Substring(0,3))) return ReadToEndLines;
            string[] Lines = null;
            if (ReadToEndLines[0].Contains("+")) {
                Lines = ReadToEndLines[0].Split('+');
            }
            else {
                Lines = ReadToEndLines;
            }
                
            if ((ediSegmentAttribute != null) && (Lines[0] == ediSegmentAttribute.Path)) {
                ReadToEndLines = ReadToEndLines.Skip(1).ToArray();
                Lines = Lines.Skip(1).ToArray();
            }
            for (int i = 0; i < Lines.Length; i++) {
                PropertyInfo propertyInfo = PropertyInfos[i];
                EdiOrderAttribute EdiOrderAttribute = (EdiOrderAttribute)propertyInfo.GetCustomAttribute(typeof(EdiOrderAttribute));
                if ((EdiOrderAttribute != null) && (EdiOrderAttribute.IsDetail)) {
                    object dataObject3 = Activator.CreateInstance(propertyInfo.PropertyType);
                    PropertyInfo[] PropertyInfosTwo = PropertyClass.GetPropertyInfos(dataObject3.GetType().GetProperties(), typeof(EdiOrderAttribute));
                    IsType(Lines[i].Split(':'), dataObject3, PropertyInfosTwo);
                    propertyInfo.SetValue(dataObject, dataObject3, null);
                }
                else {
                    if (propertyInfo.PropertyType == typeof(DateTime)) {
                        DateTime dateTime = DateTime.ParseExact(Lines[i], EdiOrderAttribute.Format, CultureInfo.InvariantCulture);
                        propertyInfo.SetValue(dataObject, dateTime);
                    }
                    else if (propertyInfo.PropertyType == typeof(int)) {
                        propertyInfo.SetValue(dataObject, Convert.ToInt32(Lines[i]));
                    }
                    else if (propertyInfo.PropertyType == typeof(TimeSpan)) {
                        TimeSpan timeSpan = TimeSpan.ParseExact(Lines[i], EdiOrderAttribute.Format, CultureInfo.InvariantCulture);
                        propertyInfo.SetValue(dataObject, timeSpan);
                    }
                    else {
                        propertyInfo.SetValue(dataObject, Lines[i]);
                    }
                }
            }
            return ReadToEndLines;
        }
    }
}