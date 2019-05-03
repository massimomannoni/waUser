using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using waUser.Models;
using waUser.Dal;
using waUser.Contracts;

namespace waUser.BLL
{
    internal static class BLLUser
    { 
        internal static async Task<ResponseAddUser> Add(User user)
        {
            RepoUser repoUser = new RepoUser();
            IBaseResponse response;

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

            return response as ResponseAddUser;
        }

        internal static async Task<ResponseGetUsers> GetAll()
        {
            RepoUser repoUser = new RepoUser();
            IBaseResponse response;

            try
            {
                response = await Task.FromResult(repoUser.GetAll()).Result;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                repoUser = null;
            }

            return response as ResponseGetUsers;
        }
    }
}
