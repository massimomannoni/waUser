﻿using System;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using waUser.Constants;
using waUser.Models;
using System.Collections.Generic;
using waUser.Contracts;

namespace waUser.Dal
{
    internal class RepoUser : DBFunctions, IRepository<User, ResponseUser>
    {
        internal async Task<ResponseUser> Add(User user)
        {
            ResponseUser result;

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

                        result = new ResponseUser(true, string.Empty, true);

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

        public Task<ResponseUser> Delete(User value)
        {
            throw new NotImplementedException();
        }

        internal async Task<ResponseUser> GetAll()
        {
            ResponseUser result;

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

                        result = new ResponseUser(true, string.Empty, users);

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

        public Task<User> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseUser> Update(User value)
        {
            throw new NotImplementedException();
        }

        Task<ResponseUser> IRepository<User, ResponseUser>.Add(User value)
        {
            throw new NotImplementedException();
        }

        Task<User> IRepository<User, ResponseUser>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
