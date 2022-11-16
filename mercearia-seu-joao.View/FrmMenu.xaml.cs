using mercearia_seu_joao.Model;
using MySqlConnector;
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
            txtUsuarioData.Text = $"Olá, hoje é dia {DateTime.Now.ToShortDateString()}";
        }

        public void VerificarUsuario()
        {
            var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
            select from Usuario where tipoUsuario = @tipoUsuario and id = @id";

            var leitura = comando.ExecuteReader();
            if (leitura.Read())
            {
                //Verifica o usuário
                string tipoUsuario = leitura.GetString("tipoUsuario");
                if (tipoUsuario.Equals("Gerente"))
                {
                    btnProduto.Visibility = Visibility.Visible;
                    btnUsuario.Visibility = Visibility.Visible;
                    btnVender.Visibility = Visibility.Visible;
                }
                else if (tipoUsuario.Equals("Vendedor"))
                {
                    btnProduto.Visibility = Visibility.Hidden;
                    btnUsuario.Visibility = Visibility.Hidden;
                    btnVender.Visibility = Visibility.Visible;
                }
            }

        }


        /*private void FuncionarioGerente()
        {
          if (DiferencaUsuario() =! true)
             {
                 btnProduto.Visibility = Visibility.Visible;
                 btnUsuario.Visibility = Visibility.Visible;
                 btnVender.Visibility = Visibility.Visible;
             }
         
         
        }
        */

        /*private void FuncionarioCaixa()
       {
          if (DiferencaUsuario() = true)
           {
               btnProduto.Visibility = Visibility.Hidden;
               btnUsuario.Visibility = Visibility.Hidden;
               btnVender.Visibility = Visibility.Visible;
           }
            
    }
*/
        private void TelaProdutos(object sender, RoutedEventArgs e)
        {
            FrmGerenciarProduto frmGerenciarProduto = new FrmGerenciarProduto();
            frmGerenciarProduto.Show();
        }

        private void UsuarioEntrar(object sender, RoutedEventArgs e)
        {
            FrmGerenciarUsuario frmGerenciarUsuario = new FrmGerenciarUsuario();
            frmGerenciarUsuario.Show();
        }

        private void EfetuarVenda(object sender, RoutedEventArgs e)
        {
            FrmVenderProduto frmVenderProduto = new FrmVenderProduto();
            frmVenderProduto.Show();
        }

        private void Sair(object sender, RoutedEventArgs e)
        {
            Close();
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();

        }       
    }
}
