using System;

namespace EdiFileProcess.Rev01.Attributes {
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class EdiSegmentAttribute : Attribute {
        public string Path { get; set; }
        public int Order { get; set; }
        public bool IsCollection { get; set; }
        public string SequenceEnd { get; set; }
        public bool IsWithSequenceEnd { get; set; }
        public bool IsLoop { get; set; }
    }
}