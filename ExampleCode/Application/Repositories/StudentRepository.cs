using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        #region Private Members
        private readonly List<Student> _context;
        #endregion

        #region Constructors
        public StudentRepository()
        {
            _context = new List<Student>();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// This method will create new student for supplied student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student CreateStudent(Student student)
        {
            try
            {
                if (student == null)
                    throw new NullReferenceException("The provided parameter, student is null");

                #region There will be no need to the following code if we use DB
                bool isStudentExists = _context.Any(stu => stu.Id == student.Id);
                if (!isStudentExists)
                    throw new Exception("The student is already added to the context");
                #endregion

                _context.Add(student);

                return student;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This method will delete student for supplied id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student DeleteStudent(int id)
        {
            try
            {
                bool isStudentExists = _context.Any(stu => stu.Id == id);
                if (!isStudentExists)
                    throw new NullReferenceException(string.Concat("Can not find the student for supplied id: ", id));

                Student deletedStudent = _context.Find(stu => stu.Id == id);
                _context.Remove(deletedStudent);
                return deletedStudent;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This method will get student for supplied id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student GetStudent(int id)
        {
            try
            {
                Student student = _context.Find(stu => stu.Id == id);
                if (student == null)
                    throw new NullReferenceException(string.Concat("Can not find the student for supplied id: ", id));

                return student;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This method will get all students
        /// </summary>
        /// <returns></returns>
        public IList<Student> GetStudents()
        {
            try
            {
                return _context.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This method will update student for supplied id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student UpdateStudent(int id, Student student)
        {
            try
            {
                Student updatedStudent = _context.Find(stu => stu.Id == id);
                if (updatedStudent == null)
                    throw new NullReferenceException(string.Concat("Can not find the student for supplied id: ", id));

                if (student == null)
                    throw new NullReferenceException("The provided parameter, student is null");

                updatedStudent.Name = student.Name;
                updatedStudent.Surname = student.Surname;
                updatedStudent.BirthDate = student.BirthDate;

                return updatedStudent;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
