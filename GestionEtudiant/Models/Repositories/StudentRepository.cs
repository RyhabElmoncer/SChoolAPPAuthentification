using Microsoft.EntityFrameworkCore;

namespace GestionEtudiant.Models.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        readonly StudentContext context;
        public StudentRepository(StudentContext context)
        {
            this.context = context;
        }
        public IList<Student> GetAll()
        {
            return context.Students.OrderBy(x => x.StudentName).Include(x
            => x.School).ToList();
        }
        public Student GetById(int id)
        {
            return context.Students.Where(x => x.StudentId ==
            id).Include(x => x.School).SingleOrDefault();
        }
        public void Add(Student s)
        {
            context.Students.Add(s);
            context.SaveChanges();
        }
        public void Edit(Student s)
        {
            Student s1 = context.Students.Find(s.StudentId);
            if (s1 != null)
            {
                s1.StudentName = s.StudentName;
                s1.Age = s.Age;
                s1.BirthDate = s.BirthDate;
                s1.SchoolID = s.SchoolID;
                context.SaveChanges();
            }
        }
        public void Delete(Student s)
        {
            Student s1 = context.Students.Find(s.StudentId);
            if (s1 != null)
            {
                context.Students.Remove(s1);
                context.SaveChanges();
            }
        }
        public IList<Student> GetStudentsBySchoolID(int? schoolId)
        {
            return context.Students.Where(s =>
            s.SchoolID.Equals(schoolId))
            .OrderBy(s => s.StudentName)
            .Include(std => std.School).ToList();
        }
        public IList<Student> FindByName(string name)
        {
            return context.Students.Where(s =>
            s.StudentName.Contains(name)).Include(std =>
            std.School).ToList();
        }
    }

}
