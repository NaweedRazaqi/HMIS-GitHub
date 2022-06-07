﻿using App.Domain.Entity.look;
using Clean.Domain.Entity.look;
using System;
using System.Collections.Generic;
using Currency = App.Domain.Entity.look.Currency;

namespace App.Domain.Entity.prf
{
    public partial class MutamidAccounts
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public int MutamidId { get; set; }
        public int Amount { get; set; }
        public int YearId { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Mutamids Mutamid { get; set; }
        public virtual Year Year { get; set; }
    }
}
