using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Enums;
using EdiFileProcess.Rev01.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EdiFileProcess.Rev01 {
    public class EdiFactSerializer {
        public void Serialize(StreamWriter streamWriter, object objectType) {
            EdiFactAttribute ediFactAttribute = (EdiFactAttribute)objectType.GetType().GetCustomAttribute(typeof(EdiFactAttribute));
            switch (ediFactAttribute.EdiFactType) {
                case EdiFactTypes.HANMOV:
                    Write(streamWriter, objectType);
                    break;
                default:
                    throw new Exception($"{ediFactAttribute.EdiFactType} Model is not designed.");
            }
        }

        public void Write(StreamWriter streamWriter, object objectType) {
            streamWriter.WriteLine("UNA:+.? '");
            WriteObjectType(streamWriter, objectType, "+");
        }

        private string WriteObjectType(StreamWriter streamWriter, object objectType, string separate) {
            string result = string.Empty;
            PropertyInfo[] propertyInfos = PropertyClass.GetPropertyInfos(objectType.GetType().GetProperties(), typeof(EdiSegmentAttribute));
            if (propertyInfos.Length > 0) {
                result = string.Empty;
                foreach (PropertyInfo propertyInfo in propertyInfos.OrderBy(p => p.GetCustomAttributes().OfType<EdiSegmentAttribute>().First().Order).ToArray()) {
                    if (!propertyInfo.PropertyType.IsGenericType) {
                        object values = propertyInfo.GetValue(objectType);
                        if (values != null) {
                            EdiSegmentAttribute propertyTypeAttribute = (EdiSegmentAttribute)propertyInfo.PropertyType.GetCustomAttribute(typeof(EdiSegmentAttribute));
                            if (propertyTypeAttribute != null) {
                                result += propertyTypeAttribute.Path + "+" + WriteObjectType(streamWriter, values, separate);
                                result = result.Substring(0, result.Length - 1) + "'";
                                streamWriter.WriteLine(result);
                                result = string.Empty;
                            }
                            else {
                                throw new Exception($"The model {propertyInfo.Name} is incorrect.");
                            }
                        }
                    }
                    else {
                        IList values = (IList)propertyInfo.GetValue(objectType);
                        if (values == null) continue;
                        for (int i = 0; i < values.Count; i++) {
                            EdiSegmentAttribute propertyTypeAttribute = (EdiSegmentAttribute)values[i].GetType().GetCustomAttribute(typeof(EdiSegmentAttribute));
                            if (propertyTypeAttribute == null) {
                                result = WriteObjectType(streamWriter, values[i], separate);
                            }
                            else {
                                result += propertyTypeAttribute.Path + "+" + WriteObjectType(streamWriter, values[i], separate);
                                result = result.Substring(0, result.Length - 1) + "'";
                                streamWriter.WriteLine(result);
                                result = string.Empty;
                            }
                        }
                    }
                }
            }

            propertyInfos = PropertyClass.GetPropertyInfos(objectType.GetType().GetProperties(), typeof(EdiOrderAttribute));
            if (propertyInfos.Length > 0) {
                foreach (PropertyInfo propertyInfo in propertyInfos.OrderBy(p => p.GetCustomAttributes().OfType<EdiOrderAttribute>().First().Order).ToArray()) {
                    EdiOrderAttribute ediOrderAttribute = (EdiOrderAttribute)propertyInfo.GetCustomAttribute(typeof(EdiOrderAttribute));
                    if (ediOrderAttribute.IsDetail) {
                        object values = propertyInfo.GetValue(objectType);
                        if (values != null) {
                            result += WriteObjectType(streamWriter, values, ":") + "+";
                        }
                    }
                    else {
                        if (propertyInfo.PropertyType == typeof(string)) {
                            if (propertyInfo.GetValue(objectType) != null)
                                result += (string)propertyInfo.GetValue(objectType) + separate;
                        }
                        else if (propertyInfo.PropertyType == typeof(int)) {
                            result += ((int)propertyInfo.GetValue(objectType)).ToString() + separate;
                        }
                        else if (propertyInfo.PropertyType == typeof(DateTime)) {
                            if (propertyInfo.GetValue(objectType) != null) {
                                string daetTimeStr = propertyInfo.GetValue(objectType).ToString();
                                DateTime dateTime = DateTime.Parse(daetTimeStr);
                                string dateTimeResult = dateTime.ToString(ediOrderAttribute.Format, null);
                                result += dateTimeResult + separate;
                            }
                        }
                        else if (propertyInfo.PropertyType == typeof(TimeSpan)) {
                            if (propertyInfo.GetValue(objectType) != null) {
                                string timeSpanStr = propertyInfo.GetValue(objectType).ToString();
                                TimeSpan timeSpan = TimeSpan.Parse(timeSpanStr);
                                string timeSpanResult = timeSpan.ToString(ediOrderAttribute.Format, null);
                                result += timeSpanResult + separate;
                            }
                        }
                    }
                }
            }

            if (result != string.Empty) {
                if (result.Substring(result.Length - 1, 1) == ":")
                    return result.Substring(0, result.Length - 1);
                else
                    return result;
            }
            else
                return result;
        }        
    }
}