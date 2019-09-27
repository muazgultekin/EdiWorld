using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace EdiFileProcess.UnitTest
{    
    [XmlRoot(ElementName = "POS")]
    public class POS
    {
        [XmlElement(ElementName = "row")]
        public Row Row { get; set; }
    }

    [XmlRoot(ElementName = "row")]
    public class Row
    {
        [XmlAttribute(AttributeName = "COURSE")]
        public string COURSE { get; set; }
        [XmlAttribute(AttributeName = "DSRC")]
        public string DSRC { get; set; }
        [XmlAttribute(AttributeName = "HEADING")]
        public string HEADING { get; set; }
        [XmlAttribute(AttributeName = "IMO")]
        public string IMO { get; set; }
        [XmlAttribute(AttributeName = "LAT")]
        public string LAT { get; set; }
        [XmlAttribute(AttributeName = "LON")]
        public string LON { get; set; }
        [XmlAttribute(AttributeName = "MMSI")]
        public string MMSI { get; set; }
        [XmlAttribute(AttributeName = "SHIP_ID")]
        public string SHIP_ID { get; set; }
        [XmlAttribute(AttributeName = "SPEED")]
        public string SPEED { get; set; }
        [XmlAttribute(AttributeName = "STATUS")]
        public string STATUS { get; set; }
        [XmlAttribute(AttributeName = "TIMESTAMP")]
        public string TIMESTAMP { get; set; }
        [XmlAttribute(AttributeName = "UTC_SECONDS")]
        public string UTC_SECONDS { get; set; }
    }

}
