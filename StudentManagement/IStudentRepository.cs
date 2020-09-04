using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement
{
    public interface IStudentRepository
    {
        Student GetStudent(int id);

        IEnumerable<Student> GetAllStudents();
    }
}
