using DWHLoadApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DWHLoadApp.Interface
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudent();

        Student GetStudentById();

        void AddStudent();

    }
}
