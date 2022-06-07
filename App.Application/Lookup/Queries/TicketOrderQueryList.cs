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
   public class TicketOrderQueryList : IRequest<List<TicketOrderModel>>
    {
        public int ID { get; set; }
    }
    public class TicketOrderQueryListHandler : IRequestHandler<TicketOrderQueryList, List<TicketOrderModel>>
    {
        private AppDbContext Context { get; set; }
        public TicketOrderQueryListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<TicketOrderModel>> Handle(TicketOrderQueryList request, CancellationToken cancellationToken)
        {
            var query = Context.TicketOrders.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new TicketOrderModel
            {
                Id = e.Id,
                Name = e.Name
            }).ToListAsync();
        }


    }
}


