using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EbookReader.Models.ViewModels
{
    public class UploadBookViewModel
    {
        public string BookName { get; set; }
        public IFormFile BookFile { get; set; }
    }
}
