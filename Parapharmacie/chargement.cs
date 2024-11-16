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
    public partial class chargement : Form
    {
        public chargement()
        {
            InitializeComponent();
        }
        int pdd = 0; 
        private void timer1_Tick(object sender, EventArgs e)
        {
            pdd += 1;
            guna2CircleProgressBar1.Value = pdd;
            pourcentage.Text = pdd + "%";
            if(guna2CircleProgressBar1.Value == 100)
            {
                guna2CircleProgressBar1.Value = 0;
                timer1.Stop();
                Form1 Mycon = new Form1();
                Mycon.Show();
                this.Hide();
            }
        }

        private void chargement_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void pourcentage_Click(object sender, EventArgs e)
        {

        }
    }
}
