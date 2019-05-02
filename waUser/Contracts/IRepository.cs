using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using waUser.Models;

namespace waUser.Contracts
{
    // T represent a model R a response. 
    // R intherit from base response due the fact of differents derived class requirements.
    internal interface IRepository<T,R> where R : IBaseResponse where T : class
    {

        // return a list  of T model
        Task<R> GetAll();

        Task<R> Add(T value);


    }
}
