using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// 
    /// </summary>
    [EdiSegment(Path = "N7")]
    public class N7Segment
    {
        [EdiValue("X(4)", Order = 0, Description = "")]
        public string EquipmentInitial  { get; set; }

        [EdiValue("X(10)", Order = 1, Description = "")]
        public string EquipmentNumber  { get; set; }
    }    
}
