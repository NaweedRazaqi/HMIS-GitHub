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
   public class TicketDiscountQueryList : IRequest<List<TicketDiscountModel>>
    {
        public int ID { get; set; }
    }
    public class TicketDiscountQueryListHandler : IRequestHandler<TicketDiscountQueryList, List<TicketDiscountModel>>
    {
        private AppDbContext Context { get; set; }
        public TicketDiscountQueryListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<TicketDiscountModel>> Handle(TicketDiscountQueryList request, CancellationToken cancellationToken)
        {
            var query = Context.TicketDiscounts.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new TicketDiscountModel
            {
                Id = e.Id,
                Name = e.Name
            }).ToListAsync();
        }


    }
}


