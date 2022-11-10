using System;
using MySqlConnector;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        //Classes apenas (ValidarCampos + Esqueceu senha + messagebox) e Layout feito dia 7/11
        //Não enviado ao Git por falta de internet...

        //Metodos, if's, etc nas classes, feito tudo dia 08/11

        private void EsqueceuSenha(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
               "Contate seu gerente!",
               "Atenção",

            MessageBoxButton.OK,
            MessageBoxImage.Warning
    );
        }

        private void FazerLogin(object sender, RoutedEventArgs e)
        {
            if (CampoCompleto() == true)
            {
                FrmMenu frmmenu = new FrmMenu();
                frmmenu.Show();
                Close();
            }

            else
            {
                MessageBoxResult result = MessageBox.Show(
                   "Você não completou os requisitos!",
                   "Atenção",

                MessageBoxButton.OK,
                MessageBoxImage.Warning
);
            }
        }

        private bool UsuarioExiste()
        {
            Usuario email, senha = new Usuario();

            if (txtEmail = email)
            {
                if (txtSenha.Password = senha)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private bool CampoCompleto()
        {
            if (txtEmail.Text == "" && txtSenha.Password == "")
            {
                return true;
            }

            else
            {
                MessageBoxResult result = MessageBox.Show(
                   "Preencha todos os campos!",
                   "Atenção",

                MessageBoxButton.OK,
                MessageBoxImage.Warning);

                return false;
            }
            //Coisas relacionadas a isso foram feitas dia 10/11 (aguardando a Juliana com a parte dela)
        }

        private bool DiferencaUsuario()
        {
            UsuarioGerente emailGerente = new UsuarioGerente();
            UsuarioCaixa emailCaixa = new UsuarioCaixa();
            Usuario email = new Usuario();

            if (email = emailCaixa)
            {
                return true;
            }
            if (email = emailGerente)
            {
                return false;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show(
                 "O Email inserido não existe, verifique se foi digitado corretamente ou cadastre-se.",
                 "Atenção",

               MessageBoxButton.OK,
               MessageBoxImage.Warning
               );
            }
        }
    }
}