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

        double numero = 0;
        double ValorTotal = 0;

        public FrmVenderProduto()
        {
            InitializeComponent();
        }

        private void BuscarProduto(object sender, RoutedEventArgs e)
        {
            if (txtCampoId.Text == "")
            {
                txtCampoQtd.IsReadOnly = true; // não permite escrever
            }
            else
            {
                txtCampoQtd.IsReadOnly = false; // permite escrever
            }
        }

        private void AdicionarProduto(object sender, RoutedEventArgs e)
        {
            produto_Vendedor produto = new produto_Vendedor();
            produto.id = RetortnaUltimoIdIncrementadoDaLista();
            produto.nome = txtCampoNome.Text;
            produto.quantidade = int.Parse(txtCampoQtd.Text);
            listaDeProdutos.Add(produto);
            numero = Double.Parse(txtCampoQtd.Text);
            ValorTotal = numero * 5.00;
            txtCampoPrecoTotal.Text = ValorTotal.ToString();
        }

        private void AtualizaDataGrid()
        {
            dgvProdutos.ItemsSource = listaDeProdutos;
            dgvProdutos.Items.Refresh();
        }

        private void Limpar(object sender, RoutedEventArgs e)
        {
            txtCampoId.Text = "";
            txtCampoNome.Text = "";
            txtCampoQtd.Text = "";
            txtCampoPrecoTotal.Text = "";
            numero = 0;
            ValorTotal = 0;
        }

        private void RealizarVenda(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Venda Realizada",
                "Informarion",
                MessageBoxButton.OK,
                MessageBoxImage.None);
        }

        private int RetortnaUltimoIdIncrementadoDaLista()
{
            int id = 0;
            if (listaDeProdutos.Count > 0)
            {
                int index = listaDeProdutos.Count - 1;
                id = listaDeProdutos[index].id;
            }
            id++;
            return id;
        }

        private void AbrirFrmItemDaLista(object sender, MouseButtonEventArgs e)
        {
            produto_Vendedor produto = (produto_Vendedor)dgvProdutos.SelectedItem;
            txtCampoNome.Text = produto.nome;
            txtCampoId.Text = produto.id.ToString();
            txtCampoQtd.Text = produto.quantidade.ToString();
            Close();
            FrmItemDaLista frmItemDaLista = new FrmItemDaLista();
            frmItemDaLista.Show();
        }

        internal void Show()
        {
            throw new NotImplementedException();
        }
    }
}
