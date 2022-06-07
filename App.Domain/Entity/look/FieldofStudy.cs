using App.Domain.Entity.prf;
using System.Collections.Generic;

namespace App.Domain.Entity.look
{
    public partial class FieldofStudy
    {
        public FieldofStudy()
        {
            Education = new HashSet<Education>();
        }

        public long Id { get; set; }
        public string Text { get; set; }

        public virtual ICollection<Education> Education { get; set; }
    }
}
