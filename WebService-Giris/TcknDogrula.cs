using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebService_Giris.TcknServiceReference;

namespace WebService_Giris
{
    public partial class TcknDogrula : Form
    {
        public TcknDogrula()
        {
            InitializeComponent();
        }

        private void TcknDogrula_Load(object sender, EventArgs e)
        {
        }

        private void btnDogrula_Click(object sender, EventArgs e)
        {
            long tckn = Convert.ToInt64(mskdTckn.Text);
            string adi = txtAdi.Text.ToUpper();
            string soyadi = txtSoyadi.Text.ToUpper();
            int dogumYili = Convert.ToInt32(mskdDogumYili.Text);

            KPSPublicSoapClient client = new KPSPublicSoapClient();
           bool sonuc= client.TCKimlikNoDogrula(tckn, adi, soyadi, dogumYili);

            if (sonuc)
            {
                MessageBox.Show("Tckn bilgileri sistemde mevcut");
               
            }
            else
            {
                MessageBox.Show("TC. kayıt bulunamadı!");
            }
        }
    }
}
