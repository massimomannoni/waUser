using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using waUser.Models;
using waUser.Dal;

namespace waUser.BLL
{
    internal static class BLLUser
    { 
        internal static async Task<ResponseUser> Add(User user)
        {
            RepoUser repoUser = new RepoUser();
            ResponseUser response;

            try
            {
                response = await Task.FromResult(repoUser.Add(user)).Result;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                repoUser = null;
            }
            return response;
        }
    }
}
