using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parapharmacie
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            panel3.Visible = false;
            
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2PictureBox3_Click_1(object sender, EventArgs e)
        {
            panel3.Size = new Size(277, 161);
            panel3.Visible = !panel3.Visible;
        }
    }
}
