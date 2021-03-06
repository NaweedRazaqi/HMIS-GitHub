using System;
using System.Collections.Generic;

namespace Clean.Domain.Entity.doc
{
    public partial class Documents
    {
        public long Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public DateTime UploadDate { get; set; }
        public long RecordId { get; set; }
        public string Root { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public int? ScreenId { get; set; }
        public DateTime? LastDownloadDate { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentSource { get; set; }
        public DateTime? DocumentDate { get; set; }
        public int DocumentTypeId { get; set; }
        public int CreatedBy { get; set; }

        public virtual DocumentType DocumentType { get; set; }
    }
}
