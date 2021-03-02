using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetFinDetudes.Repository
{
    public class SqlConstant
    {
        //prop static
        // public static string ConnectionString { get { return @"Data Source=.\SQLExpress;DataBase=PFE;Integrated Security=SSPI"; } }

        //var static
        //public static string ConnectionString = @"Data Source=.\SQLExpress;DataBase=PFE;Integrated Security=SSPI";

        // const = static + non modifiable (non utilisable lel prop)
        public const string ConnectionString = @"Data Source=.\SQLExpress;DataBase=PFE;Integrated Security=SSPI";

        //fi c# fama readonly zeda :
        //public  readonly  string ConnectionString = @"Data Source=.\SQLExpress;DataBase=PFE;Integrated Security=SSPI";

        //diff entre readonly et const (const est static)
        //=> const on lui donne la valeur uniquement lors de la création
        //readonly la valeur est donné lors de la création ou dans le constructeur
        //=> les deux on peut donner la valeur lors de la creation, readonly on peut aussi dans le constructeur, pas possible dans le constr
        //pour const car la variable est statique (appartient lel class pas à l'objet)

        //public SqlConstant()
        //{
        //    ConnectionString = "xxx";
        //}

    }
}
