namespace GestionEtudiant.Models.Repositories
{
    public class SchoolRepository : ISchoolRepository
    { 
readonly StudentContext context;
    public SchoolRepository(StudentContext context)
    {
        this.context = context;
    }
    public IList<School> GetAll()
    {
        return context.Schools.OrderBy(s => s.SchoolName).ToList();
    }
    public School GetById(int id)
    {
        return context.Schools.Find(id);
    }
    public void Add(School s)
    {
        context.Schools.Add(s);
        context.SaveChanges();
    }
    public void Edit(School s)
    {
        School s1 = context.Schools.Find(s.SchoolID);
        if (s1 != null)
        {
            s1.SchoolName = s.SchoolName;
            s1.SchoolAdress = s.SchoolAdress;
            context.SaveChanges();
        }
    }
    public void Delete(School s)
    {
        School s1 = context.Schools.Find(s.SchoolID);
        if (s1 != null)
        {
            context.Schools.Remove(s1);
            context.SaveChanges();
        }
    }
    public double StudentAgeAverage(int schoolId)
    {
        if (StudentCount(schoolId) == 0)
            return 0;
        else
            return context.Students.Where(s => s.SchoolID ==
            schoolId).Average(e => e.Age);
    }
    public int StudentCount(int schoolId)
    {
        return context.Students.Where(s => s.SchoolID ==
        schoolId).Count();
    }
}
}
