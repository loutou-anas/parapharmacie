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
    public partial class founisseurs : Form
    {
        public founisseurs()
        {
            InitializeComponent();
            afficher();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MSI\Documents\parapharmacie.mdf;Integrated Security=True;Connect Timeout=30");
        private void reinitialiser()
        {
            nomtb.Text = "";
            prenomtb.Text = "";
            adrtb.Text = "";
            desctb.Text = "";
            teltb.Text = "";
            

            Cle = 0;
        }
        private void afficher()
        {
            Con.Open();
            string Req = "select * from fournisseurs";
            SqlDataAdapter sda = new SqlDataAdapter(Req, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            listedesfab.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
        


        

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (nomtb.Text == "" || prenomtb.Text == "" || adrtb.Text == "" || desctb.Text == "" || teltb.Text == "")
            {
                MessageBox.Show("completez les informations svp");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Req = "insert into fournisseurs values('" + nomtb.Text + "','" + prenomtb.Text + "','" + adrtb.Text + "','" + desctb.Text + "','" + teltb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("fournisseur ajoute");


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
        private void button4_Click_1(object sender, EventArgs e)
        {
            reinitialiser();
        }
        int Cle = 0;
        private void listedesfab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            nomtb.Text = listedesfab.SelectedRows[0].Cells[1].Value.ToString();
            prenomtb.Text = listedesfab.SelectedRows[0].Cells[2].Value.ToString();
            adrtb.Text = listedesfab.SelectedRows[0].Cells[3].Value.ToString();
            desctb.Text = listedesfab.SelectedRows[0].Cells[4].Value.ToString();
            teltb.Text = listedesfab.SelectedRows[0].Cells[5].Value.ToString();

            if (nomtb.Text == "")
                Cle = 0;
            else
                Cle = Convert.ToInt32(listedesfab.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            if (nomtb.Text == "" || prenomtb.Text == "" || adrtb.Text == "" || desctb.Text == "" || teltb.Text == "")
            {
                MessageBox.Show("informations manquante svp");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Req = "Update fournisseurs set nom='" + nomtb.Text + "',prenom='" + prenomtb.Text + "',adresse='" + adrtb.Text + "',description='" + desctb.Text + "',telephone='" + teltb.Text + "' where Id=" + Cle + "";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("fournisseur modifié");


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

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Cle == 0)
            {
                MessageBox.Show("selectionner le fournisseurs a effacer svp");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Req = "delete from fournisseurs where Id=" + Cle + "";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("fournisseur suprimé");
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

        private void button11_Click(object sender, EventArgs e)
        {
            Produit pr = new Produit();
            pr.Show();
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

        private void button16_Click(object sender, EventArgs e)
        {
            agent ag = new agent();
            ag.Show();
            this.Hide();
            Con.Close();
        }
    }
}
