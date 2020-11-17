using System.Collections.Generic;

namespace Bounty.Repositories
{
  public interface IRepository<T>
  {
    List<T> Find();
    T FindById(int id);
    T Create(T t);
    T Update(T t);
    bool Delete(int id);
  }
}