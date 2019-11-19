using EdiFileProcess.Attributes;

namespace EdiFileProcess.Models.EdiFacts.Segments {
    [EdiSegment(Path = "CPS")]
    public class CPSSegment {
        /// <summary>
        /// A unique number assigned by the sender to identify a level within a hierarchical structure.  Without packaging hierarchy only "1“ allowed.
        /// </summary>
        [EdiValue("9(2)", Order = 0)]
        public int HierarchicalIdNumber { get; set; }

        /// <summary>
        /// It is not used.
        /// </summary>
        [EdiValue("X(20)", Order = 1)]
        public string HierarchicalParentId { get; set; }

        /// <summary>
        /// "4" = No packaging Hierarchy. 
        /// </summary>
        [EdiValue("X(20)", Order = 2)]
        public string PackagingLevelCoded { get; set; }       
    }
}
