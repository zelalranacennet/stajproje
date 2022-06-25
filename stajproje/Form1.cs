using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace stajproje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection bagla = new SqlConnection("Data Source=ZELAL-CENNET21;Initial Catalog=stajpizza;Integrated Security=True");
        private void goruntule()
        {
            bagla.Open();
            SqlCommand komut1 = new SqlCommand(" select*from siparial", bagla);
            SqlDataReader oku = komut1.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["adres"].ToString());
                ekle.SubItems.Add(oku["pizaboy"].ToString());
                ekle.SubItems.Add(oku["icecek"].ToString());
                ekle.SubItems.Add(oku["soslar"].ToString());
                ekle.SubItems.Add(oku["pizzaturu"].ToString());
                listView1.Items.Add(ekle);



            }
            bagla.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bagla.Open();
            SqlCommand komut2 = new SqlCommand("Insert into siparial (id,adsoyad,telefon,adres,pizaboy,icecek,soslar,pizzaturu)values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + maskedTextBox1.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + comboBox3.Text.ToString() + "', '" + comboBox4.Text.ToString() + "')", bagla);
            komut2.ExecuteNonQuery();
            bagla.Close();
            listView1.Items.Clear();

            goruntule();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        
                bagla.Open();
                SqlCommand komut4 = new SqlCommand("Update siparial set id='" + textBox1.Text.ToString() + "',adsoyad='" + textBox2.Text.ToString() + "',telefon='" + maskedTextBox1.Text.ToString() + "',adres='" + textBox4.Text.ToString() + "',pizaboy='" + comboBox1.Text.ToString() + "',icecek='" + comboBox2.Text.ToString() + "',soslar='" + comboBox3.Text.ToString() + "',pizzaturu= '" + comboBox4.Text.ToString() + "'where id=" + id + "", bagla);
                komut4.ExecuteNonQuery();
                bagla.Close();

                MessageBox.Show("güncelleme gercekleşti");
            listView1.Items.Clear();

            goruntule();


        }
        int id = 0;

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            maskedTextBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[5].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[6].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[7].Text;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            goruntule();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            bagla.Open();
            SqlCommand komut6 = new SqlCommand("Delete from siparial where id=(" + id + ")", bagla);
            komut6.ExecuteNonQuery();
            bagla.Close();
            listView1.Items.Clear();
            goruntule();

        }
    }
}
