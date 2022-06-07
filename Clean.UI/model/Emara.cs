using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class Emara
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public string FullAddress { get; set; }
        public int BuildingNo { get; set; }
        public int FloorNo { get; set; }
        public int RoomNo { get; set; }
        public int BedNo { get; set; }
        public string Remarks { get; set; }
        public int YearId { get; set; }
        public int? CreatedBy { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Location Location { get; set; }
        public virtual Year Year { get; set; }
    }
}
