using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class MockStudentRepository : IStudentRepository
    {
        readonly List<Student> students;
        public MockStudentRepository()
        {
            students = new List<Student>()
            {
                new Student(){ID=1,Name="张三",Email="zhangsan@163.com",ClassName="1"},
                new Student(){ID=2,Name="李四",Email="lisi@163.com",ClassName="1"},
                new Student(){ID=3,Name="王五",Email="wangwu@163.com",ClassName="1"}
            };
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return students;
        }

        public Student GetStudent(int id)
        {
            return students.FirstOrDefault(stu => stu.ID == id);
        }
    }
}
