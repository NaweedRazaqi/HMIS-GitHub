using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Persistence.Context;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace App.Application.Candidate.Commands
{
    public class AttachmentCommand : IRequest<List<AttachmentModel>>
    {

        public long? Id { get; set; }
        public string ContentType { get; set; }
        public DateTime UploadDate { get; set; }
        public string Module { get; set; }
        public string Item { get; set; }
        public long RecordId { get; set; }
        public string Root { get; set; }
        public string Path { get; set; }
        public string EncryptionKey { get; set; }
        public string ReferenceNo { get; set; }
        public int? StatusId { get; set; }
        public int? ScreenId { get; set; }
        public string Description { get; set; }
        public int DocumentTypeId { get; set; }
        public long ProfileId { get; set; }
        public DateTime? LastDownloadDate { get; set; }
        public string FileName { get; set; }
        public string DocumentNumber { get; set; }
        public string Documentsource { get; set; }
        public DateTime DocumentDate { get; set; }
        public int? BranchId { get; set; }//just for account opening
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }


    public class AttachmentCommandHandler : IRequestHandler<AttachmentCommand, List<AttachmentModel>>
    {

        private readonly AppDbContext _context;
        private readonly IMediator _mediator;
        private readonly ICurrentUser _currentUser;
        public AttachmentCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            _context = context;
            _mediator = mediator;
            _currentUser = currentUser;

        }

        public async Task<List<AttachmentModel>> Handle(AttachmentCommand request, CancellationToken cancellationToken)
        {

            string path = request.Path;
            string FileName = Path.GetFileName(path); // extracting filename 
            var ContentType = Path.GetExtension(path); // extracting file extension
            int CurrentUserId = await _currentUser.GetUserId();
            List<AttachmentModel> Result = new List<AttachmentModel>();
            if (request.Id == null || request.Id == default(decimal))
            {

                var StudentAttachment = new Clean.Domain.Entity.doc.Documents()
                {

                    ContentType = ContentType,
                    UploadDate = DateTime.Now,
                    Path = request.Path,
                    RecordId = request.ProfileId,
                    Root = request.Root,
                    DocumentTypeId = request.DocumentTypeId,
                    DocumentDate = request.DocumentDate,
                    DocumentNumber = request.DocumentNumber,
                    DocumentSource = request.Documentsource,
                    Description = request.Description,
                    FileName = FileName,
                    ScreenId = request.ScreenId,
                    LastDownloadDate = DateTime.Now,
                };

                _context.Documents.Add(StudentAttachment);

                await _context.SaveChangesAsync(cancellationToken);

                Result = await _mediator.Send(new SearchAttachmentQuery() { Id = StudentAttachment.Id });


            }
            else
            {

                var StudentAttachment = (from p in _context.Documents
                                         where p.Id == request.Id
                                         select p).First();

                StudentAttachment.ContentType = ContentType;
                StudentAttachment.UploadDate = DateTime.Now;
                StudentAttachment.Path = request.Path;
                StudentAttachment.RecordId = request.ProfileId;
                StudentAttachment.Root = request.Root;
                StudentAttachment.DocumentTypeId = request.DocumentTypeId;
                StudentAttachment.DocumentDate = request.DocumentDate;
                StudentAttachment.DocumentNumber = request.DocumentNumber;
                StudentAttachment.DocumentSource = request.Documentsource;
                StudentAttachment.Description = request.Description;
                StudentAttachment.FileName = FileName;
                StudentAttachment.ScreenId = request.ScreenId;
                StudentAttachment.LastDownloadDate = DateTime.Now;

                await _context.SaveChangesAsync();

                Result = await _mediator.Send(new SearchAttachmentQuery() { Id = StudentAttachment.Id });

            }
            return Result;
        }
    }
}


   