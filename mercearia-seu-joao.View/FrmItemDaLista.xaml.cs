using mercearia_seu_joao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace mercearia_seu_joao.View
{
    /// <summary>
    /// Lógica interna para FrmItemDaLista.xaml
    /// </summary>
    public partial class FrmItemDaLista : Window
    {
        List<produto_Vendedor> listaDeProdutos = new List<produto_Vendedor>();
        public FrmItemDaLista()
        {
            InitializeComponent();
        }

        private void AlterarProduto(object sender, RoutedEventArgs e)
        {
            if (txtCampoIdLista.Text != "")
            {
                int id = int.Parse(txtCampoIdLista.Text);
                MessageBoxResult result = MessageBox.Show(
                    $"Deseja alterar o produto id:{id} ?",
                    "Alterar o produto",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    for (int i = 0; i < listaDeProdutos.Count; i++)
                    {
                        if (listaDeProdutos[i].id == id)
                        {
                            listaDeProdutos[i].id = int.Parse(txtCampoIdLista.Text);
                            listaDeProdutos[i].nome = txtCampoNomeLista.Text;
                            listaDeProdutos[i].quantidade = int.Parse(txtCampoQtdLista.Text);
                            break;
                        }
                    }
                    //AtualizaDataGrid_();
                    LimpaCampos();
                    CaixaDeMensagem_Vendedor.ExibirMensagemProdutoAtualizado();
                }

            }
            else
            {
                CaixaDeMensagem_Vendedor.ExibirMensagemErroProdutoAtualizado();
            }
        }
        private void ExcluirProduto(object sender, RoutedEventArgs e)
        {
            if (txtCampoIdLista.Text != "")
            {
                int id = int.Parse(txtCampoIdLista.Text);
                MessageBoxResult result = MessageBox.Show(
                    $"Deseja excluir o produto id:{id} ?",
                    "Excluir Produto",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    foreach (produto_Vendedor produto in listaDeProdutos)
                    {
                        if (produto.id == id)
                        {
                            listaDeProdutos.Remove(produto);
                            break;
                        }
                        //AtualizaDataGrid_();
                        CaixaDeMensagem_Vendedor.ExibirMesagemProdutoExcluido();
                    }
                }
                CaixaDeMensagem_Vendedor.ExibirMesagemErroProdutoExcluido();
            }
        }

        private void AtualizaDataGrid_()
        {
            //dgvProdutos.ItemsSource = listaDeProdutos;
            //dgvProdutos.Items.Refresh();
        }
        private void LimpaCampos()
        {
            txtCampoIdLista.Text = "";
            txtCampoNomeLista.Text = "";
            txtCampoQtdLista.Text = "";
        }

    }

}
