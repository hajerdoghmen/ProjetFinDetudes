
using PFE.Domain;
using Repository;
using Repository.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PFE.Repository
{
    public class BankCardRepository : IBankCardRepository
    {
        private readonly string connString;
            public BankCardRepository (IDbConnection dbConnection)
        {
            connString = dbConnection.ConnectionString;
        }

        private const string PS_GetBankCardByUserId = "PS_GetBankCardByUserId";
        public List<BankCard> GetBankCardByUserId (int userId)
        {
           var bankCards = new List<CreditCardDAL>();       
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(PS_GetBankCardByUserId, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UserId", userId));
                using (SqlDataReader rdr = cmd.ExecuteReader())
                { 
                    while (rdr.Read())
                    {
                        var bankCard = new CreditCardDAL(); 
                        bankCard.CardNumber = (string)rdr["CardNumber"];
                        bankCard.ExpirationDate = (DateTime)rdr["ExpirtionDate"];
                        bankCard.Name = (string)rdr["Label"];
                        bankCard.SecurityCode = (int)rdr["SecurityCode"];
                        bankCards.Add(bankCard);

                    }
                }
            }
            var userCreditCard = bankCards.Select(bankCard => bankCard.ToDoamin()).ToList();
            return userCreditCard;
        }
    }
}
//if bech nrecuperi element we7d wala 0
//    whle recupere plusieurs elements de 0 à n

