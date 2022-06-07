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
    public class GetExpenseTypesList : IRequest<List<ExpenseTypesModel>>
    {
        public int ID { get; set; }
    }
    public class GetExpenseTypesListHandler : IRequestHandler<GetExpenseTypesList, List<ExpenseTypesModel>>
    {
        private AppDbContext Context { get; set; }
        public GetExpenseTypesListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<ExpenseTypesModel>> Handle(GetExpenseTypesList request, CancellationToken cancellationToken)
        {
            var query = Context.ExpenseTypes.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new ExpenseTypesModel
            {
                Id = e.Id,
                Name = e.Name,
                Dari = e.Dari,
            }).ToListAsync();
        }
    }
}
