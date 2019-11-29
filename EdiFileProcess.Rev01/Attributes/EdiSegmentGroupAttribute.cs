using System;

namespace EdiFileProcess.Rev01.Attributes {
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class EdiSegmentGroupAttribute : EdiSegmentAttribute {
    }
}