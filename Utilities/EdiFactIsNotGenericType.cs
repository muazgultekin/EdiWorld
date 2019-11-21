using EdiFileProcess.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace EdiFileProcess.Utilities {
    public class EdiFactIsNotGenericType {
        public static string[] IsNotGenericType(string[] readToEndLines, object dataObject) {
            if (readToEndLines.Length == 0) return readToEndLines;
            Type dataObjectType = dataObject.GetType();
            PropertyInfo[] propertyInfos = dataObjectType.GetProperties();
            try {
                propertyInfos = dataObjectType.GetProperties().OrderBy(p => p.GetCustomAttributes().OfType<EdiSegmentAttribute>().First().Order).ToArray();
            }
            catch {
                propertyInfos = dataObjectType.GetProperties().OrderBy(p => p.GetCustomAttributes().OfType<EdiOrderAttribute>().First().Order).ToArray();
            }
            for (int i = 0; i < propertyInfos.Length; i++) {
                bool IsHave = true;
                Type propertyType = propertyInfos[i].PropertyType;
                EdiSegmentAttribute eEdiSegmentAttribute = (EdiSegmentAttribute)propertyInfos[i].GetCustomAttribute(typeof(EdiSegmentAttribute));
                if ((eEdiSegmentAttribute != null) && (eEdiSegmentAttribute.SequenceEnd != null)) {
                    if (!propertyType.IsGenericType) {
                        EdiSegmentAttribute eEdiSegmentAttributeproperty = (EdiSegmentAttribute)propertyType.GetCustomAttribute(typeof(EdiSegmentAttribute));
                        if (eEdiSegmentAttributeproperty != null) {
                            IsHave = false;
                            foreach (string item in readToEndLines) {
                                if (item.StartsWith(eEdiSegmentAttribute.SequenceEnd)) {
                                    break;
                                }
                                else if (item.StartsWith(eEdiSegmentAttributeproperty.Path)) {
                                    IsHave = true;
                                }
                            }
                        }
                    }
                }
                else {
                    EdiValueAttribute ediValueAttribute = (EdiValueAttribute)propertyInfos[i].GetCustomAttribute(typeof(EdiValueAttribute));
                    if (ediValueAttribute != null) {
                        if (ediValueAttribute != null) {
                            if (readToEndLines.Length > 0) {
                                string[] parts = readToEndLines[0].Split('+');
                                if (ediValueAttribute.Path == parts[0]) {
                                    parts = parts.Skip(1).ToArray();
                                    if (parts.Length == 1) {
                                        SetPropertyInfo(parts[0].Split(':'), dataObject);
                                        readToEndLines = readToEndLines.Where(w => w != readToEndLines[0]).ToArray();
                                    }   
                                    else {
                                        SetPropertyInfo(parts, dataObject);
                                        readToEndLines = readToEndLines.Where(w => w != readToEndLines[0]).ToArray();
                                    }
                                }
                            }
                        }
                    }
                }
                if (!propertyType.IsGenericType && IsHave) {
                    if (readToEndLines.Length > 0)
                        readToEndLines = SetPropertyInfo(readToEndLines, dataObject, propertyInfos[i], propertyType);
                }
            }
            return readToEndLines;
        }

        private static string[] SetPropertyInfo(string[] ReadToEndLines, object dataObject, PropertyInfo propertyInfo, Type propertyType) {
            EdiSegmentAttribute eEdiSegmentAttribute = (EdiSegmentAttribute)propertyType.GetCustomAttribute(typeof(EdiSegmentAttribute));
            foreach (string readToEndLine in ReadToEndLines) {
                string[] parts = readToEndLine.Split('+');
                string master = parts[0];
                if (eEdiSegmentAttribute != null) {
                    if (eEdiSegmentAttribute.Path == master) {
                        parts = parts.Skip(1).ToArray();
                        object IsClassObject = Activator.CreateInstance(propertyType);                        
                        SetPropertyInfo(parts, IsClassObject);
                        propertyInfo.SetValue(dataObject, IsClassObject);
                        ReadToEndLines = ReadToEndLines.Where(w => w != readToEndLine).ToArray();
                        break;
                    }
                }
            }
            return ReadToEndLines;
        }

        private static void SetPropertyInfo(string[] unbs, object IsClassObject) {
            if ((unbs.Length == 1) && (unbs[0].Contains(":"))) {
                unbs = unbs[0].Split(':');
            }

            var a = IsClassObject.GetType().GetProperties();
            PropertyInfo[] propertyInfoTypes = IsClassObject.GetType().GetProperties().OrderBy(p => p.GetCustomAttributes().OfType<EdiOrderAttribute>().First().Order).ToArray();
            if (propertyInfoTypes.Length != unbs.Length) {
                string aaa = string.Empty;
            }
            for (int i = 0; i < unbs.Length; i++) {
                Type propertyType = propertyInfoTypes[i].PropertyType;
                if (!propertyType.IsGenericType) {
                    EdiValueAttribute ediValueAttribute = (EdiValueAttribute)propertyInfoTypes[i].GetCustomAttribute(typeof(EdiValueAttribute));
                    if (propertyInfoTypes[i].PropertyType.Name == "Int32") {
                        if ((unbs[i] != null) && (unbs[i].Length > 0))
                            propertyInfoTypes[i].SetValue(IsClassObject, Convert.ToInt32(unbs[i]));
                    }
                    else if (propertyInfoTypes[i].PropertyType.Name == "String") {
                        propertyInfoTypes[i].SetValue(IsClassObject, unbs[i]);
                    }
                    else if (propertyInfoTypes[i].PropertyType.Name == "DateTime") {
                        string sample = unbs[i].PadRight(12, '0');
                        DateTime dt = DateTime.ParseExact(sample, ediValueAttribute.Format, null);
                        propertyInfoTypes[i].SetValue(IsClassObject, dt);
                    }
                    else {
                        object IsClassObject2 = Activator.CreateInstance(propertyType);
                        SetPropertyInfo2(unbs[i].Split(':'), IsClassObject2);
                        propertyInfoTypes[i].SetValue(IsClassObject, IsClassObject2);
                    }
                }
                else {
                    object IsClassObject2 = Activator.CreateInstance(propertyType);
                    SetPropertyInfo2(unbs[i].Split(':'), IsClassObject2);
                    propertyInfoTypes[i].SetValue(IsClassObject, IsClassObject2);
                }
            }
        }

        private static void SetPropertyInfo2(string[] unbs, object IsClassObject) {
            PropertyInfo[] propertyInfoTypes = IsClassObject.GetType().GetProperties().OrderBy(p => p.GetCustomAttributes().OfType<EdiValueAttribute>().First().Order).ToArray();
            for (int i = 0; i < propertyInfoTypes.Length; i++) {
                EdiValueAttribute ediValueAttribute = (EdiValueAttribute)propertyInfoTypes[i].GetCustomAttribute(typeof(EdiValueAttribute));
                if (propertyInfoTypes[i].PropertyType.Name == "Int32") {
                    propertyInfoTypes[i].SetValue(IsClassObject, Convert.ToInt32(unbs[i]));
                }
                else if (propertyInfoTypes[i].PropertyType.Name == "DateTime") {
                    DateTime dt = DateTime.ParseExact(unbs[i], ediValueAttribute.Format, null);
                    propertyInfoTypes[i].SetValue(IsClassObject, dt);
                }
                else if (propertyInfoTypes[i].PropertyType.Name == "TimeSpan") {
                    TimeSpan.TryParseExact(unbs[i], ediValueAttribute.Format, null, out TimeSpan timeSpan);
                    propertyInfoTypes[i].SetValue(IsClassObject, timeSpan);
                }
                else {
                    propertyInfoTypes[i].SetValue(IsClassObject, unbs[i]);
                }
            }
        }
    }
}
