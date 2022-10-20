using ColaboraroForm.Model;
using System;
using System.Windows.Forms;

namespace ColaboraroForm
{
    public partial class FormLocal : Form
    {
        public FormLocal()
        {
            InitializeComponent();
        }

        private void Limpar()
        {
            textMatricula.Text = "";
            textCpf.Text = "";
            textNome.Text = "";
            textEndereco.Text = "";
        }

        private void Pesquisar()
        {
            try
            {
                int matricula = 0;
                bool n = Int32.TryParse(textMatricula.Text, out matricula);

                Colaborador Colaborador = new Colaborador();
                Colaborador.Matricula = matricula;
                Colaborador.Cpf = textCpf.Text;
                Colaborador.Nome = textNome.Text;

                DataGridViewColaborador.DataSource = Colaborador.Pesquisar();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro);
            }
        }

        private void Salvar()
        {
            try
            {
                int matricula = 0;
                bool n = Int32.TryParse(textMatricula.Text.ToString(), out matricula);

                Colaborador colaborador = new Colaborador();
                colaborador.Matricula = matricula;
                colaborador.Cpf = textCpf.Text.ToString();
                colaborador.Nome = textNome.Text.ToString();
                colaborador.Endereco = textEndereco.Text.ToString();

                if (matricula == 0)
                    colaborador.Incluir();
                else
                    colaborador.Alterar();

                Limpar();
                Pesquisar();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message);
            }
        }

        private void Excluir()
        {
            try
            {
                int matricula = 0;
                bool n = Int32.TryParse(textMatricula.Text.ToString(), out matricula);

                Colaborador colaborador = new Colaborador();
                colaborador.Matricula = matricula;
                colaborador.Excluir();
                Limpar();
                Pesquisar();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message);
            }
        }

        private void ButtonPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void ButtonSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void ButtonExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void ButtonLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
            Pesquisar();
        }

        private void DataGridViewColaborador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textMatricula.Text = DataGridViewColaborador.Rows[e.RowIndex].Cells[0].Value.ToString();
            textCpf.Text = DataGridViewColaborador.Rows[e.RowIndex].Cells[1].Value.ToString();
            textNome.Text = DataGridViewColaborador.Rows[e.RowIndex].Cells[2].Value.ToString();
            textEndereco.Text = DataGridViewColaborador.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

    }
}
