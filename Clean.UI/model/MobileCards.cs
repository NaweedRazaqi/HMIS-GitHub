using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class MobileCards
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string JobTitle { get; set; }
        public int? MutamidId { get; set; }
        public string AreaToContact { get; set; }
        public int NumberOfHaji { get; set; }
        public int CostPerMinute { get; set; }
        public int DurationInMinutes { get; set; }
        public int CostPerHaji { get; set; }
        public int TotalCost { get; set; }
        public int TotalPayebale { get; set; }
        public string RecievingPlace { get; set; }
        public string Comments { get; set; }
        public int? CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string SpentFor { get; set; }

        public virtual Mutamids Mutamid { get; set; }
    }
}
