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
    public class GetCurrencyList : IRequest<List<CurrencyModel>>
    {
        public int ID { get; set; }
    }
    public class GetCurrencyListHandler : IRequestHandler<GetCurrencyList, List<CurrencyModel>>
    {
        private AppDbContext Context { get; set; }
        public GetCurrencyListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<CurrencyModel>> Handle(GetCurrencyList request, CancellationToken cancellationToken)
        {
            var query = Context.Currencies.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new CurrencyModel
            {
                ID = e.Id,
                Dari = e.Dari,
                Name = e.Name,
            }).ToListAsync();
        }
    }
}
