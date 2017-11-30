using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EEUDataBase_DLL.Entities;

namespace EEUDataBase_DLL.Interfaces
{
    /*
     * This interface is the base for the CRUD design. 
     */
    public interface IDataBase<T, K> where T : AbstractEntity
    {
        T Create(T t);
        T ReadById(K id);
        List<T> ReadAll();
        T Update(T t);
        bool Delete(K id);


    }
}
