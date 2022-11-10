using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercearia_seu_joao.Model
{
    public class ConsultasUsuario
    {
        public static bool InserirUsuario(string nome, string tipoUsuario, string email, string senha, string confirmarSenha)
        {
            var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
            bool foiInserido = false;
            try
            {   conexao.Open();
                var comando = conexao.CreateCommand();
                string senhaCriptografada = Criptografia.CriptografarMD5Senha(senha);


                comando.CommandText = @"
                INSERT INTO Usuario (nome, tipoUsuario, email, senha, confirmarSenha) 
                VALUES(@nome,@tipoUsuario,@email,@senha,@confirmaSenha)";
                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@senha", senhaCriptografada);
                comando.Parameters.AddWithValue("@confirmaSenha", senhaCriptografada);
                var leitura = comando.ExecuteReader();
                    
                foiInserido = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    conexao.Close();
                }
            }

            return foiInserido;
        }

        //Exclui um usuario do banco de dados - REMOVE
        public static bool ExcluirUsuario(int id)
        {
            var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
            bool foiExcluido = false;
            try
            {
                conexao.Open();
                var comando = conexao.CreateCommand();
                comando.CommandText = @"
                DELETE FROM Usuario WHERE id = @id";
                comando.Parameters.AddWithValue("@id", id);
                var leitura = comando.ExecuteReader();
                foiExcluido = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    conexao.Close();
                }
            }

            return foiExcluido;
        }

        //Altera um produto no banco de dados - UPDATE
        public static bool AtualizarUsuario(int id, string nome, string tipoUsuario, string email, string senha, string confirmarSenha)
        {
            // REFAZER COM OS NOMES CERTOS
            var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
            bool foiAtualizado = false;
            try
            {
                    conexao.Open();
                    var comando = conexao.CreateCommand();
                    string senhaCriptografada = Criptografia.CriptografarMD5Senha(senha);
                    comando.CommandText = @"
                    UPDATE Usuario
                    SET nome = @nome, tipoUsuario = @tipoUsuario, email = @email, senha = @senha
                    WHERE id = @id, confirmarSenha = @confirmaSenha";
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);
                    comando.Parameters.AddWithValue("@email", email);
                    comando.Parameters.AddWithValue("@senha", senhaCriptografada);
                    comando.Parameters.AddWithValue("@confirmaSenha", senhaCriptografada);
                    var leitura = comando.ExecuteReader();

                    foiAtualizado = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    conexao.Close();
                }
            }

            return foiAtualizado;
        }

        //Retrona todos os produtos - READ
        public static List<Usuario> ObterTodosUsuarios()
        {
            var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
            List<Usuario> listaDeUsuarios = new List<Usuario>();

            try
            {
                conexao.Open();
                var comando = conexao.CreateCommand();
                comando.CommandText = @"
                SELECT * FROM Usuario;";
                var leitura = comando.ExecuteReader();
                while (leitura.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.id = leitura.GetInt32("id");
                    usuario.nome = leitura.GetString("nome");
                    usuario.tipoUsuario = leitura.GetString("tipoUsuario");
                    usuario.email = leitura.GetString("email");
                    usuario.senha = leitura.GetString("senha");
                    usuario.confirmaSenha = leitura.GetString("confirmarSenha");

                    listaDeUsuarios.Add(usuario);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    conexao.Close();
                }
            }

            return listaDeUsuarios;
        }





        //A partir daqui o código vai cuidar da criptografia
        public static bool VerificarUsuarioExistente(string email)
        {
            var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
            bool usuarioExiste = false;
            try
            {
                conexao.Open();
                var comando = conexao.CreateCommand();
                comando.CommandText = @"Select * from Usuario Where email = @email";
                comando.Parameters.AddWithValue("@email", email);
                var leitura = comando.ExecuteReader();
                while (leitura.Read())
                {
                    usuarioExiste = true;
                    break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
            return usuarioExiste;
        }
    }
}
