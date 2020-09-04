using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.ViewModels;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _repository;
        public HomeController(IStudentRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.GetAllStudents());
        }

        public IActionResult Details(int? id)
        {
            Student stu = _repository.GetStudent(id??1);
            HomeDetailsViewModel model = new HomeDetailsViewModel()
            {
                Student = stu,
                Title = "the student detail"
            };
            return View(model);
        }
    }
}
