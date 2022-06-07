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
    public class GetExpenseCentersList : IRequest<List<ExpenseCentersModel>>
    {
        public int ID { get; set; }
    }
    public class GetExpenseCentersQueryHandler : IRequestHandler<GetExpenseCentersList, List<ExpenseCentersModel>>
    {
        private AppDbContext Context { get; set; }
        public GetExpenseCentersQueryHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<ExpenseCentersModel>> Handle(GetExpenseCentersList request, CancellationToken cancellationToken)
        {
            var query = Context.ExpenseCenters.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new ExpenseCentersModel
            {
                Id = e.Id,
                Name = e.Name,
                Dari = e.Dari,
            }).ToListAsync();
        }
    }
}
