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

namespace Parapharmacie
{
    public partial class agent : Form
    {
        public agent()
        {
            InitializeComponent();
            afficher();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MSI\Documents\parapharmacie.mdf;Integrated Security=True;Connect Timeout=30");
        private void reinitialiser()
        {
            nomtb.Text = "";
            passtb.Text = "";
            teltb.Text = "";
            
            Cle = 0;
        }
        private void afficher()
        {
            Con.Open();
            string Req = "select * from agent";
            SqlDataAdapter sda = new SqlDataAdapter(Req, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            listedesag.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nomtb.Text == ""  || passtb.Text == "" || teltb.Text == "")
            {
                MessageBox.Show("completez les informations svp");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Req = "insert into agent values('" + nomtb.Text + "','" + ddn.Value.Date + "','" + teltb.Text + "','"+passtb.Text+"')";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("agent ajoute");


                    Con.Close();
                    afficher();
                    reinitialiser();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            reinitialiser(); 
        }
        int Cle = 0;

        private void listedesfab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            nomtb.Text = listedesag.SelectedRows[0].Cells[1].Value.ToString();
            ddn.Text = listedesag.SelectedRows[0].Cells[2].Value.ToString();
            teltb.Text = listedesag.SelectedRows[0].Cells[3].Value.ToString();
            passtb.Text = listedesag.SelectedRows[0].Cells[4].Value.ToString();
            
            if (nomtb.Text == "")
                Cle = 0;
            else
                Cle = Convert.ToInt32(listedesag.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Cle == 0)
            {
                MessageBox.Show("selectionner l'agent a effacer svp");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Req = "delete from agent where Id=" + Cle + "";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("agent suprimé");
                    Con.Close();
                    afficher();
                    reinitialiser();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nomtb.Text == "" || passtb.Text == "" || teltb.Text == "")
            {
                MessageBox.Show("informations manquante svp");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Req = "Update agent set nom='" + nomtb.Text + "',date='" + ddn.Value.Date + "',telephone='" + teltb.Text + "',mdp='" + passtb.Text + "' where Id=" + Cle + ";";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("agent modifié");


                    Con.Close();
                    afficher();
                    reinitialiser();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
            Con.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            founisseurs fr = new founisseurs();
            fr.Show();
            this.Hide();
            Con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Fabriquants fa = new Fabriquants();
            fa.Show();
            this.Hide();
            Con.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ventes ve = new ventes();
            ve.Show();
            this.Hide();
            Con.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            achats ach = new achats();
            ach.Show();
            this.Hide();
            Con.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            clients cl = new clients();
            cl.Show();
            this.Hide();
            Con.Close();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Produit pr = new Produit();
            pr.Show();
            this.Hide();
            Con.Close();
        }
    }
}



