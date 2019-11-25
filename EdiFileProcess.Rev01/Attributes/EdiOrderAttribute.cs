using System;

namespace EdiFileProcess.Rev01.Attributes {
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class EdiOrderAttribute : Attribute {
        public int Order { get; set; }
        public int MaxLength { get; set; } = int.MaxValue;
        public bool IsDetail { get; set; } = false;
        public string Format { get; set; }
    }
}