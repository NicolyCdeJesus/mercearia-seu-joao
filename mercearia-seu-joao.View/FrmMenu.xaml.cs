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
    /// Lógica interna para FrmMenu.xaml
    /// </summary>
    public partial class FrmMenu : Window
    {
        public FrmMenu()
        {
            InitializeComponent();
            txtUsuarioData.Text = "";
        }

        private void FuncionarioGerente()
        {
            if (TipoUsuario == UsuarioGerente)
            {
                btnProduto.Visibility = Visibility.Visible;
                btnUsuario.Visibility = Visibility.Visible;
                btnVender.Visibility = Visibility.Visible;
            }
        }

        private void FuncionarioCaixa()
        {
            if (TipoUsuario == UsuarioCaixa)
            {
                btnProduto.Visibility = Visibility.Hidden;
                btnUsuario.Visibility = Visibility.Hidden;
                btnVender.Visibility = Visibility.Visible;
            }
        }

        private void Vender(object sender, RoutedEventArgs e)
        {
            FrmVenderProduto frmVenderProduto = new FrmVenderProduto();
            frmVenderProduto.Show();

        }

        private void Sair(object sender, RoutedEventArgs e)
        {           
            Close();
            //MainWindow frmLogin = new MainWindow();
            // Abre a janela do jogo da velha.
            //frmLogin.Show();

        }

        private void UsuarioEntrar(object sender, RoutedEventArgs e)
        {
            //FrmGerenciarUsuario frmGerenciarUsuario = new FrmGerenciarUsuario();
            //frmGerenciarUsuario.Show();
        }
    }
}
