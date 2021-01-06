using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WebService_Giris.UrunServiceReference1;


namespace WebService_Giris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            UrunlerServisSoapClient client = new UrunlerServisSoapClient();
            string msg = client.HelloWorld();
            MessageBox.Show(msg);

        }

        private void btnUrunler_Click(object sender, EventArgs e)
             
        {
            Kimlik kml = new Kimlik();
            UrunlerServisSoapClient client = new UrunlerServisSoapClient();
         
            kml.KullaniciAdi = "admin";
            kml.Parola = "13";
            dataGridView1.DataSource = client.UrunlerListesi(kml);

            if (client.UrunlerListesi(kml)==null)
            {
                MessageBox.Show("Eşleşme bilgileri hatalı");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TcknDogrula TcnkFrm = new TcknDogrula();
            TcnkFrm.Show();
        }
    }
}
