using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using waUser.Models;

namespace waUser.Contracts
{
    // T represent a model R a response. 
    // R intherit from base response due the fact of differents derived class requirements.
    internal interface IRepository<T,R> where R : BaseResponse
    {
        // return a single T model 
        Task<T> GetByID(int id);

        // return a list  of T model
        Task<T> GetAll();

        Task<R> Add(T value);

        Task<R> Update(T value);

        Task<R> Delete(T value);

    }
}
