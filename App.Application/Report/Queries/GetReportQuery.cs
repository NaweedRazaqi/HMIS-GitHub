using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using App.Application.Report.Models;
using App.Persistence.Context;
using App.Domain.Entity.rep;

namespace App.Application.Report.Queries
{
    public class GetReportQuery : IRequest<List<SearchedReportModel>>
    {
        public int TableID { get; set; }
        public int ColumnID { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set;  }
        public string GraphType { get; set;  }

        
    }

    public class GetReportQueryHandler : IRequestHandler<GetReportQuery, List<SearchedReportModel>>
    {
        private readonly AppDbContext context;
        private IMediator mediator;
        public GetReportQueryHandler(AppDbContext dbContext, IMediator mediator)
        {
            context = dbContext;
            this.mediator = mediator;
        }
        public async Task<List<SearchedReportModel>> Handle(GetReportQuery request, CancellationToken cancellationToken)
        {


            string SDate =request.StartDate+" 00:00:00";
            string EDate = request.EndDate+" 23:59:59";

            List<Dbobject> TableList = await mediator.Send(new SearchDBObjectQuery() { ID = request.TableID });
            List<Dbobject> ColumnList = await mediator.Send(new SearchDBObjectQuery() { ID = request.ColumnID });

            Dbobject MainTable = new Dbobject();
            Dbobject SubTable = new Dbobject();

            if (TableList.Any())
            {
                MainTable = TableList.FirstOrDefault();
            }
            if (ColumnList.Any())
            {
                SubTable = ColumnList.FirstOrDefault();
            }


            // var query = context.Database.ex
            List<SearchedReportModel> Result = new List<SearchedReportModel>();
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                string Query="";
                if (((request.GraphType)==("Chart COLUMNS Plus")) || ((request.GraphType)==("Chart BAR Plus")))
                {  
                    Query = @"SELECT S.'$Name' Label, (Datename(YYYY, M.CreatedOn)+'-'+Datename(MM, M.CreatedOn)) as Dates, COUNT(1) RecordCount
                                 FROM $MainTable M
                                 INNER JOIN $SubTable S ON S.$PKey = M.$FKey
                                  WHERE M.CreatedOn BETWEEN '$SDate' AND '$EDate' Group by S.$Name ,  (Datename(YYYY, M.CreatedOn)+'-'+Datename(MM, M.CreatedOn))
                                ";
                    Query = Query.Replace("$MainTable", MainTable.Dbname).Replace("$SubTable", SubTable.Dbname)
                        .Replace("$PKey", SubTable.Pkey).Replace("$FKey", SubTable.Fkey)
                        .Replace("$Name", SubTable.Title).Replace("$SDate", SDate).Replace("$EDate", EDate);

                }
                else
                {
                    Query = @"SELECT S.$Name as  Label, COUNT(1) RecordCount
                                 FROM $MainTable M
                                 INNER JOIN $SubTable S ON S.$PKey = M.$FKey
                                 WHERE M.$DateReport BETWEEN '$SDate' AND '$EDate' Group by S.$Name
                                ";
                    Query = Query.Replace("$MainTable", MainTable.Dbname).Replace("$SubTable", SubTable.Dbname)
                        .Replace("$PKey", SubTable.Pkey).Replace("$FKey", SubTable.Fkey)
                        .Replace("$Name", SubTable.Title).Replace("$SDate", SDate).Replace("$EDate", EDate).Replace("$DateReport",'"'+"CreatedOn"+'"');
                }

                command.CommandText = Query;
                context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    if (((request.GraphType)==("Chart COLUMNS Plus")) || ((request.GraphType)==("Chart BAR Plus"))){
                        while (reader.Read())
                        {
                            Result.Add(new SearchedReportModel()
                            {
                                name = reader["Label"].ToString(), 
                                value = Convert.ToInt32(reader["RecordCount"].ToString()),
                                date = reader["Dates"].ToString()
                            });
                        
                        }
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            Result.Add(new SearchedReportModel()
                            {
                                name = reader["Label"].ToString(), 
                                value = Convert.ToInt32(reader["RecordCount"].ToString())
                            });
                        
                        }

                    }
                }
            }
            return Result;
        }
    }
}
