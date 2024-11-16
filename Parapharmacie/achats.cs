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
    public partial class achats : Form
    {
        public achats()
        {
            InitializeComponent();
            Remplirf();
            afficherpro();
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
            DataTable dt1 = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Load(Rdr);

            comboBox2.ValueMember = "Id";
            comboBox2.DataSource = dt;

            Con.Close();
        }
        private void afficherpro()
        {
            Con.Open();
            string Req = "select Id,nom,prix,stocks from produits";
            SqlDataAdapter sda = new SqlDataAdapter(Req, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            listedespro.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void reinitialiser()
        {
            prodtb.Text = "";
            prixtb.Text = "";
            qttb.Text = "";
            retb.Text = "";
            stocktb.Text = "";
            desctb.Text = "";


            Cle = 0;
        }
        private void afficher()
        {
            Con.Open();
            string Req = "select * from achat";
            SqlDataAdapter sda = new SqlDataAdapter(Req, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            listedesventes.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void modifierstock()
        {
            Con.Open();
            int newstock = Convert.ToInt32(stocktb.Text) + Convert.ToInt32(qttb.Text);
            string Req = "Update Produits set stocks=" + newstock + " where Id=" + Cle + ";";
            SqlCommand cmd = new SqlCommand(Req, Con);
            cmd.ExecuteNonQuery();




            Con.Close();
            afficher();
            reinitialiser();

        }

        private void listedesventes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox2.SelectedValue = listedesventes.SelectedRows[0].Cells[1].Value.ToString();
            dateTimePicker1.Text = listedesventes.SelectedRows[0].Cells[2].Value.ToString();
            prodtb.Text = listedesventes.SelectedRows[0].Cells[3].Value.ToString();
            prixtb.Text = listedesventes.SelectedRows[0].Cells[4].Value.ToString();
            qttb.Text = listedesventes.SelectedRows[0].Cells[5].Value.ToString();
            



            retb.Text = listedesventes.SelectedRows[0].Cells[6].Value.ToString();
            int montant = Convert.ToInt32(listedesventes.SelectedRows[0].Cells[7].Value.ToString());

            desctb.Text = listedesventes.SelectedRows[0].Cells[8].Value.ToString();

            if (comboBox2.SelectedIndex == -1)
                Cle = 0;
            else
                Cle = Convert.ToInt32(listedesventes.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1 || prodtb.Text == "" || prixtb.Text == "" || retb.Text == "" || desctb.Text == "" || qttb.Text == "" || stocktb.Text == "")
            {
                MessageBox.Show("completez les informations svp");
            }
            else
            {
                if (Convert.ToInt32(retb.Text) > Convert.ToInt32(qttb.Text) * Convert.ToInt32(prixtb.Text) - Convert.ToInt32(retb.Text))
                {
                    MessageBox.Show("remise grande");
                }
                else
                {
                    try
                    {
                        Con.Open();
                        int montant = Convert.ToInt32(qttb.Text) * Convert.ToInt32(prixtb.Text) - Convert.ToInt32(retb.Text);
                        string Req = "insert into achat values('" + comboBox2.SelectedValue.ToString() + "','" + dateTimePicker1.Value.Date + "','" + prodtb.Text + "','" + prixtb.Text + "','" + qttb.Text + "','" + retb.Text + "','" + montant + "','" + desctb.Text + "')";
                        SqlCommand cmd = new SqlCommand(Req, Con);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("achat ajoute");

                        Con.Close();
                        modifierstock();
                        afficher();
                        afficherpro();
                        reinitialiser();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reinitialiser();
        }
        int Cle = 0;

        private void listedespro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            prodtb.Text = listedespro.SelectedRows[0].Cells[1].Value.ToString();
            prixtb.Text = listedespro.SelectedRows[0].Cells[2].Value.ToString();
            stocktb.Text = listedespro.SelectedRows[0].Cells[3].Value.ToString();
            desctb.Text = "";
            retb.Text = "";
            if (comboBox2.SelectedIndex == -1)
                Cle = 0;
            else
                Cle = Convert.ToInt32(listedespro.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Cle == 0)
            {
                MessageBox.Show("selectionner la vente a effacer svp");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Req = "delete from achat where Id=" + Cle + "";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("vente suprimé");
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
            if (comboBox2.SelectedIndex == -1 || prodtb.Text == "" || prixtb.Text == "" || retb.Text == "" || desctb.Text == "" || qttb.Text == "")
            {
                MessageBox.Show("informations manquante svp");
            }
            else
            {
                try
                {
                    Con.Open();
                    int montant = Convert.ToInt32(qttb.Text) * Convert.ToInt32(prixtb.Text) - Convert.ToInt32(retb.Text);
                    string Req = "Update achat set fournisseur='" + comboBox2.SelectedValue.ToString() + "',date='" + dateTimePicker1.Value.Date + "',produit='" + prodtb.Text + "',prix=" + prixtb.Text + ",quantite=" + qttb.Text + ",remise=" + retb.Text + ",prix_total='" + montant + "',description='" + desctb.Text + "' where Id=" + Cle + ";";
                    SqlCommand cmd = new SqlCommand(Req, Con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("achat modifié");


                    Con.Close();
                    afficher();
                    afficherpro();
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
