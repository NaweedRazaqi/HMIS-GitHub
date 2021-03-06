using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class ScreenDocument
    {
        public int Id { get; set; }
        public int? ScreenId { get; set; }
        public int? DocumentTypeId { get; set; }
        public bool? IsActive { get; set; }

        public virtual DocumentType DocumentType { get; set; }
    }
}
