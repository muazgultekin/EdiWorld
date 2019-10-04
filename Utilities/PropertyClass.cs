using EdiFileProcess.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EdiFileProcess.Utilities {
    public class PropertyClass {
        public static string[] IsNotGenericType(string[] readToEndLines, object dataObject) {
            Type dataObjectType = dataObject.GetType();

            PropertyInfo[] propertyInfos = dataObjectType.GetProperties();
            try {
                propertyInfos = dataObjectType.GetProperties().OrderBy(p => p.GetCustomAttributes().OfType<EdiSegmentAttribute>().First().Order).ToArray();
            }
            catch {
                propertyInfos = dataObjectType.GetProperties().OrderBy(p => p.GetCustomAttributes().OfType<EdiValueAttribute>().First().Order).ToArray();
            }

            foreach (PropertyInfo propertyInfo in propertyInfos) {
                bool IsHave = true;
                Type propertyType = propertyInfo.PropertyType;
                EdiSegmentAttribute eEdiSegmentAttribute = (EdiSegmentAttribute)propertyInfo.GetCustomAttribute(typeof(EdiSegmentAttribute));
                if ((eEdiSegmentAttribute != null) && (eEdiSegmentAttribute.SequenceEnd != null)) {
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
                else {
                    EdiValueAttribute ediValueAttribute = (EdiValueAttribute)propertyInfo.GetCustomAttribute(typeof(EdiValueAttribute));
                    if (ediValueAttribute != null) {
                        if (ediValueAttribute != null) {
                            if (readToEndLines.Length > 0) {
                                string[] parts = readToEndLines[0].Split('*');
                                SetPropertyInfo(parts, dataObject);
                                readToEndLines = readToEndLines.Where(w => w != readToEndLines[0]).ToArray();
                            }
                        }
                    }
                }
                if (!propertyType.IsGenericType && IsHave) {
                    if (readToEndLines.Length > 0)
                        readToEndLines = SetPropertyInfo(readToEndLines, dataObject, propertyInfo, propertyType);
                }
            }
            return readToEndLines;
        }
        public static string[] IsGenericType(string[] readToEndLines, object dataObject) {
            Type dataObjectType = dataObject.GetType();

            PropertyInfo[] propertyInfos = dataObjectType.GetProperties();
            try {
                propertyInfos = dataObjectType.GetProperties().OrderBy(p => p.GetCustomAttributes().OfType<EdiSegmentAttribute>().First().Order).ToArray();
            }
            catch {
                propertyInfos = dataObjectType.GetProperties().OrderBy(p => p.GetCustomAttributes().OfType<EdiValueAttribute>().First().Order).ToArray();
            }

            foreach (PropertyInfo propertyInfo in propertyInfos) {
                Type propertyType = propertyInfo.PropertyType;
                if (propertyType.IsGenericType) {
                    EdiSegmentAttribute eEdiSegmentAttribute = (EdiSegmentAttribute)propertyInfo.GetCustomAttribute(typeof(EdiSegmentAttribute));
                    Type GenericArgument = propertyInfo.PropertyType.GetGenericArguments()[0];
                    List<string[]> bloks = new List<string[]>();
                    List<string> tempBlok = new List<string>();
                    foreach (string readToEndLine in readToEndLines) {
                        if (eEdiSegmentAttribute.SequenceEnd == null) {

                        }
                        else {
                            if ((tempBlok.Count > 0) && (readToEndLine.StartsWith(eEdiSegmentAttribute.SequenceEnd) | readToEndLine.StartsWith(eEdiSegmentAttribute.Path))) {
                                if (eEdiSegmentAttribute.IsWithSequenceEnd) {
                                    tempBlok.Add(readToEndLine);
                                    bloks.Add(tempBlok.ToArray());
                                    tempBlok.Clear();
                                }
                                else {
                                    bloks.Add(tempBlok.ToArray());
                                    //readToEndLines = readToEndLines.Skip(tempBlok.Count).ToArray();                                
                                    tempBlok.Clear();
                                    tempBlok.Add(readToEndLine);
                                }
                            }
                            else {
                                tempBlok.Add(readToEndLine);
                            }
                        }
                    }
                    if (tempBlok.Count > 0) {
                        bloks.Add(tempBlok.ToArray());
                        tempBlok.Clear();
                    }
                    object instance = Activator.CreateInstance(propertyInfo.PropertyType);
                    IList list = (IList)instance;
                    if (bloks.Count == 0) {
                        bool IsValueType = true;
                        PropertyInfo[] propertiesForValues = GenericArgument.GetProperties();
                        foreach (PropertyInfo propertiesForValue in propertiesForValues) {
                            IsValueType &= propertiesForValue.GetCustomAttribute<EdiValueAttribute>() != null;
                        }

                        if (!IsValueType) {
                            object newObject = Edi850Deserialize.DeserializeInternal(readToEndLines, GenericArgument);
                            list.Add(newObject);
                        }
                        else {
                            foreach (PropertyInfo propertiesForValue in propertiesForValues) {
                                if (readToEndLines.Length > 0) {
                                    EdiValueAttribute EdiValueAttributeValue = propertiesForValue.GetCustomAttribute<EdiValueAttribute>();
                                    string[] ValueResults = readToEndLines.Where(x => x.Contains(EdiValueAttributeValue.Path)).ToArray();
                                    foreach (string ValueResult in ValueResults) {
                                        object newObject = Edi850Deserialize.DeserializeInternal(new[] { ValueResult }, GenericArgument);
                                        list.Add(newObject);
                                        readToEndLines = readToEndLines.Where(w => w != ValueResult).ToArray();
                                    }
                                }
                            }
                        }
                    }
                    else {
                        foreach (string[] items in bloks) {
                            if (items[0].StartsWith(eEdiSegmentAttribute.Path)) {
                                object newObject = Edi850Deserialize.DeserializeInternal(items, GenericArgument);
                                list.Add(newObject);
                            }
                        }
                    }
                    propertyInfo.SetValue(dataObject, list, null);
                }
            }
            return readToEndLines;
        }
        public static string[] SetPropertyInfo(string[] ReadToEndLines, object dataObject, PropertyInfo propertyInfo, Type propertyType) {
            EdiSegmentAttribute eEdiSegmentAttribute = (EdiSegmentAttribute)propertyType.GetCustomAttribute(typeof(EdiSegmentAttribute));
            foreach (string readToEndLine in ReadToEndLines) {
                string[] parts = readToEndLine.Split('*');
                string master = parts[0];
                if (eEdiSegmentAttribute != null) {
                    if (eEdiSegmentAttribute.Path == master) {
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
        public static void SetPropertyInfo(string[] parts, object IsClassObject) {
            PropertyInfo[] propertyInfoTypes = IsClassObject.GetType().GetProperties().OrderBy(p => p.GetCustomAttributes().OfType<EdiValueAttribute>().First().Order).ToArray();
            foreach (PropertyInfo propertyInfoType in propertyInfoTypes) {
                #region
                object[] ediValueAttributes = propertyInfoType.GetCustomAttributes(typeof(EdiValueAttribute), true);
                EdiValueAttribute ediValueAttribute = (EdiValueAttribute)ediValueAttributes[0];
                if ((ediValueAttribute.Order + 1) >= parts.Length) {
                    break;
                }
                if (ediValueAttributes.Length > 1) {
                    string formatString = ediValueAttribute.Format + ((EdiValueAttribute)ediValueAttributes[1]).Format;
                    string sample = parts[ediValueAttribute.Order + 1] + parts[ediValueAttribute.Order + 2];
                    DateTime dt = DateTime.ParseExact(sample, formatString, null);
                    propertyInfoType.SetValue(IsClassObject, dt);
                }
                else {
                    if (ediValueAttribute.Picture.Kind == Enums.PictureKind.Numeric) {
                        if (propertyInfoType.PropertyType.IsGenericType) {
                            string result = parts[ediValueAttribute.Order + 1].ToString();
                            if (result != string.Empty) {
                                bool boolValue = result == "0" ? false : true;
                                propertyInfoType.SetValue(IsClassObject, boolValue);
                            }
                        }
                        else {
                            if (parts[ediValueAttribute.Order + 1] != string.Empty) {
                                if (propertyInfoType.PropertyType.Name == "Decimal") {
                                    Decimal decimalValue = Convert.ToDecimal(parts[ediValueAttribute.Order + 1].ToString());
                                    propertyInfoType.SetValue(IsClassObject, decimalValue);
                                }
                                else if (propertyInfoType.PropertyType.Name == "DateTime") {
                                    string s = parts[ediValueAttribute.Order + 1];
                                    DateTime dt = DateTime.ParseExact(s, ediValueAttribute.Format, null);
                                    propertyInfoType.SetValue(IsClassObject, dt);
                                }
                                else {
                                    propertyInfoType.SetValue(IsClassObject, Convert.ToInt32(parts[ediValueAttribute.Order + 1]));
                                }
                            }
                        }
                    }
                    else {
                        if (propertyInfoType.PropertyType.IsGenericType) {
                            propertyInfoType.SetValue(IsClassObject, '\0');
                        }
                        else {
                            if (propertyInfoType.PropertyType.Name == "Decimal") {
                                if (parts[ediValueAttribute.Order + 1] != string.Empty) {
                                    decimal a = Convert.ToDecimal(parts[ediValueAttribute.Order + 1].ToString());
                                    propertyInfoType.SetValue(IsClassObject, a);
                                }
                            }
                            else {
                                propertyInfoType.SetValue(IsClassObject, parts[ediValueAttribute.Order + 1]);
                            }
                        }
                    }
                }
                #endregion
            }
        }
    }
}