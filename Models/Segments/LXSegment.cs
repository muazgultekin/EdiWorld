using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.Segments
{
    /// <summary>
    /// Assigned Number
    /// </summary>
    [EdiSegment(Path = "LX")]
    public class LXSegment
    {
        [EdiValue("X(6)", Order = 0, Path = "LX", Description = "Number assigned for differentiation within a transaction set")]
        public string AssignedNumber { get; set; }
    }
}