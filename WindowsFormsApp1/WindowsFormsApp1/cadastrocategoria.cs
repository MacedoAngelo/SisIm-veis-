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
    public partial class cadastrocategoria : Form
    {
        private int cont;

        public cadastrocategoria()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                txt1.Enabled = true;
                txt1.Text = null;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-6A8PNIJ\\SQLEXPRESS; integrated security=SSPI;initial Catalog=bd_SisImoveis");
            SqlCommand cmd = new SqlCommand("insert into tbcategoria values (@nmcategoria, @cdcategoria)", sqlConn);
            SqlParameter parametrobairro = new SqlParameter("@nmcategoria", SqlDbType.VarChar, 50);
            parametrobairro.Value = txt1.Text;
            cmd.Parameters.Add(parametrobairro);
            SqlParameter parametrocidade = new SqlParameter("@cdcategoria", SqlDbType.VarChar, 50);
            parametrocidade.Value = txt1.Text;
            cmd.Parameters.Add(parametrocidade);
            sqlConn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("A categoria " + txt1.Text + " foi inserido com sucesso!!!", "Inserido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt1.Enabled = false;
            carregaTabela();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cadastrocategoria_Load(object sender, EventArgs e)
        {

        }

        private void carregaTabela()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6A8PNIJ\\SQLEXPRESS; integrated security=SSPI;initial Catalog=bd_SisImoveis"))
            {
                connection.Open();

                string query = "SELECT * FROM tbcategoria";

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

            {
                if (!string.IsNullOrEmpty(txt1.Text))
                {
                    int cdcidade = cont;

                    if (cdcidade != -1)
                    {
                        using (SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-6A8PNIJ\\SQLEXPRESS; integrated security=SSPI;initial Catalog=bd_SisImoveis"))
                        {
                            sqlConn.Open();

                            string query = "UPDATE tbcategoria SET nmcategoria = @nmcategoria, cdcategoria = @cdcategoria WHERE cdcategoria = @cdcategoria";

                            using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                            {
                                cmd.Parameters.AddWithValue("@cdcategoria", cdcidade);
                               
                                cmd.Parameters.AddWithValue("@nmcategoria", txt1.Text.Trim());
                               

                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("A cidade foi atualizada com sucesso!", "Atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Restante do código...
                        carregaTabela();
                        txt1.Text = null;
                        
                        button4.Enabled = false;
                        button3.Enabled = false;
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {

                if (!string.IsNullOrEmpty(txt1.Text.Trim()))
                {

                    using (SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-6A8PNIJ\\SQLEXPRESS; integrated security=SSPI;initial Catalog=bd_SisImoveis"))
                    {
                        sqlConn.Open();


                        string query = "DELETE FROM tbcategoria WHERE nmcategoria = @nmcategoria";


                        using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                        {

                            cmd.Parameters.AddWithValue("@nmcategoria", txt1.Text.Trim());


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

   

       
    










