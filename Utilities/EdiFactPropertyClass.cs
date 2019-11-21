using EdiFileProcess.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace EdiFileProcess.Utilities {
    public class EdiFactPropertyClass {
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
                Type propertyType = propertyInfo.PropertyType;
                if (!propertyType.IsGenericType) {
                    SetPropertyInfo(readToEndLines, propertyInfo);
                }
            }
            return readToEndLines;
        }

        public static string[] IsGenericType(string[] readToEndLines, object dataObject) {
            Type dataObjectType = dataObject.GetType();
            return readToEndLines;
        }

        private static void SetPropertyInfo(string[] line, object uNBSegment) {
            object IsClassObject2 = Activator.CreateInstance(uNBSegment.GetType());
            PropertyInfo[] propertyInfoTypes = IsClassObject2.GetType().GetProperties().OrderBy(p => p.GetCustomAttributes().OfType<EdiOrderAttribute>().First().Order).ToArray();
            string[] lineStr = line[0].Split('+');
            lineStr = lineStr.Skip(1).ToArray();
            for (int i = 0; i < propertyInfoTypes.Length; i++) {
                string[] unbs = lineStr[i].Split(':');
                Type propertyType = propertyInfoTypes[i].PropertyType;
                if (propertyInfoTypes[i].PropertyType.Name == "String") {
                    propertyInfoTypes[i].SetValue(uNBSegment, unbs[0]);
                }
                else {
                    object IsClassObject = Activator.CreateInstance(propertyType);
                    SetPropertyInfo(unbs, IsClassObject);
                    propertyInfoTypes[i].SetValue(uNBSegment, IsClassObject);
                }
            }
        }
    }
}
