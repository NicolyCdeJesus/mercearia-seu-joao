using mercearia_seu_joao.View;
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
        double n = 0;
        public FrmItemDaLista()
        {
            InitializeComponent();
        }

        private void AlterarProduto(object sender, RoutedEventArgs e)
        {
            n = Double.Parse(txtCampoQtdLista.Text);

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
                        //AtualizaDataGrid2(DataGrid dgvProduto);
                        MessageBoxResult result2 = MessageBox.Show(
                            "Produto excluído!",
                            "Atenção",
                             MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                }
            }
        }

       private void AtualizaDataGrid2(DataGrid dgvProduto)
       {
            //dgvProdutos.ItemsSource = listaDeProdutos;
           //dgvProdutos.Items.Refresh();
        }
    }
}
