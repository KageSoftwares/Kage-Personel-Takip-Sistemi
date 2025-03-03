using System;
using System.Windows.Forms;

namespace PersonelTakipSistemiDetayli
{
    public partial class LoginForm : Form
    {
        // Sabit kullanıcı adı ve şifre (düz metin)
        private const string SabitKullaniciAdi = "kageroot325";
        private const string SabitSifre = "root5567";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim(); // Boşlukları temizle
            string sifre = txtSifre.Text.Trim();               // Boşlukları temizle

            // Boş giriş kontrolü
            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Kullanıcı adı ve şifre alanları boş bırakılamaz.",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kullanıcı adı ve şifre kontrolü
            if (kullaniciAdi == SabitKullaniciAdi && sifre == SabitSifre)
            {
                this.Hide();
                Form1 anaForm = new Form1(); // Form1'i parametresiz aç
                anaForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}