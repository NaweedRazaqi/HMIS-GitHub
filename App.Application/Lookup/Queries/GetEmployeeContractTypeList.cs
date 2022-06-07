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
    public class GetEmployeeContractTypeList : IRequest<List<EmployeeContractTypeModel>>
    {
        public int ID { get; set; }
    }
    public class GetEmployeeContractTypeListHandler : IRequestHandler<GetEmployeeContractTypeList, List<EmployeeContractTypeModel>>
    {
        private AppDbContext Context { get; set; }
        public GetEmployeeContractTypeListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<EmployeeContractTypeModel>> Handle(GetEmployeeContractTypeList request, CancellationToken cancellationToken)
        {
            var query = Context.EmployeeContractTypes.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new EmployeeContractTypeModel
            {
                ID = e.Id,
                Name = e.Name,
                Dari = e.Dari,
            }).ToListAsync();
        }
    }
}
