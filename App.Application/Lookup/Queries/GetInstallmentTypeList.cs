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
    public class GetInstallmentTypeList : IRequest<List<InstallmentTypeModel>>
    {
        public int ID { get; set; }
    }
    public class GetInstallmentTypeListHandler : IRequestHandler<GetInstallmentTypeList, List<InstallmentTypeModel>>
    {
        private AppDbContext Context { get; set; }
        public GetInstallmentTypeListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<InstallmentTypeModel>> Handle(GetInstallmentTypeList request, CancellationToken cancellationToken)
        {
            var query = Context.InstallmentTypes.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new InstallmentTypeModel
            {
                ID = e.Id,
                Name = e.Name,
                Dari = e.Dari,
            }).ToListAsync();
        }
    }
}
