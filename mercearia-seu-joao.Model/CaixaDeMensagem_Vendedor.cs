using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace mercearia_seu_joao.Model
{
    public class CaixaDeMensagem_Vendedor
    {
        public static void ExibirMensagemIdCampoPreenchido()
        {
            MessageBoxResult result3 = MessageBox.Show(
                "Limpe o campo Id para poder inserir!",
                "Atenção",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }
        public static void ExibirMensagemPreencherCampos()
        {
            MessageBoxResult result3 = MessageBox.Show(
                "Preencha todos os campos!",
                "Atenção",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }
        public static void ExibirMensagemProdutoCadastrado()
        {
            MessageBoxResult result3 = MessageBox.Show(
                "O produto foi cadastrado!",
                "Atenção",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
        public static void ExibirMensagemErroProdutoCadastrado()
        {
            MessageBoxResult result3 = MessageBox.Show(
                               "Não foi possível inserir o produto, tente novamente mais tarde!",
                               "Error",
                               MessageBoxButton.OK,
                               MessageBoxImage.Error);
        }
        public static void ExibirMensagemProdutoAtualizado()
        {
            MessageBoxResult result3 = MessageBox.Show(
                               "O produto foi atualizado!",
                               "Informação",
                               MessageBoxButton.OK,
                               MessageBoxImage.Information);
        }
        public static void ExibirMensagemErroProdutoAtualizado()
        {
            MessageBoxResult result3 = MessageBox.Show(
                               "Não foi possível atualizar o produto, tente novamente mais tarde!",
                               "Error",
                               MessageBoxButton.OK,
                               MessageBoxImage.Error);
        }
        public static void ExibirMensagemProdutoExcluido()
        {
            MessageBoxResult result3 = MessageBox.Show(
                               "O produto foi excluido!",
                               "Informação",
                               MessageBoxButton.OK,
                               MessageBoxImage.Information);
        }
        public static void ExibirMensagemErroProdutoExcluido()
        {
            MessageBoxResult result3 = MessageBox.Show(
                               "Não foi possível excluir o produto",
                               "Error",
                               MessageBoxButton.OK,
                               MessageBoxImage.Error);
        }
        public static void ExibirMensagemVendaRealizada()
        {
            MessageBoxResult result3 = MessageBox.Show(
                            "Venda Realizada",
                            "Information",
                             MessageBoxButton.OK,
                             MessageBoxImage.Information);
        }
        public static void ExibirMensagemErroVendaRealizada()
        {
            MessageBoxResult result3 = MessageBox.Show(
                               "Não foi possível realizar a venda",
                               "Error",
                               MessageBoxButton.OK,
                               MessageBoxImage.Error);
        }
        public static void ExibirMesagemProdutoExcluido()
        {
            MessageBoxResult result2 = MessageBox.Show(
                            "Produto excluído!",
                            "Atenção",
                             MessageBoxButton.OK,
                             MessageBoxImage.Information);
        }
        public static void ExibirMesagemErroProdutoExcluido()
        {
            MessageBoxResult result2 = MessageBox.Show(
                            "Não foi possível excluir o produto",
                            "Error",
                             MessageBoxButton.OK,
                             MessageBoxImage.Error);
        }
    }
}
