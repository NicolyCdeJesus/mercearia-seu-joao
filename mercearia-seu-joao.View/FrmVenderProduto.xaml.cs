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
    /// Lógica interna para FrmVenderProduto.xaml
    /// </summary>
    public partial class FrmVenderProduto : Window
    {
        List<produto_Vendedor> listaDeProdutos = new List<produto_Vendedor>();

        float qtd = 0;
        float precoTotal_ = 0;
        float precoUnitario = 0;
        float valorFinal = 0;
        bool achouId = false;

        public FrmVenderProduto()
        {
            InitializeComponent();
        }

        private void BuscarOProdutoId(object sender, RoutedEventArgs e)
        {
            if (txtCampoId.Text != "")
            {
                txtCampoQtd.IsReadOnly = false; // não permite escrever
                txtCampoNome.Text = ConsultasProduto_Vendedor.RetornaNome(int.Parse(txtCampoId.Text));
                if(txtCampoNome.Text == "")
                {
                    achouId = true;
                    MessageBoxResult result = MessageBox.Show(
                    "Insira um Id válido!",
                    "Excluir Produto",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                }
                else
                {
                    CalcularPrecoTotal2();
                }

            }
            else
            {
                txtCampoQtd.IsReadOnly = true; // permite escrever
            }
        }

        private void AdicionarProduto(object sender, RoutedEventArgs e)
        {
            if (VerificaCampos() == true)
            {
                AdicionaProduto();
            }
            else
            {
                CaixaDeMensagem_Vendedor.ExibirMensagemErroProdutoCadastrado();
            }

        }
        private void Limpar(object sender, RoutedEventArgs e)
        {
            LimpaTodosOsCampos();
        }

        private void RealizarVenda(object sender, RoutedEventArgs e)
        {
            if (RealizaVenda() == true) 
            {
                CaixaDeMensagem_Vendedor.ExibirMensagemVendaRealizada();
            }
            else
            {
                CaixaDeMensagem_Vendedor.ExibirMensagemErroVendaRealizada();
            }
        }
        private void AbrirFrmItemDaLista(object sender, MouseButtonEventArgs e)
        {
            produto_Vendedor produto = (produto_Vendedor)dgvProdutos.SelectedItem;
            txtCampoNome.Text = produto.nome;
            txtCampoId.Text = produto.id.ToString();
            txtCampoQtd.Text = produto.quantidade.ToString();
            txtCampoPrecoTotal.Text = produto.precoTotal.ToString();
            Close();
            FrmItemDaLista frmItemDaLista = new FrmItemDaLista();
            frmItemDaLista.Show();
        }
        private void AdicionaProduto()
        {
            bool foiInserido = ConsultasProduto_Vendedor.InserirProduto(
                int.Parse(txtCampoId.Text),
                txtCampoNome.Text,
                int.Parse(txtCampoQtd.Text),
                int.Parse(txtPrecoTotal.Text)
                ); 

            if (foiInserido == true)
            {
                CaixaDeMensagem_Vendedor.ExibirMensagemProdutoCadastrado();
                LimpaTodosOsCampos();
                AtualizaDataGrid();

            }
            else
            {
                CaixaDeMensagem_Vendedor.ExibirMensagemErroProdutoCadastrado();
            }
        }
        private bool VerificaCampos()
        {
            if (txtCampoId.Text != "" && txtCampoNome.Text != "" && txtCampoQtd.Text != "" && txtCampoPrecoTotal.Text != "")
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        private bool RealizaVenda()
        {
            if (txtCampoId.Text != "" && txtCampoNome.Text != "" && txtCampoQtd.Text != "" && txtCampoPrecoTotal.Text != "")
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
            txtCampoId.Text = "";
            txtCampoNome.Text = "";
            txtCampoQtd.Text = "";
            txtCampoPrecoTotal.Text = "";
            float qtd = 0;
            float precoTotal = 0;
            float valorFinal = 0;
            float precoUnitario = 0;
        }
        private void AtualizaDataGrid()
        {
            listaDeProdutos.Clear();
            listaDeProdutos = ConsultasProduto_Vendedor.ObterTodosProdutos();
            dgvProdutos.ItemsSource = listaDeProdutos;
            dgvProdutos.Items.Refresh();
        }
        private void PrecoTotal()
        {
            qtd = float.Parse(txtCampoQtd.Text);
            precoTotal_= float.Parse(txtCampoPrecoTotal.Text);
            //precoUnitario = float.Parse(txtPrecoUnitario.Text);
            precoTotal_ = qtd * precoUnitario;
            txtCampoPrecoTotal.Text = precoTotal_.ToString();
        }
        private void ValorFinal()
        {
            //precoUnitario = float.Parse(precoUnitario.Text);
            //valorFinal = precoUnitario +;
        }

        private void calcularPrecoTotal(object sender, TextChangedEventArgs e)
        {
            if (achouId && txtCampoQtd.Text != "" && txtCampoQtd.Text != "0")
            {
                precoTotal_ =  CalcularPrecoTotal2();
            }
            
            
        }

        private void CalcularPrecoTotal2()
        {
            ConsultasProduto_Vendedor.RetornaPreco(int.Parse(txtCampoId.Text));
        }
    }
}
