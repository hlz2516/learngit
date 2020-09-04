using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.ViewModels
{
    public class Files
    {
        public List<IFormFile> FileList { get; set; }
    }
}
