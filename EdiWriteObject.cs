using EdiFileProcess.Attributes;
using EdiFileProcess.Utilities;
using System;
using System.Collections;
using System.IO;
using System.Reflection;

namespace EdiFileProcess
{
    internal class EdiWriteObject
    {
        private static string Separate { get; set; } = "*";
        public static void Write(StreamWriter streamWriter, object objectType)
        {
            WriteObjectType(streamWriter, objectType);
        }

        private static void WriteObjectType(StreamWriter streamWriter, object objectType)
        {
            EdiSegmentAttribute EdiSegmentAttributeMaster = (EdiSegmentAttribute)objectType.GetType().GetCustomAttribute(typeof(EdiSegmentAttribute));
            if (EdiSegmentAttributeMaster == null)
            {
                Type master = objectType.GetType();
                PropertyInfo[] propertyInfoMasters = master.GetProperties();
                foreach (PropertyInfo propertyInfoMaster in propertyInfoMasters)
                {
                    object objectTypeDetail = propertyInfoMaster.GetValue(objectType);
                    if (objectTypeDetail == null) continue;
                    EdiSegmentAttribute ediSegmentAttribute = (EdiSegmentAttribute)objectTypeDetail.GetType().GetCustomAttribute(typeof(EdiSegmentAttribute));
                    if (ediSegmentAttribute != null)
                    {
                        SetEdiSegmentAttribute(streamWriter, objectTypeDetail, ediSegmentAttribute);
                    }
                    else
                    {
                        IList collections = (IList)objectTypeDetail;
                        foreach (object collection in collections)
                        {
                            WriteObjectType(streamWriter, collection);
                        }
                    }
                }
            }
            else
            {
                SetEdiSegmentAttribute(streamWriter, objectType, EdiSegmentAttributeMaster);
            }
        }

        private static void SetEdiSegmentAttribute(StreamWriter streamWriter, object objectTypeDetail, EdiSegmentAttribute ediSegmentAttribute)
        {
            string lineInfo = string.Empty;
            lineInfo += ediSegmentAttribute.Path + Separate;
            foreach (PropertyInfo propertyInfoDetail in PropertyInfoClass.GetPropertyInfos(objectTypeDetail))
            {
                object[] EdiValueAttributes = propertyInfoDetail.GetCustomAttributes(typeof(EdiValueAttribute), true);
                foreach (object ediValueAttribute in EdiValueAttributes)
                {
                    EdiValueAttribute ediValueAttributeInfo = ediValueAttribute as EdiValueAttribute;
                    string detailValue = string.Empty;
                    switch (ediValueAttributeInfo.Picture.Kind)
                    {
                        case Enums.PictureKind.Alphanumeric:
                            if (propertyInfoDetail.PropertyType == typeof(string))
                            {
                                detailValue = (string)propertyInfoDetail.GetValue(objectTypeDetail);
                                if (ediValueAttributeInfo.IsTrim)
                                {
                                    if (detailValue != null && detailValue.Length > ediValueAttributeInfo.Picture.Scale)
                                    {
                                        detailValue = detailValue.Substring(0, ediValueAttributeInfo.Picture.Scale);
                                    }
                                }
                                else
                                {
                                    detailValue = detailValue.PadRight(ediValueAttributeInfo.Picture.Scale, ' ');
                                }
                            }
                            else if (propertyInfoDetail.PropertyType == typeof(char))
                            {
                                detailValue = ((char)propertyInfoDetail.GetValue(objectTypeDetail)).ToString();
                                if (ediValueAttributeInfo.IsTrim)
                                {
                                    if (detailValue != null && detailValue.Length > ediValueAttributeInfo.Picture.Scale)
                                    {
                                        detailValue = detailValue.Substring(0, ediValueAttributeInfo.Picture.Scale);
                                    }
                                }
                                else
                                {
                                    detailValue = detailValue.PadRight(ediValueAttributeInfo.Picture.Scale, ' ');
                                }
                            }
                            else if (propertyInfoDetail.PropertyType.IsGenericType && propertyInfoDetail.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            {
                                var genericType = propertyInfoDetail.PropertyType.GetGenericArguments()[0];
                                if (genericType.FullName == "System.Char")
                                {
                                    detailValue = ((char)propertyInfoDetail.GetValue(objectTypeDetail)).ToString();
                                    if (ediValueAttributeInfo.IsTrim)
                                        detailValue = detailValue.PadRight(ediValueAttributeInfo.Picture.Scale, ' ');
                                    else
                                    {
                                        if (detailValue != null && detailValue.Length > ediValueAttributeInfo.Picture.Scale)
                                        {
                                            detailValue = detailValue.Substring(0, ediValueAttributeInfo.Picture.Scale);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                throw new Exception("Hata");
                            }
                            break;
                        case Enums.PictureKind.Numeric:
                            if (propertyInfoDetail.GetValue(objectTypeDetail) == null)
                            {
                                var a = propertyInfoDetail.GetType();
                                detailValue = string.Empty;
                                break;
                            }
                            else
                                detailValue = propertyInfoDetail.GetValue(objectTypeDetail).ToString();
                            if (detailValue == "True")
                            {
                                detailValue = "1";
                            }
                            if (detailValue == "False")
                            {
                                detailValue = "0";
                            }
                            if (ediValueAttributeInfo.Format != null)
                            {
                                detailValue = DateTime.Parse(detailValue).ToString(ediValueAttributeInfo.Format);
                                detailValue = detailValue.PadLeft(ediValueAttributeInfo.Picture.Scale, '0');
                            }
                            else
                            {
                                detailValue = detailValue.PadLeft(ediValueAttributeInfo.Picture.Scale, '0');
                            }
                            break;
                        default:
                            break;
                    }
                    if (detailValue != null) lineInfo += detailValue + Separate;
                }
            }
            lineInfo = lineInfo.Substring(0, lineInfo.Length - 1) + "~";
            streamWriter.WriteLine(lineInfo);
        }
    }
}