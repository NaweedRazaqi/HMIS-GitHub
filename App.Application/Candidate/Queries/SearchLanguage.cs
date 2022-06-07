using App.Application.Candidate.Models;
using App.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Candidate.Queries
{
  public  class SearchLanguage : IRequest<List<SearchLanguageModel>>
    {
        public int? Id { get; set; }
    }
    public class SearchLanguageHandler : IRequestHandler<SearchLanguage, List<SearchLanguageModel>>
    {
        private AppDbContext Context { get; set; }
        public SearchLanguageHandler(AppDbContext context)
        {
            this.Context = context;
        }

        public async Task<List<SearchLanguageModel>> Handle(SearchLanguage request, CancellationToken cancellationToken)
        {
            var langs = Context.Languages.AsQueryable();
            if (request.Id.HasValue)
            {
                langs = langs.Where(e => e.Id == request.Id);
            }
            return await langs.Select(e => new SearchLanguageModel
            {
                Id = e.Id,
                Text = e.Text,
                Local = e.Local

            }).ToListAsync();
        }
    }
}
