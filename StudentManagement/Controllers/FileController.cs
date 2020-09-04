using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StudentManagement.Attributes;
using StudentManagement.helpers;
using StudentManagement.ViewModels;

namespace StudentManagement.Controllers
{
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
           // Console.WriteLine(_hostingEnvironment.WebRootPath);
            return View();
        }
        /// <summary>
        /// 对应单个图片的视图显示
        /// </summary>
        /// <returns></returns>
        public IActionResult Show()
        {
            return View();
        }
        /// <summary>
        /// 处理单个图片的上传
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            var desPosition = Path.Combine(_hostingEnvironment.WebRootPath, "Image", "upload.jpg");
            using (var stream = new FileStream(desPosition, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            
            return RedirectToAction("Show");
        }

        [HttpPost]
        [DisableFormValueModelBinding]
        public async Task<IActionResult> BigFileUpload()
        {
            FormValueProvider formModel;
            formModel = await Request.StreamFiles(@"D:\Root");
            var model = new BigFileViewModel();
            var bindSucceessful = await TryUpdateModelAsync(model, prefix: "", valueProvider: formModel);
            if (!bindSucceessful)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
            }
            return Ok(model);
        }
    }
}
