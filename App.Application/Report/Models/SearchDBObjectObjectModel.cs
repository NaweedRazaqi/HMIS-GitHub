using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Report.Models
{
    public class SearchDBObjectObjectModel
    {
        public long ID { get; set; }
        public long? ParentID { get; set; }
        public long? ChildID { get; set; }

        public string ParentText { get; set; }
        public string ChildText { get; set; }
    }
}
