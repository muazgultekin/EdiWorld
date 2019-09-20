using EdiFileProcess.Structs;
using System;

namespace EdiFileProcess.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public sealed class EdiValueAttribute : Attribute
    {
        public bool IsTrim { get; set; } = true;

        /// <summary>
        /// Helps by annotating the current member with a <see cref="Description"/>. Only for reference and documentation.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Extra dotnet style format string. Currently only used for date formatting. (ie yyyyMMdd)
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// The path for the component value. A string representation of an <see cref="EdiPath"/> pointing to a component value ie: "XYZ/0/0"
        /// </summary>
        public string Path { get; set; }

        public int Order { get; set; }

        /// <summary>
        /// The value spec regarding value size and format.
        /// </summary>
        public Picture Picture { get; }

        /// <summary>
        /// Constructs the attribute with defaults
        /// </summary>
        public EdiValueAttribute()
           : this(default(Picture))
        {
        }

        /// <summary>
        /// Constructs the attribute given the string representation of a <see cref="Picture"/>
        /// </summary>
        public EdiValueAttribute(string picture)
            : this((Picture)picture)
        {
        }

        /// <summary>
        /// Constructs the attribute given the <see cref="Picture"/>
        /// </summary>
        /// <param name="picture"></param>
        public EdiValueAttribute(Picture picture)
        {
            Picture = picture;
        }
    }
}