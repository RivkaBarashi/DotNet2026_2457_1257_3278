

namespace DalApi;

public interface IDalApi<T>
{
    int Create(T item);
    T? Read(int id);
    List<T> ReadAll();
    void Update(T item);
    void Delete(int id);
}

