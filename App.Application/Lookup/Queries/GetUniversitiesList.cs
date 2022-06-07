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


    public class GetUniversitiesList : IRequest<List<SearchUniversityModel>>
    {
        public int? ID { get; set; }
    }


    public class GetUniversitiesListHandler : IRequestHandler<GetUniversitiesList, List<SearchUniversityModel>>
    {
        private AppDbContext Context { get; set; }

        public GetUniversitiesListHandler(AppDbContext context)
        {
            Context = context;
        }

        public async Task<List<SearchUniversityModel>> Handle(GetUniversitiesList request, CancellationToken cancellationToken)
        {
            var query = Context.Universities.AsQueryable();
            if (request.ID.HasValue)
            {
                query = query.Where(e => e.Id == request.ID);
            }
           
            return await query.Select(e => new SearchUniversityModel

            {
                Id = e.Id,
                Name = e.Name,
               
            }

            ).ToListAsync();
        }
    }
}
