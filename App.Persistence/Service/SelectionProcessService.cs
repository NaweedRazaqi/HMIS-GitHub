using App.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using App.Domain.Entity.prf;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Clean.Common.Dates;

namespace App.Persistence.Service
{
    public class SelectionProcessService : BackgroundService
    {
        private IServiceProvider Provider { get; }
        private ILogger<SelectionProcessService> Logger { get; }
        private System.Timers.Timer MainTimer { get; }
        public SelectionProcessService(IServiceProvider provider, ILogger<SelectionProcessService> logger)
        {
            Provider = provider;
            Logger = logger;
            MainTimer = new System.Timers.Timer();

        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            MainTimer.Interval = TimeSpan.FromSeconds(10).TotalMilliseconds;
            MainTimer.Elapsed += MainTimer_Elapsed;
            MainTimer.Start();
            return Task.CompletedTask;
        }

        private void MainTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Logger.LogInformation("Service Is Called{0}", DateTime.Now);
            MainTimer.Stop();

            try
            {
                Logger.LogWarning("Selection Service Running!");

                using var scope = Provider.CreateScope();

                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var enYear = PersianToEnglish(PersianDate.ToPersianDate(DateTime.Now).Substring(0, 4));
                var yId = context.Years.Where(e => e.Name.ToString() == enYear).Select(e => e.Id).SingleOrDefault();

                var candidate = context.Candidates.Where(c => c.IsSelected == false && c.HajiStatusId==1 && c.CandidateTypeId==1).OrderBy(c => c.CreatedOn).ToList();

                candidate.ForEach(h =>
                {
                        var addtoqueue = new Domain.Entity.prf.SelectQueue
                        {
                            FirstName = h.FirstName,
                            LastName = h.LastName,
                            FatherName = h.FatherName,
                            CandidateId = h.Id,
                            GenderId = h.GenderId,
                            CreatedOn = h.CreatedOn,
                            SelectedOn = h.CreatedOn,
                            Status = h.HajiStatusId,
                            CurrentYearsId=h.YearId

                        };
                        try
                        {
                            context.SelectQueues.Add(addtoqueue);
                            context.SaveChanges();

                            // updating Candidate table

                            try
                            {
                                Candidate candidat = new Candidate();
                                candidat = context.Candidates.Where(c => c.Id == addtoqueue.CandidateId).SingleOrDefault();
                                candidat.IsSelected = true;
                                candidat.HajiStatusId = 2;
                                context.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                Logger.LogInformation(ex, "");
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.LogInformation(ex, "");
                            //return new JsonResult(CustomMessages.FabricateException(ex));
                        }
                });

                context.SaveChanges();
                Logger.LogInformation("Counted Records are as follow {0}");

            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Exception Counting  Records :");
            }
            finally
            {
                MainTimer.Start();
            }

        }

        private string[] persion = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
        private string[] english = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public string PersianToEnglish(string strNum)
        {
            string chash = strNum;
            for (int i = 0; i < 10; i++)
                chash = chash.Replace(persion[i], english[i]);
            return chash;
        }
    }
}
