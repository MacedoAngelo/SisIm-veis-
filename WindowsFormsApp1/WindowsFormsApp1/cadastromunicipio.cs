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
    public partial class cadastromunicipio : Form
    {
        private int cont;

        public cadastromunicipio()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            textBox1.Enabled = true;
            comboBox1.SelectedIndex = -1;
            textBox1.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            {
                SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-6A8PNIJ\\SQLEXPRESS; integrated security=SSPI;initial Catalog=bd_SisImoveis");
                SqlCommand cmd = new SqlCommand("insert into tbcidade values (@nmcidade, @cdestado)", sqlConn);
                SqlParameter parametrocidade = new SqlParameter("@nmcidade", SqlDbType.VarChar, 50);
                parametrocidade.Value = textBox1.Text;
                cmd.Parameters.Add(parametrocidade);

                SqlParameter parametroestado = new SqlParameter("@cdestado", SqlDbType.VarChar, 50);
                parametroestado.Value = comboBox1.Text;
                cmd.Parameters.Add(parametroestado);
                sqlConn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("A cidade " + textBox1.Text + " foi inserida com sucesso!!!", "Inserido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
                carregaTabela(); 
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cadastromunicipio_Load(object sender, EventArgs e)
        {
            carregaTabela(); 
        }
        private void carregaUF()
        {
            SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-6A8PNIJ\\SQLEXPRESS; integrated security=SSPI;initial Catalog=bd_SisImoveis");
            SqlCommand cmd = new SqlCommand("select cdestado, nmestado from tbestado order by nmestado", sqlConn);
            sqlConn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "nmestado";
            comboBox1.ValueMember = "cdestado";
            sqlConn.Close();
            sqlConn.Dispose();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)

        {
             
        }

        


        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void carregaTabela()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6A8PNIJ\\SQLEXPRESS; integrated security=SSPI;initial Catalog=bd_SisImoveis"))
            {
                connection.Open();

                string query = "SELECT * FROM tbcidade";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                int cdcidade = cont;

                if (cdcidade != -1)
                {
                    using (SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-6A8PNIJ\\SQLEXPRESS; integrated security=SSPI;initial Catalog=bd_SisImoveis"))
                    {
                        sqlConn.Open();

                        string query = "UPDATE tbcidade SET nmcidade = @nmcidade, cdestado = @cdestado WHERE cdcidade = @cdcidade";

                        using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                        {
                            cmd.Parameters.AddWithValue("@cdcidade", cdcidade);
                            cmd.Parameters.AddWithValue("@nmcidade", textBox1.Text.Trim());
                            cmd.Parameters.AddWithValue("@cdestado", Convert.ToInt32(comboBox1.SelectedValue)); 

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("A cidade foi atualizada com sucesso!", "Atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    carregaTabela();
                    textBox1.Text = null;
                    comboBox1.Text = null;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Nome de cidade não encontrado. Por favor, insira um nome de cidade válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um valor válido para atualização.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {

                if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                {

                    using (SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-6A8PNIJ\\SQLEXPRESS; integrated security=SSPI;initial Catalog=bd_SisImoveis"))
                    {
                        sqlConn.Open();




                        string query = "DELETE FROM tbcidade WHERE nmcidade = @nmcidade";


                        using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                        {

                            cmd.Parameters.AddWithValue("@nmcidade", textBox1.Text.Trim());



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
            }
            carregaTabela();

        }
    }
    }


        
    

