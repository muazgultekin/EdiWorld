using EdiFileProcess.Rev01.Attributes;
using EdiFileProcess.Rev01.Details;

namespace EdiFileProcess.Rev01.Segments.EdiFact {
    [EdiSegment(Path = "LOC")]
    public class LOCSegment {
        [EdiOrder(Order = 0)]
        public string PlaceLocationQualifier { get; set; }

        [EdiOrder(Order = 1, IsDetail = true)]
        public LocationIdentificationDetails LocationIdentificationDetail { get; set; }

        [EdiOrder(Order = 2, IsDetail = true)]
        public RelatedLocationOneIdentificationDetails RelatedLocationOneIdentificationDetail { get; set; }

        [EdiOrder(Order = 3, IsDetail = true)]
        public RelatedLocationTwoIdentificationDetails RelatedLocationTwoIdentificationDetail { get; set; }

        [EdiOrder(Order = 4)]
        public string RelationCoded { get; set; }
    }
}