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
    public partial class cadastrobairro : Form
    {
        private int cont;

        public cadastrobairro()
        {
            InitializeComponent();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            cb1.Enabled = true;
            textbox.Enabled = true;
            cb1.Text = null;
            textbox.Text = null;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-6A8PNIJ\\SQLEXPRESS; integrated security=SSPI;initial Catalog=bd_SisImoveis");
            SqlCommand cmd = new SqlCommand("insert into tbbairro values (@nmbairro, @cdcidade)", sqlConn);
            SqlParameter parametrobairro = new SqlParameter("@nmbairro", SqlDbType.VarChar, 100);
            parametrobairro.Value = textbox.Text;
            cmd.Parameters.Add(parametrobairro);
            SqlParameter parametrocidade = new SqlParameter("@cdcidade", SqlDbType.VarChar, 100);
            parametrocidade.Value = cb1.Text;
            cmd.Parameters.Add(parametrocidade);
            sqlConn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("O bairro " + textbox.Text + " foi inserido com sucesso!!!", "Inserido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textbox.Enabled = false;
            cb1.Enabled = false;
            carregaTabela();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Close();
        }

      

        private void cadastrobairro_Load(object sender, EventArgs e)
        {
            ; 
        }

        private void carregaTabela()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-6A8PNIJ\\SQLEXPRESS; integrated security=SSPI;initial Catalog=bd_SisImoveis"))
            {
                connection.Open();

                string query = "SELECT * FROM tbbairro";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }

        }
        private void LimparControles()
        {

            textbox.Text = string.Empty;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            {

                if (!string.IsNullOrEmpty(textbox.Text.Trim()))
                {

                    using (SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-6A8PNIJ\\SQLEXPRESS; integrated security=SSPI;initial Catalog=bd_SisImoveis"))
                    {
                        sqlConn.Open();



                       
                        string query = "DELETE FROM tbbairro WHERE nmbairro = @nmbairro";


                        using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                        {

                            cmd.Parameters.AddWithValue("@nmbairro", textbox.Text.Trim());
                           


                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {

                                MessageBox.Show("Dados excluídos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                LimparControles();
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

        private void button3_Click(object sender, EventArgs e)
        {

            {
               
                if (!string.IsNullOrEmpty(textbox.Text.Trim()))
                {
                    
                    using (SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-6A8PNIJ\\SQLEXPRESS; integrated security=SSPI;initial Catalog=bd_SisImoveis"))
                    {
                        sqlConn.Open();

                       
                        string query = "UPDATE tbbairro SET nmbairro = @nmbairro, cdcidade = @cdcidade WHERE nmbairro = @nmbairro";
                        





                        using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                        {
                           
                            cmd.Parameters.AddWithValue("@nmbairro", textbox.Text.Trim());
                            cmd.Parameters.AddWithValue("@cdcidade", cb1.Text.Trim());

                           
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                
                                MessageBox.Show("Bairro e cidade atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                
                               

                              
                            }
                            else
                            {
                               
                                MessageBox.Show("Nenhum bairro encontrado para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                else
                {
                   
                    MessageBox.Show("Por favor, insira um nome de bairro válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            carregaTabela();
            }
            }
        }
    



















