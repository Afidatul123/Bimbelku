using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bimbelku.Services
{
    public class FileService
    {
        IWebHostEnvironment _file;
        public FileService(IWebHostEnvironment f)
        {
            _file = f;
        }

        public async Task<string> AddFile(IFormFile file)
        {
            string folderBaru = "FOLDER";
            if (file == null)
            {
                return string.Empty;
            }

            var savepath = Path.Combine(_file.WebRootPath, folderBaru);

            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);
            }

            var filebaru = file.FileName;
            var fileaddres = Path.Combine(savepath, filebaru);

            using (var stream = new FileStream(fileaddres, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Path.Combine("/" + folderBaru + "/", filebaru);
        }

    }
}
