/*EdiSegmentAttribute eEdiSegmentAttribute = (EdiSegmentAttribute)propertyInfo.GetCustomAttribute(typeof(EdiSegmentAttribute));
Type GenericArgument = propertyInfo.PropertyType.GetGenericArguments()[0];                    
List<string> readToEndLineTemp = new List<string>();
bool IsAdd = false;
foreach (string readToEndLine in ReadToEndLines)
{
    string[] parts = readToEndLine.Split('*');
    string master = parts[0];
    if (!IsAdd)
    {
        if (master == eEdiSegmentAttribute.Path)
        {
            readToEndLineTemp.Add(readToEndLine);
            IsAdd = !IsAdd;
        }
    }            
    else
    {
        if ((master != eEdiSegmentAttribute.Path) && (master != eEdiSegmentAttribute.SequenceEnd))
        {
            readToEndLineTemp.Add(readToEndLine);                                
        }
        else
        {
            object dataObjectReturn = DeserializeInternal(readToEndLineTemp.ToArray(), GenericArgument);
            propertyInfo.SetValue(GenericArgument, dataObjectReturn);
            IsAdd = !IsAdd;
        }
    }
}    */

using EdiFileProcess.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EdiFileProcess
{
    public class EdiDeserialize
    {
        public T Deserialize<T>(StreamReader reader)
        {
            return (T)Deserialize(reader, typeof(T));
        }

        public object Deserialize(StreamReader reader, Type objectType)
        {
            string ReadToEnd = reader.ReadToEnd();
            string[] ReadToEndLines = ReadToEnd.Replace("\r", string.Empty).Replace("\n", string.Empty).Split('~');
            ReadToEndLines = ReadToEndLines.Where(w => w != string.Empty).ToArray();
            EdiAttribute ediAttribute = (EdiAttribute)objectType.GetCustomAttribute<EdiAttribute>();
            if (ediAttribute == null)
                throw new Exception("Deserialize edilecek obje Modeli hangi Edi dosyası için işlem tyapılacağı tanımlanmamış!");
            switch (ediAttribute.EdiType)
            {
                case Enums.EdiTypes.Edi210:
                case Enums.EdiTypes.Edi214:
                case Enums.EdiTypes.Edi850:
                    return DeserializeInternal(ReadToEndLines, objectType);
                case Enums.EdiTypes.Edi856:
                case Enums.EdiTypes.Edi856WithEquipment:
                    return DeserializeInternal856(ReadToEndLines, objectType);
                case Enums.EdiTypes.Edi990:
                    return DeserializeEdi990(ReadToEndLines, objectType);
                default:
                    return DeserializeInternal(ReadToEndLines, objectType);
            }
        }

        private object DeserializeInternal(string[] ReadToEndLines, Type objectType)
        {
            object dataObject = Activator.CreateInstance(objectType);
            Type dataObjectType = dataObject.GetType();

            PropertyInfo[] propertyInfos = dataObjectType.GetProperties();

            EdiValueAttribute ediValueAttribute = (EdiValueAttribute)propertyInfos[0].GetCustomAttribute(typeof(EdiValueAttribute));
            if (ediValueAttribute != null)
            {
                var a = objectType.GetCustomAttributes();
                string[] parts = ReadToEndLines[0].Split('*');
                SetPropertyInfo(parts, dataObject);
                return dataObject;
            }
            propertyInfos = dataObjectType.GetProperties().OrderBy(p => p.GetCustomAttributes().OfType<EdiSegmentAttribute>().First().Order).ToArray();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Type propertyType = propertyInfo.PropertyType;
                if (!propertyType.IsGenericType)
                {
                    ReadToEndLines = SetPropertyInfo(ReadToEndLines, dataObject, propertyInfo, propertyType);
                }
            }

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Type propertyType = propertyInfo.PropertyType;
                if (propertyType.IsGenericType)
                {
                    EdiSegmentAttribute eEdiSegmentAttribute = (EdiSegmentAttribute)propertyInfo.GetCustomAttribute(typeof(EdiSegmentAttribute));
                    Type GenericArgument = propertyInfo.PropertyType.GetGenericArguments()[0];

                    List<string> readToEndLineTemp = new List<string>();
                    List<string[]> details = new List<string[]>();
                    foreach (string readToEndLine in ReadToEndLines)
                    {
                        string[] parts = readToEndLine.Split('*');
                        string master = parts[0];
                        if (eEdiSegmentAttribute.SequenceEnd == null)
                        {
                            IEnumerable<Attribute> Attributes = GenericArgument.GetCustomAttributes();
                            if (Attributes.Count() == 0)
                            {
                                readToEndLineTemp.Add(readToEndLine);
                            }
                            else
                            {
                                if (eEdiSegmentAttribute.Path == master)
                                {
                                    readToEndLineTemp.Add(readToEndLine);
                                }
                            }
                        }
                        else if (eEdiSegmentAttribute.SequenceEnd == master)
                        {
                            readToEndLineTemp.Add(readToEndLine);
                            details.Add(readToEndLineTemp.ToArray());
                            readToEndLineTemp = new List<string>();
                        }
                        else
                        {
                            readToEndLineTemp.Add(readToEndLine);
                        }
                    }
                    if (details.Count > 0)
                    {
                        object instance = Activator.CreateInstance(propertyInfo.PropertyType);
                        IList list = (IList)instance;
                        foreach (string[] strings in details)
                        {
                            object newObject = DeserializeInternal(strings, GenericArgument);
                            list.Add(newObject);
                        }
                        propertyInfo.SetValue(dataObject, list, null);
                    }
                    else
                    {
                        List<string> readToEndLineTempDetay = new List<string>();
                        foreach (string readToEndLine in readToEndLineTemp)
                        {
                            string[] parts = readToEndLine.Split('*');
                            string master = parts[0];
                            if (master == "SE") continue;
                            if ((eEdiSegmentAttribute.Path == master) && (readToEndLineTempDetay.Count > 1))
                            {
                                details.Add(readToEndLineTempDetay.ToArray());
                                readToEndLineTempDetay = new List<string>();
                            }
                            readToEndLineTempDetay.Add(readToEndLine);
                        }
                        if (readToEndLineTempDetay.Count > 0)
                        {
                            details.Add(readToEndLineTempDetay.ToArray());
                            readToEndLineTempDetay = new List<string>();
                        }

                        object instance = Activator.CreateInstance(propertyInfo.PropertyType);
                        IList list = (IList)instance;
                        foreach (string[] strings in details)
                        {
                            object newObject = DeserializeInternal(strings, GenericArgument);
                            list.Add(newObject);
                        }
                        propertyInfo.SetValue(dataObject, list, null);
                    }
                }
            }
            return dataObject;
        }

        private object DeserializeInternal856(string[] ReadToEndLines, Type objectType)
        {
            EdiAttribute ediAttribute = (EdiAttribute)objectType.GetCustomAttribute<EdiAttribute>();
            Array array = Enum.GetValues(typeof(Enums.EdiTypes));
            throw new Exception(array.GetValue((int)ediAttribute.EdiType) + ": Deserialize işlemi geliştirme aşamasında. ");
        }

        private static string[] SetPropertyInfo(string[] ReadToEndLines, object dataObject, PropertyInfo propertyInfo, Type propertyType)
        {
            EdiSegmentAttribute eEdiSegmentAttribute = (EdiSegmentAttribute)propertyType.GetCustomAttribute(typeof(EdiSegmentAttribute));
            foreach (string readToEndLine in ReadToEndLines)
            {
                string[] parts = readToEndLine.Split('*');
                string master = parts[0];
                if (eEdiSegmentAttribute != null)
                {
                    if (eEdiSegmentAttribute.Path == master)
                    {
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

        private static void SetPropertyInfo(string[] parts, object IsClassObject)
        {
            PropertyInfo[] propertyInfoTypes = IsClassObject.GetType().GetProperties().OrderBy(p => p.GetCustomAttributes().OfType<EdiValueAttribute>().First().Order).ToArray();
            foreach (PropertyInfo propertyInfoType in propertyInfoTypes)
            {
                #region
                object[] ediValueAttributes = propertyInfoType.GetCustomAttributes(typeof(EdiValueAttribute), true);
                EdiValueAttribute ediValueAttribute = (EdiValueAttribute)ediValueAttributes[0];
                if ((ediValueAttribute.Order + 1) >= parts.Length)
                {
                    break;
                }
                if (ediValueAttributes.Length > 1)
                {
                    string formatString = ediValueAttribute.Format + ((EdiValueAttribute)ediValueAttributes[1]).Format;
                    string sample = parts[ediValueAttribute.Order + 1] + parts[ediValueAttribute.Order + 2];
                    DateTime dt = DateTime.ParseExact(sample, formatString, null);
                    propertyInfoType.SetValue(IsClassObject, dt);
                }
                else
                {
                    if (ediValueAttribute.Picture.Kind == Enums.PictureKind.Numeric)
                    {
                        if (propertyInfoType.PropertyType.IsGenericType)
                        {
                            string result = parts[ediValueAttribute.Order + 1].ToString();
                            if (result != string.Empty)
                            {
                                bool boolValue = result == "0" ? false : true;
                                propertyInfoType.SetValue(IsClassObject, boolValue);
                            }
                        }
                        else
                        {
                            if (parts[ediValueAttribute.Order + 1] != string.Empty)
                            {
                                if (propertyInfoType.PropertyType.Name == "Decimal")
                                {
                                    Decimal decimalValue = Convert.ToDecimal(parts[ediValueAttribute.Order + 1].ToString());
                                    propertyInfoType.SetValue(IsClassObject, decimalValue);
                                }
                                else if (propertyInfoType.PropertyType.Name == "DateTime")
                                {
                                    string s = parts[ediValueAttribute.Order + 1];
                                    DateTime dt = DateTime.ParseExact(s, ediValueAttribute.Format, null);
                                    propertyInfoType.SetValue(IsClassObject, dt);
                                }
                                else
                                {
                                    propertyInfoType.SetValue(IsClassObject, Convert.ToInt32(parts[ediValueAttribute.Order + 1]));
                                }
                            }
                        }
                    }
                    else
                    {
                        if (propertyInfoType.PropertyType.IsGenericType)
                        {
                            propertyInfoType.SetValue(IsClassObject, '\0');
                        }
                        else
                        {
                            if (propertyInfoType.PropertyType.Name == "Decimal")
                            {
                                if (parts[ediValueAttribute.Order + 1] != string.Empty)
                                {
                                    Decimal a = Convert.ToDecimal(parts[ediValueAttribute.Order + 1].ToString());
                                    propertyInfoType.SetValue(IsClassObject, a);
                                }
                            }
                            else
                            {
                                propertyInfoType.SetValue(IsClassObject, parts[ediValueAttribute.Order + 1]);
                            }
                        }
                    }
                }
                #endregion
            }
        }

        private object DeserializeEdi990(string[] ReadToEndLines, Type objectType)
        {
            
            #region Edi Validation
            /*
            if (ReadToEndLines.Length < 4)
                throw new Exception("Edi hatalı!");

            string ISALine = ReadToEndLines[0];
            string[] ISALineParts = ISALine.Split('*');
            if (ISALineParts[0] != "ISA")
                throw new Exception("Edi dosyası ISA ile başlamalıdır!");

            string GSLine = ReadToEndLines[1];
            string[] GSLineParts = GSLine.Split('*');
            if (GSLineParts[0] != "GS")
                throw new Exception("Edi dosyası 2. satırda GS içermelidir!");

            string GELine = ReadToEndLines[ReadToEndLines.Length - 2];
            string[] GELineParts = GELine.Split('*');
            if (GELineParts[0] != "GE")
                throw new Exception("Edi dosyası GE bilgisi içermelidir!");

            string IEALine = ReadToEndLines[ReadToEndLines.Length - 1];
            string[] IEALineParts = IEALine.Split('*');
            if (IEALineParts[0] != "IEA")
                throw new Exception("Edi dosyası IEA ile bitmelidir!");
            */

            object dataObject = Activator.CreateInstance(objectType);
            Type dataObjectType = dataObject.GetType();


            foreach (PropertyInfo propertyInfo in dataObjectType.GetProperties())
            {
                Type propertyType = propertyInfo.PropertyType;
                if (!propertyType.IsGenericType)
                {
                    ReadToEndLines = SetPropertyInfo(ReadToEndLines, dataObject, propertyInfo, propertyType);
                }
            }
            #endregion Edi Validation

            PropertyInfo[] propertyInfos = dataObjectType.GetProperties();
            propertyInfos = dataObjectType.GetProperties().OrderBy(p => p.GetCustomAttributes().OfType<EdiSegmentAttribute>().First().Order).ToArray();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Type propertyType = propertyInfo.PropertyType;
                if (propertyType.IsGenericType)
                {
                    EdiSegmentAttribute eEdiSegmentAttribute = (EdiSegmentAttribute)propertyInfo.GetCustomAttribute(typeof(EdiSegmentAttribute));
                    Type GenericArgument = propertyInfo.PropertyType.GetGenericArguments()[0];

                    List<string> readToEndLineTemp = new List<string>();
                    List<string[]> details = new List<string[]>();
                    foreach (string readToEndLine in ReadToEndLines)
                    {
                        string[] parts = readToEndLine.Split('*');
                        string master = parts[0];
                        if (eEdiSegmentAttribute.SequenceEnd == null)
                        {
                            IEnumerable<Attribute> Attributes = GenericArgument.GetCustomAttributes();
                            if (Attributes.Count() == 0)
                            {
                                readToEndLineTemp.Add(readToEndLine);
                            }
                            else
                            {
                                if (eEdiSegmentAttribute.Path == master)
                                {
                                    readToEndLineTemp.Add(readToEndLine);
                                }
                            }
                        }
                        else if (eEdiSegmentAttribute.SequenceEnd == master)
                        {
                            readToEndLineTemp.Add(readToEndLine);
                            details.Add(readToEndLineTemp.ToArray());
                            readToEndLineTemp = new List<string>();
                        }
                        else
                        {
                            readToEndLineTemp.Add(readToEndLine);
                        }
                    }
                    if (details.Count > 0)
                    {
                        object instance = Activator.CreateInstance(propertyInfo.PropertyType);
                        IList list = (IList)instance;
                        foreach (string[] strings in details)
                        {
                            object newObject = DeserializeInternal(strings, GenericArgument);
                            list.Add(newObject);
                        }
                        propertyInfo.SetValue(dataObject, list, null);
                    }
                    else
                    {
                        List<string> readToEndLineTempDetay = new List<string>();
                        foreach (string readToEndLine in readToEndLineTemp)
                        {
                            string[] parts = readToEndLine.Split('*');
                            string master = parts[0];
                            if ((eEdiSegmentAttribute.Path == master) && (readToEndLineTempDetay.Count > 1))
                            {
                                details.Add(readToEndLineTempDetay.ToArray());
                                readToEndLineTempDetay = new List<string>();
                            }
                            readToEndLineTempDetay.Add(readToEndLine);
                        }
                        if (readToEndLineTempDetay.Count > 0)
                        {
                            details.Add(readToEndLineTempDetay.ToArray());
                            readToEndLineTempDetay = new List<string>();
                        }

                        object instance = Activator.CreateInstance(propertyInfo.PropertyType);
                        IList list = (IList)instance;
                        foreach (string[] strings in details)
                        {
                            IEnumerable<Attribute> Attributes = GenericArgument.GetCustomAttributes();
                            if (Attributes.Count() == 0)
                            {
                                object newObject = DeserializeInternal(strings, GenericArgument);
                                list.Add(newObject);
                            }
                            else
                            {
                                foreach (string item in strings)
                                {
                                    object newObject = DeserializeInternal(new string[] { item }, GenericArgument);
                                    list.Add(newObject);
                                }
                            }
                        }
                        propertyInfo.SetValue(dataObject, list, null);
                    }
                }
            }
            return dataObject;
        }
    }
}