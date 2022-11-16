using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IStudentRepository
    {
        Student GetStudent(int id);
        IList<Student> GetStudents();
        Student CreateStudent(Student student);
        Student UpdateStudent(int id, Student student);
        Student DeleteStudent(int id);
    }
}
