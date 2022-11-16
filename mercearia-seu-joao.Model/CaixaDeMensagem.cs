using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace mercearia_seu_joao.Model
{
    public class CaixaDeMensagem
    {
        public static void ExibirMenssagemIdCampoPreenchido()
        {
            MessageBoxResult result2 = MessageBox.Show(
                "Limpe o campo Id para poder inserir!",
                "Atenção",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }
        public static void ExibirMenssagemPreencherCampos()
        {
            MessageBoxResult result2 = MessageBox.Show(
                "Preencha todos os campos!",
                "Atenção",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }
        public static void ExibirMenssagemUsuarioCadastrado()
        {
            MessageBoxResult result2 = MessageBox.Show(
                "O Usuário foi cadastrado!",
                "Atenção",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }
        public static void ExibirMenssagemErroUsuarioCadastrado()
        {
            MessageBoxResult result2 = MessageBox.Show(
                               "Não foi possível inserir o Usuário, tente novamente mais tarde!",
                               "Atenção",
                               MessageBoxButton.OK,
                               MessageBoxImage.Error);
        }
        public static void ExibirMenssagemErroUsuarioAtualizado()
        {
            MessageBoxResult result2 = MessageBox.Show(
                               "Não foi possível atualizar o Usuário, tente novamente mais tarde!",
                               "Atenção",
                               MessageBoxButton.OK,
                               MessageBoxImage.Error);
        }
        public static void ExibirMenssagemUsuarioAtualizado()
        {
            MessageBoxResult result2 = MessageBox.Show(
                               "O usuário foi atualizado!",
                               "Informação",
                               MessageBoxButton.OK,
                               MessageBoxImage.Information);
        }
        public static void ExibirMenssagemUsuarioExcluido()
        {
            MessageBoxResult result2 = MessageBox.Show(
                               "O usuário foi excluido!",
                               "Informação",
                               MessageBoxButton.OK,
                               MessageBoxImage.Information);
        }
        public static void ExibirMenssagemErroUsuarioExcluido()
        {
            MessageBoxResult result2 = MessageBox.Show(
                               "Não foi possível excluir o usuário",
                               "Error",
                               MessageBoxButton.OK,
                               MessageBoxImage.Error);
        }

        /*public static void ExibirMen
            MessageBoxButton.OK,
           MessageBoxImage.Warning);*/
    
        public static void ExibirMenssagemProdutoCadastrado()
        {
        MessageBoxResult result2 = MessageBox.Show(
            "Produto foi cadastrado!",
            "Atenção",
            MessageBoxButton.OK,
            MessageBoxImage.Warning);
        }
        public static void ExibirMenssagemErroProdutoCadastrado()
        {
            MessageBoxResult result2 = MessageBox.Show(
                           "Não foi possível inserir o Produto, tente novamente mais tarde!",
                           "Atenção",
                           MessageBoxButton.OK,
                           MessageBoxImage.Error);
        }
        public static void ExibirMenssagemErroProdutoAtualizado()
        {
            MessageBoxResult result2 = MessageBox.Show(
                           "Não foi possível atualizar o Produto, tente novamente mais tarde!",
                           "Atenção",
                           MessageBoxButton.OK,
                           MessageBoxImage.Error);
        }
        public static void ExibirMenssagemProdutoAtualizado()
        {
            MessageBoxResult result2 = MessageBox.Show(
                           "Produto foi atualizado!",
                           "Informação",
                           MessageBoxButton.OK,
                           MessageBoxImage.Information);
        }
        public static void ExibirMenssagemProdutoExcluido()
        {
            MessageBoxResult result2 = MessageBox.Show(
                           "Produto foi excluido!",
                           "Informação",
                           MessageBoxButton.OK,
                           MessageBoxImage.Information);
        }
        public static void ExibirMenssagemErroProdutoExcluido()
        {
            MessageBoxResult result2 = MessageBox.Show(
                           "Não foi possível excluir o produto",
                           "Error",
                           MessageBoxButton.OK,
                           MessageBoxImage.Error);
        }
    
    }
    
}
