using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercearia_seu_joao.Model
{
    public class ConsultasProduto_Vendedor
    {
        // Cadastra o produto no banco de dados
        public static bool InserirProduto(int id, string nome, int quantidade, int precoTotal)
        {
            var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
            bool foiInserido = false;
            try
            {
                conexao.Open();
                var comando = conexao.CreateCommand();
                comando.CommandText = @"
                INSERT INTO Produto (id, nome, quantidade) 
                VALUES(@id , @nome, @quantidade)";
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@quantidade", quantidade);
                comando.Parameters.AddWithValue("precoTotal", precoTotal);

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


        //public static bool AlterarProduto_(string text)
        //{
        //throw new NotImplementedException();
        //}

        //Exclui um produto do banco de dados - REMOVE
        public static bool ExcluirProduto(int id)
        {
            var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
            bool foiExcluido = false;
            try
            {
                conexao.Open();
                var comando = conexao.CreateCommand();
                comando.CommandText = @"
                DELETE FROM Produto WHERE id = @id";
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
        public static bool AlterarProduto(int id, string nome, int quantidade, int precoTotal)
        {
            var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
            bool foiAlterado = false;
            try
            {
                conexao.Open();
                var comando = conexao.CreateCommand();
                comando.CommandText = @"
                    UPDATE Produto
                    SET nome = @nome, quantidade = @quantidade, precoTotal = @precoTotal
                    WHERE id = @id";
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@quantidade", quantidade);
                comando.Parameters.AddWithValue("@precoTotal", precoTotal);
                var leitura = comando.ExecuteReader();
                foiAlterado = true;
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
            return foiAlterado;
        }

        //Retorna todos os produtos - READ
        public static List<produto_Vendedor> ObterTodosProdutos()
        {
            var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
            List<produto_Vendedor> listaDeProdutos = new List<produto_Vendedor>();

            try
            {
                conexao.Open();
                var comando = conexao.CreateCommand();
                comando.CommandText = @"
                SELECT * FROM Produto;";
                var leitura = comando.ExecuteReader();
                while (leitura.Read())
                {
                    produto_Vendedor produto = new produto_Vendedor();
                    produto.id = leitura.GetInt32("id");
                    produto.nome = leitura.GetString("nome");
                    produto.quantidade = leitura.GetInt32("quantidade");
                    produto.precoTotal = leitura.GetInt32("precoTotal");
                    listaDeProdutos.Add(produto);
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
            return listaDeProdutos;
        }


        public static bool VerificarProdutoExistente(int id)
        {
            var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
            bool produtoExiste = false;
            try
            {
                conexao.Open();
                var comando = conexao.CreateCommand();
                comando.CommandText = @"Select * from Produto Where id = @id";
                comando.Parameters.AddWithValue("@id", id);
                var leitura = comando.ExecuteReader();
                while (leitura.Read())
                {

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
            return produtoExiste;
        }


        public static bool AlterarProduto_(int quantidade, int precoTotal)
        {
            var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
            bool foiAlterado_ = false;
            try
            {
                conexao.Open();
                var comando = conexao.CreateCommand();
                comando.CommandText = @"
                    UPDATE Produto
                    SET quantidade = @quantidade, precoTotal = @precoTotal
                    WHERE id = @id";
                comando.Parameters.AddWithValue("@quantidade", quantidade);
                comando.Parameters.AddWithValue("@precoTotal", precoTotal);
                var leitura = comando.ExecuteReader();
                foiAlterado_ = true;
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
            return foiAlterado_;


        }
    }
}
