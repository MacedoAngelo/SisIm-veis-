using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void munícipioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastromunicipio geranome = new cadastromunicipio();
            geranome.Show();
        }

        private void qaurtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastroquarto geranome = new cadastroquarto();
            geranome.Show();
        }

        private void imóveisToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void poCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void jaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bairroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastrobairro geranome = new cadastrobairro();
            geranome.Show();
        }

        private void estadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastroestado geranome = new cadastroestado();
            geranome.Show();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastrocategoria geranome = new cadastrocategoria();
            geranome.Show();
        }

        private void negócioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastronegocio geranome = new cadastronegocio();
            geranome.Show();
        }

        private void imóveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
