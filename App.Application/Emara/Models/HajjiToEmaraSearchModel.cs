using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Emara.Models
{
    public class HajjiToEmaraSearchModel
    {

        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int? EmaraId { get; set; }
        public int MaktabNo { get; set; }
        public int BuildingNo { get; set; }
        public int FloorNo { get; set; }
        public int RoomNo { get; set; }
        public int BedNo { get; set; }
        public int YearId { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string CandidateName { get; set; }
        public string EmaraDetail { get; set; }
        public int? YearName { get; set; }

    }
}
