﻿using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class Bank
    {
        public Bank()
        {
            Installment = new HashSet<Installment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Installment> Installment { get; set; }
    }
}