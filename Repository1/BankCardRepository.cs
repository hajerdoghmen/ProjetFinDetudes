using ProjetFinDetudes.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ProjetFinDetudes.Repository
{
    public class BankCardRepository
    {
        public List<BankCard> GetBankCardByUserId (int userId)
        {
            List<BankCard> bankCards = new List<BankCard>();
                 
            using (SqlConnection conn = new SqlConnection(SqlConstant.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PS_GetBankCardByUserId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UserId", userId));
                using (SqlDataReader rdr = cmd.ExecuteReader())
                { 
                    while (rdr.Read())
                    {
                        var bankCard = new BankCard(); 
                        bankCard.CardNumber = (string)rdr["CardNumber"];
                        bankCard.ExpirationDate = (DateTime)rdr["ExpirtionDate"];
                        bankCard.Name = (string)rdr["Label"];
                        bankCard.SecurityCode = (int)rdr["SecurityCode"];
                        bankCards.Add(bankCard);

                    }
                }
            }
            //if bech nrecuperi element we7d wala 0
            //    whle recupere plusieurs elements de 0 à n
              
            return bankCards;
        }
    }
}
