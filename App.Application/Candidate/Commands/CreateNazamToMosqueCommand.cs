using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Persistence.Context;
using Clean.Common.Exceptions;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Candidate.Commands
{
    public class CreateNazamToMosqueCommand : IRequest<List<SearchNazamToMosqueModel>>
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public int MosqueId { get; set; }
        public int? LocationId { get; set; }
        public int? TrainingTime { get; set; }
    }
    public class CreateNazamToMosqueCommandHandler : IRequestHandler<CreateNazamToMosqueCommand, List<SearchNazamToMosqueModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateNazamToMosqueCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchNazamToMosqueModel>> Handle(CreateNazamToMosqueCommand request, CancellationToken cancellationToken)
        {


            int nazemscore = context.ExamScores.Where(e => e.CandidateId == request.CandidateId).Select(e => e.TotalMarks).SingleOrDefault();

            if(nazemscore == 0)
            {
                throw new BusinessRulesException("ناظم مذکور امتحان را سپری ننموده است بنا قابل تعیین به مسجد را نمیباشد.");
            }
            int CurrentUserId = await currentUser.GetUserId();
            var NazamToMosque = request.Id != 0 ? context.NazamToMosques.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.NazamToMosque();
            IEnumerable<SearchNazamToMosqueModel> result = new List<SearchNazamToMosqueModel>();
            NazamToMosque.Id = request.Id;
            NazamToMosque.CandidateId = request.CandidateId;
            NazamToMosque.MosqueId = request.MosqueId;
            NazamToMosque.TrainingTime = request.TrainingTime;
            NazamToMosque.LocationId = request.LocationId;

            if (request.Id == 0)
            {
                NazamToMosque.ModifiedBy = "";
                NazamToMosque.ModifiedOn = DateTime.Now;
                NazamToMosque.CreatedBy = CurrentUserId;
                NazamToMosque.CreatedOn = DateTime.Now;
                context.NazamToMosques.Add(NazamToMosque);
            }
            else
            {
                NazamToMosque.ModifiedBy += "," + CurrentUserId; ;
                NazamToMosque.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchNazamToMosqueQuery() { Id = NazamToMosque.Id });
            return result.ToList();

        }
    }
}
