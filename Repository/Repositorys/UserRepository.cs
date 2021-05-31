
using PFE.Domain;
using PFE.Repository.DAL;
using Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Text;

namespace PFE.Repository
{
    public class UserRepository :IUserRepository
    {
        private readonly string connString;
        public UserRepository(IDbConnection dbConnection)
        {
            connString = dbConnection.ConnectionString;
        }
        public User GetUsersById (int UserId)
        {
            var user = new UserDAL();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PS_GetUserById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UserId", UserId));
                using (SqlDataReader rdr = cmd.ExecuteReader())
                    while (rdr.Read())
                    {
                        user.FirstName = (string)rdr["FirstName"];
                        user.LastName =(string)rdr["LastName"];
                        user.DateOfBirth = (DateTime)rdr["DateOfBirth"];
                        user.Sex = (string)rdr["Sex"];
                        user.UserId = UserId;
                    }
            }
            return user.ToDomain ();
        }
    }
}
