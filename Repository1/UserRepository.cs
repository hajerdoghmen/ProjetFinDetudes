using ProjetFinDetudes.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Text;

namespace ProjetFinDetudes.Repository
{
    public class UserRepository
    {
        public User GetUsersById (int UserId)
        {
            User user = new User();
            
            using (SqlConnection conn = new SqlConnection(SqlConstant.ConnectionString))
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
                        
                        //int i = 5;
                        //double d = 4.6;

                        //d = i; // cast implicit (specifique on lui met un generique)user.Sex = (Sex) Enum.Parse(typeof(Sex), (string)rdr["Sex"]);
                        user.UserId = UserId;
                        //i = (int)d;

                        //Animal a = new Animal();
                        //Chien c = new Chien();

                        //a = c;
                        //Animal aa = new Chien();

                        //c = (Chien)a;

                        //Dictionary<int, string> df = new Dictionary<int, string>();
                        //df.Add(3,"val");
    
                    }
            }
            return user;
        }
    }

    public class Animal { }
    public class Chien : Animal { }
}
