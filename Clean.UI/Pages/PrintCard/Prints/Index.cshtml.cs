using App.Application.CandidateCard.Queries;
using Clean.Common;
using Clean.Common.Enums;
using Clean.Common.Storage;
using Clean.UI.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Clean.UI.Pages.PrintCard.Prints
{
    public class IndexModel : BasePage
    {
        private readonly IConfiguration Config;
        public IndexModel(IConfiguration configuration)
        {
            Config = configuration;
        }
        public async Task OnGetAsync([FromQuery] string recordid)
        {
            FileStorage _storage = new FileStorage();
            var Print_Data = await Mediator.Send(new SearchPrintDataQuery { ID = Convert.ToInt32(recordid) });
            Print_Data[0].PhotoPath =await GetFile("ImagesPath",  Print_Data[0].PhotoPath );
            ViewData["Card"] = Print_Data;
        }
        public async Task<string> GetFile(String Dir, String FileName)
        {
            FileStorage _storage = new FileStorage();
            var filepath = Config[Dir] + FileName;
            System.IO.Stream filecontent = await _storage.GetAsync(filepath);

            byte[] filebytes = new byte[filecontent.Length];
            filecontent.Read(filebytes, 0, Convert.ToInt32(filecontent.Length));
            String Result = "data:" + _storage.GetContentType(filepath) + ";base64," + Convert.ToBase64String(filebytes, Base64FormattingOptions.None);
            return Result;
        }
        public async Task<IActionResult> OnGetDownload([FromQuery] string file, [FromQuery] string uploadType)
        {
            FileStorage _storage = new FileStorage();
            var basePath = "";
            if (uploadType == UploadTypes.Photo)
            {
                basePath = AppConfig.ImagesPath;
            }
            else if (uploadType == UploadTypes.Signature)
            {
                basePath = AppConfig.SignaturesPath;
            }
            var filepath = basePath + file;
            System.IO.Stream filecontent = await _storage.GetAsync(filepath);
            var filetype = _storage.GetContentType(filepath);
            return File(filecontent, filetype, file);
        }
    }
}
