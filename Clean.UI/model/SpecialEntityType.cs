using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class SpecialEntityType
    {
        public SpecialEntityType()
        {
            Qouta = new HashSet<Qouta>();
            SpecialEntityOrganization = new HashSet<SpecialEntity>();
            SpecialEntitySpecialEntityType = new HashSet<SpecialEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public string Code { get; set; }
        public int? TypeId { get; set; }
        public int? ParentId { get; set; }

        public virtual ICollection<Qouta> Qouta { get; set; }
        public virtual ICollection<SpecialEntity> SpecialEntityOrganization { get; set; }
        public virtual ICollection<SpecialEntity> SpecialEntitySpecialEntityType { get; set; }
    }
}
