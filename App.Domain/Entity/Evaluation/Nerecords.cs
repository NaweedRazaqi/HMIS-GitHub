using App.Domain.Entity.look;
using App.Domain.Entity.prf;
using System;

namespace App.Domain.Entity.Evaluation
{
    public partial class Nerecords
    {
        public int Id { get; set; }
        public int? Nid { get; set; }
        public int? Evid { get; set; }
        public int? ZoneId { get; set; }
        public int? EvCreteriaId { get; set; }
        public int? ResultId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Evcategory Ev { get; set; }
        public virtual EvCreteria EvCreteria { get; set; }
        public virtual Candidate N { get; set; }
        public virtual Marks Result { get; set; }
        public virtual Evzone Zone { get; set; }
    }
}
