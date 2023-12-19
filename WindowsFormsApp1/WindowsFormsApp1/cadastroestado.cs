using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class cadastroestado : Form
    {
        private int cont;

        public cadastroestado()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            txt1.Enabled = true;
            textBox1.Text = null;
            txt1.Text = null;
        }

        private void cadastroestado_Load(object sender, EventArgs e)
        {
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-6A8PNIJ\\SQLEXPRESS; integrated security=SSPI;initial Catalog=bd_SisImoveis");
            SqlCommand cmd = new SqlCommand("insert into tbestado values (@nmestado, @ufestado)", sqlConn);
            SqlParameter parametrobairro = new SqlParameter("@nmestado", SqlDbType.VarChar, 50);
            parametrobairro.Value = txt1.Text;
            cmd.Parameters.Add(parametrobairro);
            SqlParameter parametrocidade = new SqlParameter("@ufestado", SqlDbType.Char, 2);
            parametrocidade.Value = textBox1.Text;
            cmd.Parameters.Add(parametrocidade);
            sqlConn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("A estado " + txt1.Text + " foi inserido com sucesso!!!", "Inserido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt1.Enabled = false;
            carregaTabela();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void carregaTabela()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6A8PNIJ\\SQLEXPRESS; integrated security=SSPI;initial Catalog=bd_SisImoveis"))
            {
                connection.Open();

                string query = "SELECT * FROM tbestado";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt1.Text.Trim()))
            {

                using (SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-6A8PNIJ\\SQLEXPRESS; integrated security=SSPI;initial Catalog=bd_SisImoveis"))
                {
                    sqlConn.Open();




                    string query = "DELETE FROM tbestado WHERE nmestado = @nmestado";


                    using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                    {

                        cmd.Parameters.AddWithValue("@nmestado", txt1.Text.Trim());



                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {

                            MessageBox.Show("Dados excluídos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);



                        }
                        else
                        {

                            MessageBox.Show("Nenhum registro encontrado para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {

                MessageBox.Show("Por favor, insira um valor válido para o campo-chave.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            carregaTabela();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                if (!string.IsNullOrEmpty(txt1.Text))
                {
                    int cdcidade = cont;

                    if (cdcidade != -1)
                    {
                        using (SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-6A8PNIJ\\SQLEXPRESS; integrated security=SSPI;initial Catalog=bd_SisImoveis"))
                        {
                            sqlConn.Open();

                            string query = "UPDATE tbestado SET ufestado = @ufestado, nmestado = @nmestado WHERE nmestado = @nmestado";

                            using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                            {
                                cmd.Parameters.AddWithValue("@cdestado", cdcidade);
                                cmd.Parameters.AddWithValue("@nmestado", txt1.Text.Trim());
                                cmd.Parameters.AddWithValue("@ufestado", textBox1.Text.Trim());

                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("O Estado foi atualizada com sucesso!", "Atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        carregaTabela();
                        txt1.Text = null;
                        textBox1.Text = null;
                        button4.Enabled = true;
                        button3.Enabled = true;
                        button1.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Estado não encontrado. Por favor, insira um nome de cidade válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, insira um valor válido para atualização.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
    }

    
    

