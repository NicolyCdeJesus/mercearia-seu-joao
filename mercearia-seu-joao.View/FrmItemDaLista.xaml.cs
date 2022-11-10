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
    /// Interação lógica para FrmItemDaLista.xam
    /// </summary>
    public partial class FrmItemDaLista : Page
    {
        double n = 0;
        public FrmItemDaLista()
        {
            InitializeComponent();
        }
        //Feito entre 08/11/2022 a 09/11/2022

        private void alterar(object sender, RoutedEventArgs e)
        {
            n = Double.Parse(txtCampoQtdLista.Text);

        }

        private void excluir(object sender, RoutedEventArgs e)
        {

        }
    }
}
