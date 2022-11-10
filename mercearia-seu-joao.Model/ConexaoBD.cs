using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercearia_seu_joao.Model
{
    public class ConexaoBD
    {
        public static MySqlConnectionStringBuilder Connection
        {
            get
            {
                return new MySqlConnectionStringBuilder
                {
                    Server = "127.0.0.1",
                    UserID = "root",
                    Password = "",
                    Database = "MerceariaDoJoao"
                };
            }
            private set
            {

            }
        }
    }
}
