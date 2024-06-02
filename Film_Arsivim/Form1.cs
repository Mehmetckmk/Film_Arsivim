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
using static System.Windows.Forms.LinkLabel;

namespace Film_Arsivim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-NTA9CUL\SQLEXPRESS;Initial Catalog=FilmArsivi;Integrated Security=True");


        void Filmler()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLFILMLER", baglanti);
            //Veri Tablosu Nesnesi Oluşturduk
            DataTable dt = new DataTable();
            //Tabloya Select Sorgusundan Çektiğin Verileri Doldur
            da.Fill(dt);
            //Form Yüklendiğinde Listele
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Filmler();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLFILMLER(AD,KATEGORI,LINK) values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtFilmAd.Text);
            komut.Parameters.AddWithValue("@p2", txtKategori.Text);
            komut.Parameters.AddWithValue("@p3", txtLink.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film Listenize Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Filmler();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            webBrowser1.Navigate("" + link + "");

        }

        private void btnHakkimizda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mehmet Çakmak");
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRenkDegistir_Click(object sender, EventArgs e)
        {


            Random rastgele = new Random();
            this.BackColor = Color.FromArgb(rastgele.Next(256), rastgele.Next(256), rastgele.Next(256));


        }

        private void btnTamEkran_Click(object sender, EventArgs e)
        {
            int secilenIndex = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilenIndex].Cells[3].Value.ToString();

            TamEkran tmEkran = new TamEkran(link);
            tmEkran.Show();
        }
    }
}
