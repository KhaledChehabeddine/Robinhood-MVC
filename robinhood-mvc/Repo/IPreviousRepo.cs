using robinhood_mvc.Models;

namespace robinhood_mvc.Repo;

public interface IPreviousRepo
{
    void Create(Previous previous);

    Previous Get(int id);

    List<Instructor> GetAll();

    void Edit(Previous newPrevious);

    void Delete(int id);
}