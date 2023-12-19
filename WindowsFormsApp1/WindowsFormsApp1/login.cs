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

namespace WindowsFormsApp1
{
    public partial class login : Form
    {
        private readonly string string_de_conexao = "Data Source=DESKTOP-6A8PNIJ\\SQLEXPRESS; integrated security=SSPI;initial Catalog=bd_SisImoveis";
        public login()
        {
            InitializeComponent();
        }

        

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-6A8PNIJ\\SQLEXPRESS; integrated security=SSPI;initial Catalog=bd_SisImoveis");

        SqlCommand cm = new SqlCommand();

        SqlDataReader dt;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (txt1.Text == "admin" && txt2.Text == "0000")
                {
                    menu geranome = new menu();
                    geranome.Show();
                }

                else { MessageBox.Show("Usuario/senha invalido"); {




                    }
                }
            }
    }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
