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
    /// Lógica interna para FrmGerenciarProduto.xaml
    /// </summary>
    public partial class FrmGerenciarProduto : Window
    {
        List<Produto> listaDeProdutos = new List<Produto>();
        public FrmGerenciarProduto()
        {
            InitializeComponent();
            AtualizaDataGrid();

        }

        private void NovoProduto(object sender, RoutedEventArgs e)
        {
            if (VerificaCampos() == true)
            {
                if (txtID.Text == "")
                {
                    AdicionaProduto();
                }
                else
                {
                    //CaixaDeMenssagem.ExibirMenssagemIdCampoPreenchido();
                }
            }
            else
            {
                //CaixaDeMenssagem.ExibirMenssagemPreencherCampos();
            }

        }

        private void LimparCampos(object sender, RoutedEventArgs e)
        {
            LimpaTodosOsCampos();
        }

        private void AlterarProduto(object sender, RoutedEventArgs e)
        {
            if (txtID.Text != "")
            {
                int id = int.Parse(txtID.Text);
                MessageBoxResult result = MessageBox.Show(
                "Deseja alterar o produto id: {id} ?",
                "Alterar o produto",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bool foiAtualizado = ConsultasProduto.AtualizarProduto(
                    id,
                    txtNomeProduto.Text,
                    txtFornecedor.Text,
                    int.Parse(txtQuantidade.Text),
                    float.Parse(txtPrecoUnitario.Text)
                    );
                    if (foiAtualizado == true)
                    {
                        //CaixaDeMenssagem.ExibirMenssagemProdutoAtualizado();
                        LimpaTodosOsCampos();
                        AtualizaDataGrid();
                    }
                    else
                    {
                        //CaixaDeMenssagem.ExibirMenssagemErroProdutoAtualizado();
                    }
                }
            }
        }

        private void ExcluirProduto(object sender, RoutedEventArgs e)
        {
            if (txtID.Text != "")
            {
                int id = int.Parse(txtID.Text);
                MessageBoxResult result = MessageBox.Show(
                $"Deseja excluir o produto id:{id} ?",
                "Excluir Produto",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bool foiExcluido = ConsultasProduto.ExcluirProduto(id);
                    if (foiExcluido == true)
                    {
                       // CaixaDeMenssagem.ExibirMenssagemProdutoExcluido();
                        LimpaTodosOsCampos();
                        AtualizaDataGrid();
                    }
                    else
                    {
                        //CaixaDeMenssagem.ExibirMenssagemErroProdutoExcluido();
                    }
                }
            }

        }

        private bool VerificaCampos()
        {
            if (txtNomeProduto.Text != "" && txtFornecedor.Text != "" && txtQuantidade.Text != "" && txtPrecoUnitario.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void LimpaTodosOsCampos()
        {
            txtID.Text = "";
            txtNomeProduto.Text = "";
            txtFornecedor.Text = "";
            txtQuantidade.Text = "";
            txtPrecoUnitario.Text = "";
        }
        private void AdicionaProduto()
        {
            bool foiInserido = ConsultasProduto.InserirProduto(
            txtNomeProduto.Text,
            txtFornecedor.Text,
            int.Parse(txtQuantidade.Text),
            float.Parse(txtPrecoUnitario.Text)
            );
            if (foiInserido == true)
            {
               // CaixaDeMenssagem.ExibirMenssagemProdutoCadastrado();
                LimpaTodosOsCampos();
                AtualizaDataGrid();
            }
            else
            {
               // CaixaDeMenssagem.ExibirMenssagemErroProdutoCadastrado();
            }
        }
        private void AtualizaDataGrid()
        {
            listaDeProdutos.Clear();
            listaDeProdutos = ConsultasProduto.ObterTodosProdutos();
            dgvProdutos.ItemsSource = listaDeProdutos;
            dgvProdutos.Items.Refresh();
        }
        private void PegarItemNoGrid(object sender, MouseButtonEventArgs e)
        {
            Produto produto = (Produto)dgvProdutos.SelectedItem;
            txtID.Text = produto.id.ToString();
            txtNomeProduto.Text = produto.nome;
            txtFornecedor.Text = produto.fornecedor;
            txtQuantidade.Text = produto.qtd.ToString();
            txtPrecoUnitario.Text = produto.qtd.ToString();
        }
    }
}
