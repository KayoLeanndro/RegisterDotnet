using System.Collections.Generic;
namespace DIO.Series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        T ReturnById(int id);
        void Insert(T BaseEntity);
        void Delete(int id);
        void Update(int id, T BaseEntity);
        int NextId();
    }   
}