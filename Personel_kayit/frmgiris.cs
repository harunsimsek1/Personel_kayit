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

namespace Personel_kayit
{
    public partial class frmgiris : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-F59JTTH\\SQLEXPRESS;Initial Catalog=Personel;Integrated Security=True");
        public frmgiris()
        {
            InitializeComponent();
        }

        private void frmgiris_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand x = new SqlCommand("select * from tbl_giris where kullaniciadi=@p1 and sifre=@p2",baglanti);
            x.Parameters.AddWithValue("@p1", textBox1.Text);
            x.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader dr = x.ExecuteReader();
            if (dr.Read())
            {
                Form1 fr = new Form1();
                    fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("yanlış giriş");
            }
            baglanti.Close();
        }
    }
}
