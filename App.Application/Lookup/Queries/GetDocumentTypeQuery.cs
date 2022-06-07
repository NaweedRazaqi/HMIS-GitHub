using App.Application.Lookup.Models;
using App.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Lookup.Queries
{
    public class GetDocumentTypeQuery : IRequest<List<DocumentTypeModel>>
    {
        public int? ID { get; set; }
        public int? ScreenID { get; set; }
        public string Category { get; set; }
    }
    public class GetDocumentTypeQueryHandler : IRequestHandler<GetDocumentTypeQuery, List<DocumentTypeModel>>
    {
        private readonly AppDbContext _context;
        public GetDocumentTypeQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<DocumentTypeModel>> Handle(GetDocumentTypeQuery request, CancellationToken cancellationToken)
        {

            var query = _context.ScreenDocuments.AsQueryable();
            if (request.ID.HasValue)
            {
                query = query.Where(e => e.Id == request.ID);
            }
            else
            {
                if (request.ScreenID.HasValue)
                {
                    query = query.Where(e => e.Screen.Id == request.ScreenID);
                }

            }
            var result = await query
                               .Include(e => e.Screen)
                               .Include(e => e.DocumentType)
                               .Select(e => new DocumentTypeModel()
                               {
                                   ID = e.Id,
                                   Name = e.DocumentType.Name,
                                   DocumentTypeId = e.DocumentType.Id,
                                   ScreenID = e.ScreenId,
                                   Category=e.DocumentType.Category

                               }).ToListAsync();


            if (!String.IsNullOrEmpty(request.Category))
            {
                result = result.Where(e => e.Category == request.Category).ToList();
            }

            return result;

        }
    }
}
