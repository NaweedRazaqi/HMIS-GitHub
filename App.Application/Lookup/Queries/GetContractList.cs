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
    public class GetContractList : IRequest<List<ContractModel>>
    {
        public int ID { get; set; }
    }
    public class GetContractListHandler : IRequestHandler<GetContractList, List<ContractModel>>
    {
        private AppDbContext Context { get; set; }
        public GetContractListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<ContractModel>> Handle(GetContractList request, CancellationToken cancellationToken)
        {
            var query = Context.Contracts.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new ContractModel
            {
                Id = e.Id,
                ContractNumber = e.ContractNumber,
                CompanyName = e.CompanyName,
                ContractDetails = e.CompanyName + " (" + e.ContractNumber +  ")",
            }).ToListAsync();
        }
    }
}
