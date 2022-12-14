using mercearia_seu_joao.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ConsultasProduto
{
    //Cadastra o produto no banco de dados - CREATE
    public static bool InserirProduto(string nome, string fornecedor, int quantidade, float precoUnitario)
    {
        var conexao = new
        MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiInserido = false;
        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
            INSERT INTO Produto (nome,  qtd, fornecedor, precoUnitario) 
            VALUES(@nome,@qtd,@fornecedor,@precoUnitario)";
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@qtd", quantidade);
            comando.Parameters.AddWithValue("@fornecedor", fornecedor);
            comando.Parameters.AddWithValue("@precoUnitario", precoUnitario);
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
    //Exclui um produto do banco de dados - REMOVE
    public static bool ExcluirProduto(int id)
    {
        var conexao = new
       MySqlConnection(ConexaoBD.Connection.ConnectionString);
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
    public static bool AtualizarProduto(int id, string nome, string fornecedor, int quantidade, double precounitario)
    {
        var conexao = new
       MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiAtualizado = false;
        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
            UPDATE Produto
            SET nome = @nome, fornecedor = 
            @fornecedor, qtd = @quantidade, precoUnitario = @precoUnitario,
            WHERE id = @id";
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@quantidade", quantidade);
            comando.Parameters.AddWithValue("@fabricante", fornecedor);
            comando.Parameters.AddWithValue("@precoUnitario", precounitario);
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
    public static List<Produto> ObterTodosProdutos()
    {
        var conexao = new
       MySqlConnection(ConexaoBD.Connection.ConnectionString);
        List<Produto> listaDeProdutos = new List<Produto>();
        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
            SELECT * FROM Produto;";
            var leitura = comando.ExecuteReader();
            while (leitura.Read())
            {
                Produto produto = new Produto();
                produto.id = leitura.GetInt32("id");
                produto.nome = leitura.GetString("nome");
                produto.qtd = leitura.GetInt32("qtd");               
                produto.precoUnitario = leitura.GetDouble("precoUnitario");
                produto.fornecedor = leitura.GetString("fornecedor");

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
}
