using EdiFileProcess.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EdiFileProcess.Utilities {
    public class EdiFactIsGenericType {
        public static string[] IsGenericType(string[] readToEndLines, object dataObject) {
            if (readToEndLines.Length == 0) return null;
            Type dataObjectType = dataObject.GetType();
            PropertyInfo[] propertyInfos = dataObjectType.GetProperties();
            try {
                propertyInfos = dataObjectType.GetProperties().OrderBy(p => p.GetCustomAttributes().OfType<EdiSegmentAttribute>().First().Order).ToArray();
            }
            catch {
                propertyInfos = dataObjectType.GetProperties().OrderBy(p => p.GetCustomAttributes().OfType<EdiOrderAttribute>().First().Order).ToArray();
            }
            for (int i = 0; i < propertyInfos.Length; i++) {
                Type propertyType = propertyInfos[i].PropertyType;
                if (propertyType.IsGenericType) {
                    EdiSegmentAttribute eEdiSegmentAttribute = (EdiSegmentAttribute)propertyInfos[i].GetCustomAttribute(typeof(EdiSegmentAttribute));
                    Type GenericArgument = propertyInfos[i].PropertyType.GetGenericArguments()[0];
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
                    object instance = Activator.CreateInstance(propertyInfos[i].PropertyType);
                    IList list = (IList)instance;
                    if (bloks.Count == 0) {
                        bool IsValueType = true;
                        PropertyInfo[] propertiesForValues = GenericArgument.GetProperties();
                        foreach (PropertyInfo propertiesForValue in propertiesForValues) {
                            IsValueType &= propertiesForValue.GetCustomAttribute<EdiValueAttribute>() != null;
                        }

                        if (!IsValueType) {
                            if (readToEndLines.Length > 0) {
                                bool IsSame = true;
                                string strValue = string.Empty;
                                strValue = readToEndLines[0].Substring(0, 3);
                                foreach (string readToEndLine in readToEndLines) {
                                    IsSame &= strValue == readToEndLine.Substring(0, 3);
                                    if (!IsSame) break;
                                }
                                if (IsSame) {
                                    foreach (string readToEndLine in readToEndLines) {
                                        EdiFactDeserialize ediFactDeserialize = new EdiFactDeserialize();
                                        object newObject = ediFactDeserialize.DeserializeInternal(new[] { readToEndLine }, GenericArgument);
                                        list.Add(newObject);
                                        readToEndLines = readToEndLines.Where(w => w != readToEndLine).ToArray();
                                    }
                                }
                                else {
                                    EdiFactDeserialize ediFactDeserialize = new EdiFactDeserialize();
                                    object newObject = ediFactDeserialize.DeserializeInternal(readToEndLines, GenericArgument);
                                    list.Add(newObject);                                    
                                }
                            }
                        }
                        else {
                            foreach (PropertyInfo propertiesForValue in propertiesForValues) {
                                if (readToEndLines.Length > 0) {
                                    EdiValueAttribute EdiValueAttributeValue = propertiesForValue.GetCustomAttribute<EdiValueAttribute>();
                                    string[] ValueResults = readToEndLines.Where(x => x.Contains(EdiValueAttributeValue.Path)).ToArray();
                                    foreach (string ValueResult in ValueResults) {
                                        EdiFactDeserialize ediFactDeserialize = new EdiFactDeserialize();
                                        object newObject = ediFactDeserialize.DeserializeInternal(new[] { readToEndLines[0] }, GenericArgument);
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
                                EdiFactDeserialize ediFactDeserialize = new EdiFactDeserialize();
                                object newObject = ediFactDeserialize.DeserializeInternal(items, GenericArgument);
                                list.Add(newObject);
                            }
                        }
                    }
                    propertyInfos[i].SetValue(dataObject, list, null);
                }
            }
            return readToEndLines;
        }
    }
}