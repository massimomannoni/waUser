using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using waUser.Models;

namespace waUser.Contracts
{
    // T represent a model R a response which implements a IBaseResponse interface
    internal interface IRepository<T,R>  where T : class where R : IBaseResponse
    {
        Task<R> GetAll();

        Task<R> Add(T value);

    }
}
