using System.Reflection;

namespace EdiFileProcess.Utilities
{
    public class PropertyInfoClass
    {
        public static PropertyInfo[] GetPropertyInfos(object objectType)
        {                    
            PropertyInfo[] allProperties = objectType.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);            
            return allProperties;
        }            
    }
}