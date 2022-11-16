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
using System.Security.Cryptography;

namespace mercearia_seu_joao.View
{
    /// <summary>
    /// Lógica interna para FrmGerenciarUsuario.xaml
    /// </summary>
    public partial class FrmGerenciarUsuario : Window
    {

        List<Usuario> listaDeUsuarios = new List<Usuario>();
        List<int> listaDeNumeros = new List<int>();
        public FrmGerenciarUsuario()
        {
            InitializeComponent();
            AddItensNoComboBox();
        }

        private void AddItensNoComboBox()
        {
            cbTipoUsuario.Items.Add("Caixa");
            cbTipoUsuario.Items.Add("Gerente");
        }

        private void AdicionarNovoUsuario(object sender, RoutedEventArgs e)
        {
            if (VerificaCampos() == true)
            {
                if (txtId.Text == "")
                {
                    if (txtConfirmarSenha.Password == txtSenha.Password) 
                    { 
                        AdicionaUsuario(); 
                    }
                    else
                    {
                        CaixaDeMensagem.CamposSenhaEConfirmarSenhaDiferentes();
                    } 
                }
                else
                {
                    CaixaDeMensagem.ExibirMenssagemIdCampoPreenchido();
                }

            }
            else
            {
                CaixaDeMensagem.ExibirMenssagemPreencherCampos();
            }
        }
        private void LimparCamposDoUsuario(object sender, RoutedEventArgs e)
        {
            LimpaTodosOsCampos();
        }

        private void AtualizarDataGridUsuario(object sender, RoutedEventArgs e)
        {
            if (txtId.Text != "")
            {
                int id = int.Parse(txtId.Text);
                MessageBoxResult result = MessageBox.Show(
                    "Deseja alterar o usuário id: {id} ?",
                    "Alterar o usuario",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bool foiAtualizado = ConsultasUsuario.AtualizarUsuario(
                        id,
                        txtNome.Text,
                        cbTipoUsuario.Text,
                        txtEmail.Text,
                        txtSenha.Password
                        );

                    if (foiAtualizado == true)
                    {
                        CaixaDeMensagem.ExibirMenssagemUsuarioAtualizado();
                        LimpaTodosOsCampos();
                        AtualizaDataGrid();
                    }
                    else
                    {
                        CaixaDeMensagem.ExibirMenssagemErroUsuarioAtualizado();
                    }
                }
            }
        }

        private void ExcluirUsuario(object sender, RoutedEventArgs e)
        {
            if (txtId.Text != "")
            {
                int id = int.Parse(txtId.Text);
                MessageBoxResult result = MessageBox.Show(
                    $"Deseja excluir o usuario id:{id} ?",
                    "Excluir Usuario",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bool foiExcluido = ConsultasUsuario.ExcluirUsuario(id);
                    if (foiExcluido == true)
                    {
                        CaixaDeMensagem.ExibirMenssagemUsuarioExcluido();
                        LimpaTodosOsCampos();
                        AtualizaDataGrid();
                    }
                    else
                    {
                        CaixaDeMensagem.ExibirMenssagemErroUsuarioExcluido();
                    }
                }
            }
        }


        private bool VerificaCampos()
        {
            if (txtNome.Text != "" && txtEmail.Text != "" && txtSenha.Password != "" && txtConfirmarSenha.Password != "" && cbTipoUsuario.Text != "")
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
            txtId.Text = "";
            txtNome.Text = "";
            cbTipoUsuario.Text = "";
            txtEmail.Text = "";
            txtSenha.Password = "";
            txtConfirmarSenha.Password = "";
        }
        private void AtualizaDataGrid()
        {
            listaDeUsuarios.Clear();
            listaDeUsuarios = ConsultasUsuario.ObterTodosUsuarios();
            dgvUsuario.ItemsSource = listaDeUsuarios;
            dgvUsuario.Items.Refresh();
        }
        private void AdicionaUsuario()
        {
            bool foiInserido = ConsultasUsuario.InserirUsuario(
                txtNome.Text,
                cbTipoUsuario.Text,
                txtEmail.Text,
                txtSenha.Password
                );
            if (foiInserido == true)
            {
                CaixaDeMensagem.ExibirMenssagemUsuarioCadastrado();
                CadastrarUsuario();
                LimpaTodosOsCampos();
                AtualizaDataGrid();
            }
            else
            {
                CaixaDeMensagem.ExibirMenssagemErroUsuarioCadastrado();
            }
        }

        private void CadastrarUsuario()
        {
            string nome = txtNome.Text;
            string tipoUsuario = cbTipoUsuario.Text;
            string email = txtEmail.Text;
            string senha = txtSenha.Password;

            bool usuarioExiste = ConsultasUsuario.VerificarUsuarioExistente(email);
            if (usuarioExiste == false)
            {
                bool validarCadastro = ConsultasUsuario.InserirUsuario(nome, tipoUsuario, email, senha);
                if (validarCadastro == true)
                {
                    CaixaDeMensagem.ExibirMenssagemErroUsuarioCadastrado();
                }
                else
                {
                    CaixaDeMensagem.ExibirMenssagemErroUsuarioCadastrado(); 
                }
            }

            else
            {
                CaixaDeMensagem.UsuarioJaEstaCadastradoNoSistema();
            }
        }


        /*public void VerificarParametrosDaSenha()
        {
            if(txtSenha.Password.Length > 8)
            {
                if (txtSenha.Password.Contains(listaDeNumeros.ToString()))
                {
                    if ()
                    {
                        if ()
                        {

                        }
                        else
                        {
                            CaixaDeMensagem.SenhaFraca();
                        }
                    }
                    else
                    {
                        CaixaDeMensagem.SenhaFraca();
                    }
                }
                else
                {
                    CaixaDeMensagem.SenhaFraca();
                }
            }
            else
            {
                CaixaDeMensagem.SenhaFraca();
            }
        }*/

    }
}
