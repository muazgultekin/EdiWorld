using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// TD3*TL*CK*6789~
    /// </summary>
    [EdiSegment(Path = "TD3")]
    public class TD3Segment
    {
        [EdiValue("X(2)", Order = 0)]
        public string EquipmentDescriptionCode { get; set; }

        [EdiValue("X(4)", Order = 1)]
        public string EquipmentInitial { get; set; }

        [EdiValue("X(7)", Order = 2)]
        public string EquipmentNumber { get; set; }

        [EdiValue("X(50)", Order = 3)]
        public string Unknown1 { get; set; }

        [EdiValue("X(50)", Order = 4)]
        public string Unknown2 { get; set; }

        [EdiValue("X(50)", Order = 5)]
        public string Unknown3 { get; set; }

        [EdiValue("X(50)", Order = 6)]
        public string Unknown4 { get; set; }

        [EdiValue("X(50)", Order = 7)]
        public string Unknown5 { get; set; }

        [EdiValue("X(50)", Order = 8)]
        public string Unknown6 { get; set; }
    }
}