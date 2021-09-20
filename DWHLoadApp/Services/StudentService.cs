using DWHLoadApp.Interface;
using DWHLoadApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DWHLoadApp.Services
{
    public class StudentService : IStudentService
    {
        public void AddStudent()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudent()
        {
            List<Student> StudentList = new List<Student>();
            return StudentList;
        }

        public Student GetStudentById()
        {
            return new Student();  
        }
    }
}
