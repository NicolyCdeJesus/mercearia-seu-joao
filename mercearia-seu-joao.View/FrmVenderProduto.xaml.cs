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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mercearia_seu_joao.View
{
    /// <summary>
    /// Interação lógica para FrmVenderProduto.xam
    /// </summary>
    public partial class FrmVenderProduto : Page
    {
        double numero = 0;
        double ValorTotal = 0;
     
        public FrmVenderProduto()
        {
            InitializeComponent();
        }

        //Feito entre 08/11/2022 a 09/11/2022
        private void buscarProduto(object sender, RoutedEventArgs e)
        {
            if (txtCampoId.Text == "")
            {
                txtCampoQtd.IsReadOnly = true;// não permite escrever
            }
            else
            {
                txtCampoQtd.IsReadOnly = false;// permite escrever
            }
        }

        private void adicionarProduto(object sender, RoutedEventArgs e)
        {
            numero = Double.Parse(txtCampoQtd.Text);
            ValorTotal = numero * 5.00;
            txtCampoPrecoTotal.Text = ValorTotal.ToString();
        }

        private void limpar(object sender, RoutedEventArgs e)
        {
            txtCampoId.Text = "";
            txtCampoNome.Text = "";
            txtCampoQtd.Text = "";
            txtCampoPrecoTotal.Text = "";
            numero = 0;
            ValorTotal = 0;
        }

        private void realizarVenda(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Venda Realizada",
                "Informarion",
                MessageBoxButton.OK,
                MessageBoxImage.None);
        }

        private void abrirFrmItemDaLista(object sender, MouseButtonEventArgs e)
        {
            //Close();
            FrmItemDaLista FrmItemDaLista = new FrmItemDaLista();
            //rmItemDaLista.Show();
        }

        internal void Show()
        {
            throw new NotImplementedException();
        }
    }
}
