﻿using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class District
    {
        public int Id { get; set; }
        public int? ProvinceId { get; set; }
        public string Name { get; set; }
    }
}
