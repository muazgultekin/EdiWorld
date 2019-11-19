using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.X12.Segments
{
    /// <summary>
    /// Assigned Number
    /// </summary>
    [EdiSegment(Path = "LX")]
    public class LXSegment
    {
        [EdiValue("X(6)", Order = 0, Description = "Number assigned for differentiation within a transaction set")]
        public string AssignedNumber { get; set; }
    }
}