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
    public partial class Produit : Form
    {
        public Produit()
        {
            InitializeComponent();
            Remplirf();
           afficher();
            
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MSI\Documents\parapharmacie.mdf;Integrated Security=True;Connect Timeout=30");
        private void Remplirf()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Id from fournisseurs", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Load(Rdr);
            fabtb.ValueMember = "Id";
            fabtb.DataSource = dt;
            Con.Close();
        }
       private void reinitialiser()
        {
            nomtb.Text = "";
            prixtb.Text = "";
            stocktb.Text = "";


           Cle = 0;
        }
        private void afficher()
        {
            Con.Open();
            string Req = "select * from Produits";
            SqlDataAdapter sda = new SqlDataAdapter(Req, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            listedespro.DataSource = ds.Tables[0];
            Con.Close();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            if (nomtb.Text == "" || prixtb.Text == "" || stocktb.Text == "" || fabtb.SelectedIndex == -1 )
            {
                MessageBox.Show("completez les informations svp");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Req = "insert into Produits values('" + nomtb.Text + "','" + prixtb.Text + "','" + stocktb.Text + "','" + fabtb.SelectedValue.ToString()+ "','" + datetb.Value.Date + "')";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("produits ajoute");
                    
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

        private void label11_Click(object sender, EventArgs e)
        {
            Fabriquants Fab = new Fabriquants();
            Fab.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reinitialiser();
        }
        int Cle = 0;

        private void listedespro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            nomtb.Text = listedespro.SelectedRows[0].Cells[1].Value.ToString();
            prixtb.Text = listedespro.SelectedRows[0].Cells[2].Value.ToString();
            stocktb.Text = listedespro.SelectedRows[0].Cells[3].Value.ToString();
            fabtb.SelectedValue = listedespro.SelectedRows[0].Cells[4].Value.ToString();
            datetb.Text = listedespro.SelectedRows[0].Cells[5].Value.ToString();
            if (nomtb.Text == "")
                Cle = 0;
            else
                Cle = Convert.ToInt32(listedespro.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Cle == 0)
            {
                MessageBox.Show("selectionner le produit a effacer svp");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Req = "delete from Produits where Id=" + Cle + "";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("produit suprimé");
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
            if (nomtb.Text == "" || prixtb.Text == "" || stocktb.Text == "" || fabtb.SelectedIndex == -1)
            {
                MessageBox.Show("informations manquante svp");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Req = "Update Produits set nom='" + nomtb.Text + "',prix=" + prixtb.Text + ",stocks=" + stocktb.Text + ",fabriquant=" + fabtb.SelectedValue.ToString() + ",expiration='"+datetb.Value.Date+"' where Id=" + Cle + ";";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("produit modifié");


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

        private void button13_Click(object sender, EventArgs e)
        {
            achats ach = new achats();
            ach.Show();
            this.Hide();
            Con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void fabtb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
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

        private void button16_Click(object sender, EventArgs e)
        {
            agent ag = new agent();
            ag.Show();
            this.Hide();
            Con.Close();
        }
    }
}
