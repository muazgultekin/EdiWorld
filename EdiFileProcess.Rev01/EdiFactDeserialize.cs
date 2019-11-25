using System;
using System.IO;

namespace EdiFileProcess.Rev01 {
    public class EdiFactDeserialize {
        public T Deserialize<T>(StreamReader reader) {
            return (T)Deserialize(reader, typeof(T));
        }

        public object Deserialize(StreamReader reader, Type objectType) {
            return null;
        }
    }
}
