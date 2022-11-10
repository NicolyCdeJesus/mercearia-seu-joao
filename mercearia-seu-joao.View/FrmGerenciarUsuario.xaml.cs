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
                    AdicionaUsuario();
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
                    txtConfirmarSenha.Text = txtSenha.Text;
                    bool foiAtualizado = ConsultasUsuario.AtualizarUsuario(
                        id,
                        txtNome.Text,
                        cbTipoUsuario.Text,
                        txtEmail.Text,
                        txtSenha.Text,
                        txtConfirmarSenha.Text);

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
            if (txtNome.Text != "" && txtEmail.Text != "" && txtSenha.Text != "" && txtConfirmarSenha.Text != "")
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
            txtEmail.Text = "";
            txtConfirmarSenha.Text = "";
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
                txtSenha.Text,
                txtConfirmarSenha.Text
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
            string senha = txtSenha.Text;
            string confirmarSenha = txtSenha.Text;

            bool usuarioExiste = ConsultasUsuario.VerificarUsuarioExistente(email);
            if (usuarioExiste == false)
            {
                bool validarCadastro = ConsultasUsuario.InserirUsuario(nome, tipoUsuario, email, senha, confirmarSenha);
                if (validarCadastro == true)
                {
                    MessageBoxResult result = MessageBox.Show(
                    "Usuario cadastrado com sucesso",
                    "Informação!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(
                        "Não foi possível fazer o cadastro, tente novamente mais tarde!",
                        "Error!",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }

            else
            {
                MessageBoxResult result = MessageBox.Show(
                    "Email já existe no sistema!",
                    "Atenção!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
        
    }
}
