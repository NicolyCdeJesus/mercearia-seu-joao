using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercearia_seu_joao.Model
{
    internal class ConsultarTipoUsuario
    {
        public void ConsultarBD(string nome, string tipoUsuario)
        {
            var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
            try
            {
                //abrindo comando para conectar
                conexao.Open();
                var comando = conexao.CreateCommand();
                comando.CommandText = @"
            select from Usuario where tipoUsuario = @tipoUsuario and id = @id";

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    conexao.Close();
                }
            }

        }

    }
}
