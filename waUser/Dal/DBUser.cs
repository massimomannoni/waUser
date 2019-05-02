using System;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using waUser.Constants;
using waUser.Models;
using System.Collections.Generic;
using waUser.Contracts;

namespace waUser.Dal
{
    internal class RepoUser : DBFunctions, IRepository<User, IBaseResponse>
    {

        public async Task<IBaseResponse> Add(User user)
        {
            ResponseAddUser result;

            try
            {
                using (SqlConnection conn = NewConnection())
                {
                    using (SqlCommand cmd = NewCommand(conn, "InsUser", CommandType.StoredProcedure,
                      Param("@Email", user.Email, SqlDbType.VarChar),
                      Param("@Password", user.Password, SqlDbType.VarChar),
                      Param("@Confirmed", user.Confirmed, SqlDbType.Bit)))
                    {
                        await conn.OpenAsync();

                        cmd.CommandTimeout = DataBase.COMMANDTIMEOUT;

                        await cmd.ExecuteNonQueryAsync();

                        result = new ResponseAddUser(true, string.Empty, true);

                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public async Task<IBaseResponse> GetAll()
        {
            ResponseGetUsers result;

            List<User> users = new List<User>();

            try
            {
                using (SqlConnection conn = NewConnection())
                {
                    using (SqlCommand cmd = NewCommand(conn, "GetUsers", CommandType.StoredProcedure))
                    {
                        await conn.OpenAsync();

                        cmd.CommandTimeout = DataBase.COMMANDTIMEOUT;

                        using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                        {
                            while (await dr.ReadAsync())
                            {
                                User user = new User();
                                user.UserID = (long)dr["UserID"];
                                user.Email = (string)dr["Email"];
                                user.Password = (string)dr["Password"];
                                user.Confirmed = (bool)dr["Confirmed"];
                                user.CreationDate = (DateTime)dr["CreationDate"];
                                users.Add(user);
                            }

                            dr.Close();
                        }

                        result = new ResponseGetUsers(true, string.Empty, users);

                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

       
    }
}
