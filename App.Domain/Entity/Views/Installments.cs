using App.Domain.Entity.doc;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.Views
{
    public partial class Installments
    {
        public int HasNoKey { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string Province { get; set; }
        public string Destricts { get; set; }
        public string Vilege { get; set; }
        public string NationalId { get; set; }
        public string Religion { get; set; }
        public string Code { get; set; }
        public int? DocumentTypeId { get; set; }

        //public virtual DocumentType DocumentType { get; set; }
    }
}
