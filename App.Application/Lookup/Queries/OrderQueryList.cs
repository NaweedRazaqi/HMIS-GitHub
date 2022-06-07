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
   public class OrderQueryList : IRequest<List<OrderModel>>
    {
        public int ID { get; set; }
    }
    public class OrderQueryListHandler : IRequestHandler<OrderQueryList, List<OrderModel>>
    {
        private AppDbContext Context { get; set; }
        public OrderQueryListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<OrderModel>> Handle(OrderQueryList request, CancellationToken cancellationToken)
        {
            var query = Context.Orders.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new OrderModel
            {
                Id = e.Id,
                Name = e.Name
            }).ToListAsync();
        }

        
    }
}

