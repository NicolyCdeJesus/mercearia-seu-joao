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
using mercearia_seu_joao.Model;

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

        public void EsqueceuSenha(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
               "Contate seu gerente!",
               "Atenção",

            MessageBoxButton.OK,
            MessageBoxImage.Warning
    );
        }

        public void FazerLogin(object sender, RoutedEventArgs e)
        {
            if (CampoPreenchido() == true && UsuarioExiste() == true)
            {
                FrmMenu frmmenu = new FrmMenu();
                frmmenu.Show();
                Close();
           
            }

            else
            {
                MessageBoxResult result = MessageBox.Show(
                   "Você não completou os requisitos corretamente!",
                   "Atenção",

                MessageBoxButton.OK,
                MessageBoxImage.Warning
);
            }
        }
        public bool UsuarioExiste()
        {   
            
            Usuario usuario = new Usuario();
            string txtEmail = "";
            string txtSenha = "";

            if (txtEmail == usuario.email && txtSenha == usuario.senha)
            {
                return true;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show(
                 "O Email ou senha inserido não existe, verifique se foi digitado corretamente ou cadastre-se.",
                 "Nah ah ah, você não disse a palavra magica!",

               MessageBoxButton.OK,
               MessageBoxImage.Warning
               );
                return false;
            }
        }
       

        public bool CampoPreenchido()
        {
            if (txtEmail.Text != "" && txtSenha.Password != "")
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
        }


    }
}