using EdiFileProcess.Rev01.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EdiFileProcess.Rev01.Utilities {
    public class PropertyClass {        
        public static PropertyInfo[] GetPropertyInfos(PropertyInfo[] propertyInfos, Type attributeType) {
            List<PropertyInfo> propertyInfoArray = new List<PropertyInfo>();            
            foreach (PropertyInfo propertyInfo in propertyInfos) {
                Attribute attribute = propertyInfo.GetCustomAttribute(attributeType);
                if (attribute == null) continue;
                propertyInfoArray.Add(propertyInfo);
            }

            if (attributeType.Name == "EdiSegmentAttribute")
                return propertyInfoArray.OrderBy(p => p.GetCustomAttributes().OfType<EdiSegmentAttribute>().First().Order).ToArray();
            else if (attributeType.Name == "EdiOrderAttribute")
                return propertyInfoArray.OrderBy(p => p.GetCustomAttributes().OfType<EdiOrderAttribute>().First().Order).ToArray();
            else
                throw new Exception($"Tanımlanmamış {attributeType.Name}");
        }
    }
}
