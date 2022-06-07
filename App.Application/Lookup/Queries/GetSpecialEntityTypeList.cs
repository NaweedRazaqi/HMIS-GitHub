using App.Application.Lookup.Models;
using App.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Lookup.Queries
{
    public class GetSpecialEntityTypeList : IRequest<List<SpecialEntityTypeModel>>
    {
        public int Id { get; set; }
        public int? TypeId { get; set; }
        public int? ParentId { get; set; }
    }
    public class GetSpecialEntityTypeListHandler : IRequestHandler<GetSpecialEntityTypeList, List<SpecialEntityTypeModel>>
    {
        private AppDbContext Context { get; set; }
        public GetSpecialEntityTypeListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<SpecialEntityTypeModel>> Handle(GetSpecialEntityTypeList request, CancellationToken cancellationToken)
        {
            List<SpecialEntityTypeModel> list = new List<SpecialEntityTypeModel>();

            var query = Context.SpecialEntityTypes.AsQueryable();

            if (request.ParentId.HasValue)
            {
                query = query.Where(L => L.ParentId == request.ParentId);
            }
            if (request.TypeId.HasValue)
            {
                query = query.Where(L => L.TypeId == request.TypeId);
            }

            list = await (from o in query
                          select new SpecialEntityTypeModel
                          {
                              Id = o.Id,
                              Name = o.Name,
                              Dari = o.Dari,
                          }).ToListAsync(cancellationToken);
            return list;

        }
    }
}
