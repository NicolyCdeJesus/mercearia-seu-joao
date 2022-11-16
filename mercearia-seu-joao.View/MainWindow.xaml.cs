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
        Usuario usuarioLogado = new Usuario();
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
                FrmMenu frmmenu = new FrmMenu(usuarioLogado);
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

            Usuario obteveUsuario = ConsultasUsuario.ObterUsuario(txtEmail.Text, txtSenha.Password);

            if (obteveUsuario != null)
            {
                usuarioLogado = obteveUsuario;
                MessageBoxResult result = MessageBox.Show(
                    "Login efetuado com sucesso!",
                    "Check!",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
                return true;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show(
                    "O Email ou senha inserido não existe, verifique se foi digitado corretamente ou cadastre-se.",
                    "Aviso!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

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