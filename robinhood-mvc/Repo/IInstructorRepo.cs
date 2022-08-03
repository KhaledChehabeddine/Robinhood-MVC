using robinhood_mvc.Models;

namespace robinhood_mvc.Repo;

public interface IInstructorRepo
{
    void Create(Instructor course);

    Instructor Get(int id);

    List<Instructor> GetAll();

    void Edit(Instructor newInstructor);

    void Delete(int id);
}