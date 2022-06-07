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
    public class GetBankList : IRequest<List<BankModel>>
    {
        public int ID { get; set; }
    }
    public class GetBankListHandler : IRequestHandler<GetBankList, List<BankModel>>
    {
        private AppDbContext Context { get; set; }
        public GetBankListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<BankModel>> Handle(GetBankList request, CancellationToken cancellationToken)
        {
            var query = Context.Banks.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new BankModel
            {
                ID = e.Id,
                Name = e.Name
            }).ToListAsync();
        }
    }
}
