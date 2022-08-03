using robinhood_mvc.Models;

namespace robinhood_mvc.Repo;

public interface ICourseRepo
{
    void Create(Course course);

    Course Get(int id);

    List<Course> GetAll();

    void Edit(Course newCourse);

    void Delete(int id);
}