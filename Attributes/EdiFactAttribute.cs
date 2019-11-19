using EdiFileProcess.Enums;
using System;

namespace EdiFileProcess.Attributes {
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class EdiFactAttribute : Attribute {
        public EdiFactTypes EdiFactType { get; set; }
        public override string ToString() {
            return base.ToString();
        }
    }
}   