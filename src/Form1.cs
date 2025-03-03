using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PersonelTakipSistemiDetayli
{
    public partial class Form1 : Form
    {

        public class Personel
        {
            public int PersonelID { get; set; }
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string Departman { get; set; }
            public string Pozisyon { get; set; }
            public string Telefon { get; set; }
            public string Eposta { get; set; }
            public decimal Maas { get; set; }
            public DateTime IseBaslamaTarihi { get; set; }
            public byte[] Foto { get; set; }
            public int ToplamIzinGun { get; set; }
            public double ToplamFazlaMesai { get; set; }
        }

        public class CalismaSaati
        {
            public int CalismaID { get; set; }
            public int PersonelID { get; set; }
            public DateTime Tarih { get; set; }
            public DateTime GirisSaati { get; set; }
            public DateTime CikisSaati { get; set; }
            public double FazlaMesai { get; set; }
            public string Notlar { get; set; }
            public bool OnaylandiMi { get; set; }
            public string Durum { get; set; }
        }

        public class Izin
        {
            public int IzinID { get; set; }
            public int PersonelID { get; set; }
            public DateTime Baslangic { get; set; }
            public DateTime Bitis { get; set; }
            public string IzinTuru { get; set; }
            public double GunSayisi { get; set; }
            public string Aciklama { get; set; }
            public bool OnaylandiMi { get; set; }
            public DateTime TalepTarihi { get; set; }
            public string Durum { get; set; }
        }


        private string connectionString = "Data Source=PersonelTakip.db;Version=3;";
        private int selectedPersonelID = 0;
        private int selectedCalismaID = 0;
        private int selectedIzinID = 0;

        public Form1()
        {
            InitializeComponent();
            VeritabaniOlustur();
            VerileriYukle();
            PlaceholderAyarla();
            ComboBoxlariDoldur();
            this.Text = "Kage Personel Takip Sistemi v2.0";
        }


        private void VeritabaniOlustur()
        {
            if (!File.Exists("PersonelTakip.db"))
            {
                SQLiteConnection.CreateFile("PersonelTakip.db");
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string personelTablosu = @"
                        CREATE TABLE Personel (
                            PersonelID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Ad TEXT NOT NULL,
                            Soyad TEXT NOT NULL,
                            Departman TEXT,
                            Pozisyon TEXT,
                            Telefon TEXT,
                            Eposta TEXT,
                            Maas REAL,
                            IseBaslamaTarihi TEXT,
                            Foto BLOB,
                            ToplamIzinGun INTEGER,
                            ToplamFazlaMesai REAL
                        )";
                    string calismaSaatleriTablosu = @"
                        CREATE TABLE CalismaSaatleri (
                            CalismaID INTEGER PRIMARY KEY AUTOINCREMENT,
                            PersonelID INTEGER,
                            Tarih TEXT,
                            GirisSaati TEXT,
                            CikisSaati TEXT,
                            FazlaMesai REAL,
                            Notlar TEXT,
                            OnaylandiMi INTEGER,
                            Durum TEXT,
                            FOREIGN KEY (PersonelID) REFERENCES Personel(PersonelID)
                        )";
                    string izinlerTablosu = @"
                        CREATE TABLE Izinler (
                            IzinID INTEGER PRIMARY KEY AUTOINCREMENT,
                            PersonelID INTEGER,
                            Baslangic TEXT,
                            Bitis TEXT,
                            IzinTuru TEXT,
                            GunSayisi REAL,
                            Aciklama TEXT,
                            OnaylandiMi INTEGER,
                            TalepTarihi TEXT,
                            Durum TEXT,
                            FOREIGN KEY (PersonelID) REFERENCES Personel(PersonelID)
                        )";

                    using (var cmd = new SQLiteCommand(personelTablosu, conn)) { cmd.ExecuteNonQuery(); }
                    using (var cmd = new SQLiteCommand(calismaSaatleriTablosu, conn)) { cmd.ExecuteNonQuery(); }
                    using (var cmd = new SQLiteCommand(izinlerTablosu, conn)) { cmd.ExecuteNonQuery(); }


                    VarsayilanVerilerEkle(conn);
                }
            }
        }


        private void VarsayilanVerilerEkle(SQLiteConnection conn)
        {
            string insertPersonel = @"
                INSERT INTO Personel (Ad, Soyad, Departman, Pozisyon, Telefon, Eposta, Maas, IseBaslamaTarihi, ToplamIzinGun, ToplamFazlaMesai)
                VALUES (@Ad, @Soyad, @Departman, @Pozisyon, @Telefon, @Eposta, @Maas, @IseBaslamaTarihi, @ToplamIzinGun, @ToplamFazlaMesai)";
            string insertCalisma = @"
                INSERT INTO CalismaSaatleri (PersonelID, Tarih, GirisSaati, CikisSaati, FazlaMesai, Notlar, OnaylandiMi, Durum)
                VALUES (@PersonelID, @Tarih, @GirisSaati, @CikisSaati, @FazlaMesai, @Notlar, @OnaylandiMi, @Durum)";
            string insertIzin = @"
                INSERT INTO Izinler (PersonelID, Baslangic, Bitis, IzinTuru, GunSayisi, Aciklama, OnaylandiMi, TalepTarihi, Durum)
                VALUES (@PersonelID, @Baslangic, @Bitis, @IzinTuru, @GunSayisi, @Aciklama, @OnaylandiMi, @TalepTarihi, @Durum)";

            using (var cmd = new SQLiteCommand(insertPersonel, conn))
            {
                cmd.Parameters.AddWithValue("@Ad", "Ahmet");
                cmd.Parameters.AddWithValue("@Soyad", "Yılmaz");
                cmd.Parameters.AddWithValue("@Departman", "IT");
                cmd.Parameters.AddWithValue("@Pozisyon", "Yazılım Geliştirici");
                cmd.Parameters.AddWithValue("@Telefon", "555-123-4567");
                cmd.Parameters.AddWithValue("@Eposta", "ahmet@example.com");
                cmd.Parameters.AddWithValue("@Maas", 10000);
                cmd.Parameters.AddWithValue("@IseBaslamaTarihi", DateTime.Now.AddYears(-2).ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ToplamIzinGun", 15);
                cmd.Parameters.AddWithValue("@ToplamFazlaMesai", 10);
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Ad", "Ayşe");
                cmd.Parameters.AddWithValue("@Soyad", "Kara");
                cmd.Parameters.AddWithValue("@Departman", "İnsan Kaynakları");
                cmd.Parameters.AddWithValue("@Pozisyon", "İK Uzmanı");
                cmd.Parameters.AddWithValue("@Telefon", "555-987-6543");
                cmd.Parameters.AddWithValue("@Eposta", "ayse@example.com");
                cmd.Parameters.AddWithValue("@Maas", 8000);
                cmd.Parameters.AddWithValue("@IseBaslamaTarihi", DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ToplamIzinGun", 20);
                cmd.Parameters.AddWithValue("@ToplamFazlaMesai", 5);
                cmd.ExecuteNonQuery();
            }

            using (var cmd = new SQLiteCommand(insertCalisma, conn))
            {
                cmd.Parameters.AddWithValue("@PersonelID", 1);
                cmd.Parameters.AddWithValue("@Tarih", DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@GirisSaati", DateTime.Today.AddDays(-1).AddHours(8).ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@CikisSaati", DateTime.Today.AddDays(-1).AddHours(18).ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@FazlaMesai", 1);
                cmd.Parameters.AddWithValue("@Notlar", "Proje teslimi için fazla mesai");
                cmd.Parameters.AddWithValue("@OnaylandiMi", 1);
                cmd.Parameters.AddWithValue("@Durum", "Tamamlandı");
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PersonelID", 2);
                cmd.Parameters.AddWithValue("@Tarih", DateTime.Today.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@GirisSaati", DateTime.Today.AddHours(9).ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@CikisSaati", DateTime.Today.AddHours(17).ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@FazlaMesai", 0);
                cmd.Parameters.AddWithValue("@Notlar", "Normal mesai");
                cmd.Parameters.AddWithValue("@OnaylandiMi", 0);
                cmd.Parameters.AddWithValue("@Durum", "Beklemede");
                cmd.ExecuteNonQuery();
            }

            using (var cmd = new SQLiteCommand(insertIzin, conn))
            {
                cmd.Parameters.AddWithValue("@PersonelID", 1);
                cmd.Parameters.AddWithValue("@Baslangic", DateTime.Today.AddDays(1).ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Bitis", DateTime.Today.AddDays(6).ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@IzinTuru", "Yıllık");
                cmd.Parameters.AddWithValue("@GunSayisi", 5);
                cmd.Parameters.AddWithValue("@Aciklama", "Aile tatili");
                cmd.Parameters.AddWithValue("@OnaylandiMi", 1);
                cmd.Parameters.AddWithValue("@TalepTarihi", DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@Durum", "Onaylandı");
                cmd.ExecuteNonQuery();
            }
        }


        private void VerileriYukle()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();


                var personelListesi = new List<Personel>();
                using (var cmd = new SQLiteCommand("SELECT * FROM Personel", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        personelListesi.Add(new Personel
                        {
                            PersonelID = reader.GetInt32(0),
                            Ad = reader.GetString(1),
                            Soyad = reader.GetString(2),
                            Departman = reader.IsDBNull(3) ? null : reader.GetString(3),
                            Pozisyon = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Telefon = reader.IsDBNull(5) ? null : reader.GetString(5),
                            Eposta = reader.IsDBNull(6) ? null : reader.GetString(6),
                            Maas = reader.IsDBNull(7) ? 0 : reader.GetDecimal(7),
                            IseBaslamaTarihi = DateTime.Parse(reader.GetString(8)),
                            Foto = reader.IsDBNull(9) ? null : (byte[])reader["Foto"],
                            ToplamIzinGun = reader.GetInt32(10),
                            ToplamFazlaMesai = reader.GetDouble(11)
                        });
                    }
                }
                dgvPersonel.DataSource = personelListesi;


                var calismaSaatleriListesi = new List<CalismaSaati>();
                using (var cmd = new SQLiteCommand("SELECT * FROM CalismaSaatleri", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        calismaSaatleriListesi.Add(new CalismaSaati
                        {
                            CalismaID = reader.GetInt32(0),
                            PersonelID = reader.GetInt32(1),
                            Tarih = DateTime.Parse(reader.GetString(2)),
                            GirisSaati = DateTime.Parse(reader.GetString(3)),
                            CikisSaati = DateTime.Parse(reader.GetString(4)),
                            FazlaMesai = reader.GetDouble(5),
                            Notlar = reader.IsDBNull(6) ? null : reader.GetString(6),
                            OnaylandiMi = reader.GetInt32(7) == 1,
                            Durum = reader.IsDBNull(8) ? null : reader.GetString(8)
                        });
                    }
                }
                dgvCalismaSaatleri.DataSource = calismaSaatleriListesi;


                var izinListesi = new List<Izin>();
                using (var cmd = new SQLiteCommand("SELECT * FROM Izinler", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        izinListesi.Add(new Izin
                        {
                            IzinID = reader.GetInt32(0),
                            PersonelID = reader.GetInt32(1),
                            Baslangic = DateTime.Parse(reader.GetString(2)),
                            Bitis = DateTime.Parse(reader.GetString(3)),
                            IzinTuru = reader.IsDBNull(4) ? null : reader.GetString(4),
                            GunSayisi = reader.GetDouble(5),
                            Aciklama = reader.IsDBNull(6) ? null : reader.GetString(6),
                            OnaylandiMi = reader.GetInt32(7) == 1,
                            TalepTarihi = DateTime.Parse(reader.GetString(8)),
                            Durum = reader.IsDBNull(9) ? null : reader.GetString(9)
                        });
                    }
                }
                dgvIzinler.DataSource = izinListesi;


                cmbSaatPersonelSec.DataSource = personelListesi;
                cmbSaatPersonelSec.DisplayMember = "Ad";
                cmbSaatPersonelSec.ValueMember = "PersonelID";
                cmbIzinPersonelSec.DataSource = personelListesi.ToList();
                cmbIzinPersonelSec.DisplayMember = "Ad";
                cmbIzinPersonelSec.ValueMember = "PersonelID";

                GuncelleIstatistikler();
            }
        }

      
        private void PlaceholderAyarla()
        {
            txtArama.Text = "Personel Ara...";
            txtArama.ForeColor = Color.Gray;
        }

        private void TxtArama_Enter(object sender, EventArgs e)
        {
            if (txtArama.Text == "Personel Ara...")
            {
                txtArama.Text = "";
                txtArama.ForeColor = Color.Black;
            }
        }

        private void TxtArama_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtArama.Text))
            {
                txtArama.Text = "Personel Ara...";
                txtArama.ForeColor = Color.Gray;
            }
        }


        private void BtnFotoSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Resim Dosyaları|*.jpg;*.png;*.bmp" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbPersonelFoto.Image = Image.FromFile(ofd.FileName);
            }
        }


        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                MessageBox.Show("Ad ve Soyad alanları zorunludur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string insertQuery = @"
                    INSERT INTO Personel (Ad, Soyad, Departman, Pozisyon, Telefon, Eposta, Maas, IseBaslamaTarihi, Foto, ToplamIzinGun, ToplamFazlaMesai)
                    VALUES (@Ad, @Soyad, @Departman, @Pozisyon, @Telefon, @Eposta, @Maas, @IseBaslamaTarihi, @Foto, @ToplamIzinGun, @ToplamFazlaMesai);
                    SELECT last_insert_rowid();";
                using (var cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Ad", ad);
                    cmd.Parameters.AddWithValue("@Soyad", soyad);
                    cmd.Parameters.AddWithValue("@Departman", txtDepartman.Text);
                    cmd.Parameters.AddWithValue("@Pozisyon", txtPozisyon.Text);
                    cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                    cmd.Parameters.AddWithValue("@Eposta", txtEposta.Text);
                    cmd.Parameters.AddWithValue("@Maas", decimal.TryParse(txtMaas.Text, out decimal maas) ? maas : 0);
                    cmd.Parameters.AddWithValue("@IseBaslamaTarihi", dtpIseBaslama.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Foto", pbPersonelFoto.Image != null ? ImageToByteArray(pbPersonelFoto.Image) : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ToplamIzinGun", 20);
                    cmd.Parameters.AddWithValue("@ToplamFazlaMesai", 0);
                    cmd.ExecuteScalar();

                    VerileriYukle();
                    Temizle();
                    MessageBox.Show($"{ad} {soyad} başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (selectedPersonelID == 0)
            {
                MessageBox.Show("Lütfen güncellenecek bir personel seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string updateQuery = @"
                    UPDATE Personel 
                    SET Ad = @Ad, Soyad = @Soyad, Departman = @Departman, Pozisyon = @Pozisyon, Telefon = @Telefon, 
                        Eposta = @Eposta, Maas = @Maas, IseBaslamaTarihi = @IseBaslamaTarihi, Foto = @Foto
                    WHERE PersonelID = @PersonelID";
                using (var cmd = new SQLiteCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@PersonelID", selectedPersonelID);
                    cmd.Parameters.AddWithValue("@Ad", ad);
                    cmd.Parameters.AddWithValue("@Soyad", soyad);
                    cmd.Parameters.AddWithValue("@Departman", txtDepartman.Text);
                    cmd.Parameters.AddWithValue("@Pozisyon", txtPozisyon.Text);
                    cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                    cmd.Parameters.AddWithValue("@Eposta", txtEposta.Text);
                    cmd.Parameters.AddWithValue("@Maas", decimal.TryParse(txtMaas.Text, out decimal maas) ? maas : 0);
                    cmd.Parameters.AddWithValue("@IseBaslamaTarihi", dtpIseBaslama.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Foto", pbPersonelFoto.Image != null ? ImageToByteArray(pbPersonelFoto.Image) : (object)DBNull.Value);
                    cmd.ExecuteNonQuery();

                    VerileriYukle();
                    Temizle();
                    MessageBox.Show($"{ad} {soyad} bilgileri güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (selectedPersonelID == 0)
            {
                MessageBox.Show("Lütfen silinecek bir personel seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ad = "";
            string soyad = "";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string personelAdSoyadQuery = "SELECT Ad, Soyad FROM Personel WHERE PersonelID = @PersonelID";
                using (var cmd = new SQLiteCommand(personelAdSoyadQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@PersonelID", selectedPersonelID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ad = reader.GetString(0);
                            soyad = reader.GetString(1);
                        }
                    }
                }

                if (MessageBox.Show($"{ad} {soyad} adlı personeli silmek istediğinize emin misiniz?",
                    "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string deleteCalisma = "DELETE FROM CalismaSaatleri WHERE PersonelID = @PersonelID";
                    string deleteIzin = "DELETE FROM Izinler WHERE PersonelID = @PersonelID";
                    string deletePersonel = "DELETE FROM Personel WHERE PersonelID = @PersonelID";

                    using (var cmd = new SQLiteCommand(deleteCalisma, conn))
                    {
                        cmd.Parameters.AddWithValue("@PersonelID", selectedPersonelID);
                        cmd.ExecuteNonQuery();
                    }
                    using (var cmd = new SQLiteCommand(deleteIzin, conn))
                    {
                        cmd.Parameters.AddWithValue("@PersonelID", selectedPersonelID);
                        cmd.ExecuteNonQuery();
                    }
                    using (var cmd = new SQLiteCommand(deletePersonel, conn))
                    {
                        cmd.Parameters.AddWithValue("@PersonelID", selectedPersonelID);
                        cmd.ExecuteNonQuery();
                    }

                    VerileriYukle();
                    Temizle();
                    MessageBox.Show($"{ad} {soyad} silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
            MessageBox.Show("Form temizlendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtDepartman.Clear();
            txtPozisyon.Clear();
            txtTelefon.Clear();
            txtEposta.Clear();
            txtMaas.Clear();
            dtpIseBaslama.Value = DateTime.Now;
            pbPersonelFoto.Image = null;
            selectedPersonelID = 0;

            txtSaatNotlar.Clear();
            chkSaatOnay.Checked = false;
            cmbSaatDurum.SelectedIndex = -1;
            selectedCalismaID = 0;

            txtIzinAciklama.Clear();
            chkIzinOnay.Checked = false;
            cmbIzinDurum.SelectedIndex = -1;
            selectedIzinID = 0;
        }


        private void BtnSaatEkle_Click(object sender, EventArgs e)
        {
            if (cmbSaatPersonelSec.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir personel seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int personelID = (int)cmbSaatPersonelSec.SelectedValue;
            DateTime girisSaati = dtpSaatTarih.Value.Date + dtpGirisSaati.Value.TimeOfDay;
            DateTime cikisSaati = dtpSaatTarih.Value.Date + dtpCikisSaati.Value.TimeOfDay;

            if (cikisSaati <= girisSaati)
            {
                MessageBox.Show("Çıkış saati, giriş saatinden sonra olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double fazlaMesai = (cikisSaati - girisSaati).TotalHours - 8;
            string ad = "";
            string soyad = "";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string insertQuery = @"
                    INSERT INTO CalismaSaatleri (PersonelID, Tarih, GirisSaati, CikisSaati, FazlaMesai, Notlar, OnaylandiMi, Durum)
                    VALUES (@PersonelID, @Tarih, @GirisSaati, @CikisSaati, @FazlaMesai, @Notlar, @OnaylandiMi, @Durum)";
                using (var cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@PersonelID", personelID);
                    cmd.Parameters.AddWithValue("@Tarih", dtpSaatTarih.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@GirisSaati", girisSaati.ToString("yyyy-MM-dd HH:mm"));
                    cmd.Parameters.AddWithValue("@CikisSaati", cikisSaati.ToString("yyyy-MM-dd HH:mm"));
                    cmd.Parameters.AddWithValue("@FazlaMesai", fazlaMesai > 0 ? fazlaMesai : 0);
                    cmd.Parameters.AddWithValue("@Notlar", txtSaatNotlar.Text);
                    cmd.Parameters.AddWithValue("@OnaylandiMi", chkSaatOnay.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@Durum", cmbSaatDurum.SelectedItem?.ToString() ?? "Beklemede");
                    cmd.ExecuteNonQuery();

                    if (chkSaatOnay.Checked)
                    {
                        string updatePersonel = "UPDATE Personel SET ToplamFazlaMesai = ToplamFazlaMesai + @FazlaMesai WHERE PersonelID = @PersonelID";
                        using (var updateCmd = new SQLiteCommand(updatePersonel, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@FazlaMesai", fazlaMesai);
                            updateCmd.Parameters.AddWithValue("@PersonelID", personelID);
                            updateCmd.ExecuteNonQuery();
                        }
                    }

                    string adSoyadQuery = "SELECT Ad, Soyad FROM Personel WHERE PersonelID = @PersonelID";
                    using (var adCmd = new SQLiteCommand(adSoyadQuery, conn))
                    {
                        adCmd.Parameters.AddWithValue("@PersonelID", personelID);
                        using (var reader = adCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ad = reader.GetString(0);
                                soyad = reader.GetString(1);
                            }
                        }
                    }

                    VerileriYukle();
                    Temizle();
                    MessageBox.Show($"{ad} {soyad} için {dtpSaatTarih.Value:dd.MM.yyyy} tarihli çalışma saati eklendi.",
                        "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnSaatGuncelle_Click(object sender, EventArgs e)
        {
            if (selectedCalismaID == 0)
            {
                MessageBox.Show("Lütfen güncellenecek bir çalışma saati seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime girisSaati = dtpSaatTarih.Value.Date + dtpGirisSaati.Value.TimeOfDay;
            DateTime cikisSaati = dtpSaatTarih.Value.Date + dtpCikisSaati.Value.TimeOfDay;

            if (cikisSaati <= girisSaati)
            {
                MessageBox.Show("Çıkış saati, giriş saatinden sonra olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ad = "";
            string soyad = "";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();


                string selectQuery = "SELECT PersonelID, FazlaMesai, OnaylandiMi FROM CalismaSaatleri WHERE CalismaID = @CalismaID";
                int personelID = 0;
                double eskiFazlaMesai = 0;
                bool eskiOnay = false;
                using (var cmd = new SQLiteCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CalismaID", selectedCalismaID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            personelID = reader.GetInt32(0);
                            eskiFazlaMesai = reader.GetDouble(1);
                            eskiOnay = reader.GetInt32(2) == 1;
                        }
                    }
                }

                double yeniFazlaMesai = (cikisSaati - girisSaati).TotalHours - 8;


                string updateQuery = @"
                    UPDATE CalismaSaatleri 
                    SET Tarih = @Tarih, GirisSaati = @GirisSaati, CikisSaati = @CikisSaati, FazlaMesai = @FazlaMesai, 
                        Notlar = @Notlar, OnaylandiMi = @OnaylandiMi, Durum = @Durum
                    WHERE CalismaID = @CalismaID";
                using (var cmd = new SQLiteCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CalismaID", selectedCalismaID);
                    cmd.Parameters.AddWithValue("@Tarih", dtpSaatTarih.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@GirisSaati", girisSaati.ToString("yyyy-MM-dd HH:mm"));
                    cmd.Parameters.AddWithValue("@CikisSaati", cikisSaati.ToString("yyyy-MM-dd HH:mm"));
                    cmd.Parameters.AddWithValue("@FazlaMesai", yeniFazlaMesai > 0 ? yeniFazlaMesai : 0);
                    cmd.Parameters.AddWithValue("@Notlar", txtSaatNotlar.Text);
                    cmd.Parameters.AddWithValue("@OnaylandiMi", chkSaatOnay.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@Durum", cmbSaatDurum.SelectedItem?.ToString() ?? "Beklemede");
                    cmd.ExecuteNonQuery();
                }


                if (eskiOnay || chkSaatOnay.Checked)
                {
                    string updatePersonel = "UPDATE Personel SET ToplamFazlaMesai = ToplamFazlaMesai - @EskiFazlaMesai + @YeniFazlaMesai WHERE PersonelID = @PersonelID";
                    using (var cmd = new SQLiteCommand(updatePersonel, conn))
                    {
                        cmd.Parameters.AddWithValue("@EskiFazlaMesai", eskiOnay ? eskiFazlaMesai : 0);
                        cmd.Parameters.AddWithValue("@YeniFazlaMesai", chkSaatOnay.Checked && yeniFazlaMesai > 0 ? yeniFazlaMesai : 0);
                        cmd.Parameters.AddWithValue("@PersonelID", personelID);
                        cmd.ExecuteNonQuery();
                    }
                }

                string adSoyadQuery = "SELECT Ad, Soyad FROM Personel WHERE PersonelID = @PersonelID";
                using (var cmd = new SQLiteCommand(adSoyadQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@PersonelID", personelID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ad = reader.GetString(0);
                            soyad = reader.GetString(1);
                        }
                    }
                }

                VerileriYukle();
                Temizle();
                MessageBox.Show($"{ad} {soyad} için {dtpSaatTarih.Value:dd.MM.yyyy} tarihli çalışma saati güncellendi.",
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void BtnSaatSil_Click(object sender, EventArgs e)
        {
            if (selectedCalismaID == 0)
            {
                MessageBox.Show("Lütfen silinecek bir çalışma saati seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ad = "";
            string soyad = "";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();


                string selectQuery = "SELECT PersonelID, Tarih, FazlaMesai, OnaylandiMi FROM CalismaSaatleri WHERE CalismaID = @CalismaID";
                int personelID = 0;
                string tarih = "";
                double fazlaMesai = 0;
                bool onaylandiMi = false;
                using (var cmd = new SQLiteCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CalismaID", selectedCalismaID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            personelID = reader.GetInt32(0);
                            tarih = reader.GetString(1);
                            fazlaMesai = reader.GetDouble(2);
                            onaylandiMi = reader.GetInt32(3) == 1;
                        }
                    }
                }

                string adSoyadQuery = "SELECT Ad, Soyad FROM Personel WHERE PersonelID = @PersonelID";
                using (var cmd = new SQLiteCommand(adSoyadQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@PersonelID", personelID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ad = reader.GetString(0);
                            soyad = reader.GetString(1);
                        }
                    }
                }

                if (MessageBox.Show($"{ad} {soyad} için {DateTime.Parse(tarih):dd.MM.yyyy} tarihli çalışma saatini silmek istediğinize emin misiniz?",
                    "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string deleteQuery = "DELETE FROM CalismaSaatleri WHERE CalismaID = @CalismaID";
                    using (var cmd = new SQLiteCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@CalismaID", selectedCalismaID);
                        cmd.ExecuteNonQuery();
                    }

                    if (onaylandiMi)
                    {
                        string updatePersonel = "UPDATE Personel SET ToplamFazlaMesai = ToplamFazlaMesai - @FazlaMesai WHERE PersonelID = @PersonelID";
                        using (var cmd = new SQLiteCommand(updatePersonel, conn))
                        {
                            cmd.Parameters.AddWithValue("@FazlaMesai", fazlaMesai);
                            cmd.Parameters.AddWithValue("@PersonelID", personelID);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    VerileriYukle();
                    Temizle();
                    MessageBox.Show("Çalışma saati silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void BtnIzinEkle_Click(object sender, EventArgs e)
        {
            if (cmbIzinPersonelSec.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir personel seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int personelID = (int)cmbIzinPersonelSec.SelectedValue;
            double gunSayisi = (dtpIzinBitis.Value - dtpIzinBaslangic.Value).TotalDays;

            if (gunSayisi <= 0)
            {
                MessageBox.Show("İzin bitiş tarihi, başlangıç tarihinden sonra olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ad = "";
            string soyad = "";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();


                int toplamIzinGun = 0;
                using (var cmd = new SQLiteCommand("SELECT ToplamIzinGun FROM Personel WHERE PersonelID = @PersonelID", conn))
                {
                    cmd.Parameters.AddWithValue("@PersonelID", personelID);
                    toplamIzinGun = Convert.ToInt32(cmd.ExecuteScalar());
                }

                if (chkIzinOnay.Checked && toplamIzinGun < gunSayisi)
                {
                    string adSoyadQuery = "SELECT Ad, Soyad FROM Personel WHERE PersonelID = @PersonelID";
                    using (var cmd = new SQLiteCommand(adSoyadQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@PersonelID", personelID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ad = reader.GetString(0);
                                soyad = reader.GetString(1);
                            }
                        }
                    }
                    MessageBox.Show($"{ad} {soyad} için yeterli izin günü yok. Kalan: {toplamIzinGun} gün.",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string insertQuery = @"
                    INSERT INTO Izinler (PersonelID, Baslangic, Bitis, IzinTuru, GunSayisi, Aciklama, OnaylandiMi, TalepTarihi, Durum)
                    VALUES (@PersonelID, @Baslangic, @Bitis, @IzinTuru, @GunSayisi, @Aciklama, @OnaylandiMi, @TalepTarihi, @Durum)";
                using (var cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@PersonelID", personelID);
                    cmd.Parameters.AddWithValue("@Baslangic", dtpIzinBaslangic.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Bitis", dtpIzinBitis.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@IzinTuru", cmbIzinTuru.SelectedItem?.ToString() ?? "Belirtilmemiş");
                    cmd.Parameters.AddWithValue("@GunSayisi", gunSayisi);
                    cmd.Parameters.AddWithValue("@Aciklama", txtIzinAciklama.Text);
                    cmd.Parameters.AddWithValue("@OnaylandiMi", chkIzinOnay.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@TalepTarihi", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                    cmd.Parameters.AddWithValue("@Durum", cmbIzinDurum.SelectedItem?.ToString() ?? "Beklemede");
                    cmd.ExecuteNonQuery();

                    if (chkIzinOnay.Checked)
                    {
                        string updatePersonel = "UPDATE Personel SET ToplamIzinGun = ToplamIzinGun - @GunSayisi WHERE PersonelID = @PersonelID";
                        using (var updateCmd = new SQLiteCommand(updatePersonel, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@GunSayisi", gunSayisi);
                            updateCmd.Parameters.AddWithValue("@PersonelID", personelID);
                            updateCmd.ExecuteNonQuery();
                        }
                    }

                    string adSoyadQuery = "SELECT Ad, Soyad FROM Personel WHERE PersonelID = @PersonelID";
                    using (var adCmd = new SQLiteCommand(adSoyadQuery, conn))
                    {
                        adCmd.Parameters.AddWithValue("@PersonelID", personelID);
                        using (var reader = adCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ad = reader.GetString(0);
                                soyad = reader.GetString(1);
                            }
                        }
                    }

                    VerileriYukle();
                    Temizle();
                    MessageBox.Show($"{ad} {soyad} için izin eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnIzinGuncelle_Click(object sender, EventArgs e)
        {
            if (selectedIzinID == 0)
            {
                MessageBox.Show("Lütfen güncellenecek bir izin kaydı seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double yeniGunSayisi = (dtpIzinBitis.Value - dtpIzinBaslangic.Value).TotalDays;

            if (yeniGunSayisi <= 0)
            {
                MessageBox.Show("İzin bitiş tarihi, başlangıç tarihinden sonra olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ad = "";
            string soyad = "";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();


                string selectQuery = "SELECT PersonelID, GunSayisi, OnaylandiMi FROM Izinler WHERE IzinID = @IzinID";
                int personelID = 0;
                double eskiGunSayisi = 0;
                bool eskiOnay = false;
                using (var cmd = new SQLiteCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@IzinID", selectedIzinID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            personelID = reader.GetInt32(0);
                            eskiGunSayisi = reader.GetDouble(1);
                            eskiOnay = reader.GetInt32(2) == 1;
                        }
                    }
                }

                int toplamIzinGun = 0;
                using (var cmd = new SQLiteCommand("SELECT ToplamIzinGun FROM Personel WHERE PersonelID = @PersonelID", conn))
                {
                    cmd.Parameters.AddWithValue("@PersonelID", personelID);
                    toplamIzinGun = Convert.ToInt32(cmd.ExecuteScalar());
                }

                if (chkIzinOnay.Checked && toplamIzinGun + (eskiOnay ? (int)eskiGunSayisi : 0) < yeniGunSayisi)
                {
                    string adSoyadQuery = "SELECT Ad, Soyad FROM Personel WHERE PersonelID = @PersonelID";
                    using (var cmd = new SQLiteCommand(adSoyadQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@PersonelID", personelID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ad = reader.GetString(0);
                                soyad = reader.GetString(1);
                            }
                        }
                    }
                    MessageBox.Show($"{ad} {soyad} için yeterli izin günü yok. Kalan: {toplamIzinGun + (eskiOnay ? (int)eskiGunSayisi : 0)} gün.",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string updateQuery = @"
                    UPDATE Izinler 
                    SET Baslangic = @Baslangic, Bitis = @Bitis, IzinTuru = @IzinTuru, GunSayisi = @GunSayisi, 
                        Aciklama = @Aciklama, OnaylandiMi = @OnaylandiMi, Durum = @Durum
                    WHERE IzinID = @IzinID";
                using (var cmd = new SQLiteCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@IzinID", selectedIzinID);
                    cmd.Parameters.AddWithValue("@Baslangic", dtpIzinBaslangic.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Bitis", dtpIzinBitis.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@IzinTuru", cmbIzinTuru.SelectedItem?.ToString() ?? "Belirtilmemiş");
                    cmd.Parameters.AddWithValue("@GunSayisi", yeniGunSayisi);
                    cmd.Parameters.AddWithValue("@Aciklama", txtIzinAciklama.Text);
                    cmd.Parameters.AddWithValue("@OnaylandiMi", chkIzinOnay.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@Durum", cmbIzinDurum.SelectedItem?.ToString() ?? "Beklemede");
                    cmd.ExecuteNonQuery();
                }


                if (eskiOnay || chkIzinOnay.Checked)
                {
                    string updatePersonel = "UPDATE Personel SET ToplamIzinGun = ToplamIzinGun + @EskiGunSayisi - @YeniGunSayisi WHERE PersonelID = @PersonelID";
                    using (var cmd = new SQLiteCommand(updatePersonel, conn))
                    {
                        cmd.Parameters.AddWithValue("@EskiGunSayisi", eskiOnay ? (int)eskiGunSayisi : 0);
                        cmd.Parameters.AddWithValue("@YeniGunSayisi", chkIzinOnay.Checked ? (int)yeniGunSayisi : 0);
                        cmd.Parameters.AddWithValue("@PersonelID", personelID);
                        cmd.ExecuteNonQuery();
                    }
                }

                string adSoyadQueryFinal = "SELECT Ad, Soyad FROM Personel WHERE PersonelID = @PersonelID";
                using (var cmd = new SQLiteCommand(adSoyadQueryFinal, conn))
                {
                    cmd.Parameters.AddWithValue("@PersonelID", personelID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ad = reader.GetString(0);
                            soyad = reader.GetString(1);
                        }
                    }
                }

                VerileriYukle();
                Temizle();
                MessageBox.Show($"{ad} {soyad} için izin güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void BtnIzinSil_Click(object sender, EventArgs e)
        {
            if (selectedIzinID == 0)
            {
                MessageBox.Show("Lütfen silinecek bir izin kaydı seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ad = "";
            string soyad = "";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();


                string selectQuery = "SELECT PersonelID, Baslangic, Bitis, GunSayisi, OnaylandiMi FROM Izinler WHERE IzinID = @IzinID";
                int personelID = 0;
                string baslangic = "", bitis = "";
                double gunSayisi = 0;
                bool onaylandiMi = false;
                using (var cmd = new SQLiteCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@IzinID", selectedIzinID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            personelID = reader.GetInt32(0);
                            baslangic = reader.GetString(1);
                            bitis = reader.GetString(2);
                            gunSayisi = reader.GetDouble(3);
                            onaylandiMi = reader.GetInt32(4) == 1;
                        }
                    }
                }

                string adSoyadQuery = "SELECT Ad, Soyad FROM Personel WHERE PersonelID = @PersonelID";
                using (var cmd = new SQLiteCommand(adSoyadQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@PersonelID", personelID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ad = reader.GetString(0);
                            soyad = reader.GetString(1);
                        }
                    }
                }

                if (MessageBox.Show($"{ad} {soyad} için {DateTime.Parse(baslangic):dd.MM.yyyy} - {DateTime.Parse(bitis):dd.MM.yyyy} tarihli izni silmek istediğinize emin misiniz?",
                    "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string deleteQuery = "DELETE FROM Izinler WHERE IzinID = @IzinID";
                    using (var cmd = new SQLiteCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IzinID", selectedIzinID);
                        cmd.ExecuteNonQuery();
                    }

                    if (onaylandiMi)
                    {
                        string updatePersonel = "UPDATE Personel SET ToplamIzinGun = ToplamIzinGun + @GunSayisi WHERE PersonelID = @PersonelID";
                        using (var cmd = new SQLiteCommand(updatePersonel, conn))
                        {
                            cmd.Parameters.AddWithValue("@GunSayisi", (int)gunSayisi);
                            cmd.Parameters.AddWithValue("@PersonelID", personelID);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    VerileriYukle();
                    Temizle();
                    MessageBox.Show("İzin silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void BtnRaporOlustur_Click(object sender, EventArgs e)
        {
            string rapor = "Personel Takip Sistemi Raporu\n\n";
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();


                using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Personel", conn))
                {
                    rapor += $"Toplam Personel: {cmd.ExecuteScalar()}\n";
                }
                using (var cmd = new SQLiteCommand("SELECT SUM(FazlaMesai) FROM CalismaSaatleri WHERE OnaylandiMi = 1", conn))
                {
                    rapor += $"Toplam Onaylı Fazla Mesai: {(cmd.ExecuteScalar() != DBNull.Value ? Convert.ToDouble(cmd.ExecuteScalar()) : 0):F2} saat\n";
                }
                using (var cmd = new SQLiteCommand("SELECT SUM(GunSayisi) FROM Izinler WHERE OnaylandiMi = 1", conn))
                {
                    rapor += $"Toplam Onaylı İzin Günleri: {(cmd.ExecuteScalar() != DBNull.Value ? Convert.ToDouble(cmd.ExecuteScalar()) : 0)} gün\n\n";
                }

                rapor += "Personel Bazında Detaylar:\n";
                using (var cmd = new SQLiteCommand("SELECT * FROM Personel", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int personelID = reader.GetInt32(0);
                        string ad = reader.GetString(1);
                        string soyad = reader.GetString(2);
                        string departman = reader.IsDBNull(3) ? "" : reader.GetString(3);
                        double toplamFazlaMesai = reader.GetDouble(11);
                        int toplamIzinGun = reader.GetInt32(10);

                        rapor += $"ID: {personelID}, Ad: {ad} {soyad}, Departman: {departman}, " +
                                 $"Fazla Mesai: {toplamFazlaMesai:F2} saat, Kalan İzin: {toplamIzinGun} gün\n";


                        rapor += "Çalışma Saatleri:\n";
                        using (var calismaCmd = new SQLiteCommand("SELECT * FROM CalismaSaatleri WHERE PersonelID = @PersonelID", conn))
                        {
                            calismaCmd.Parameters.AddWithValue("@PersonelID", personelID);
                            using (var calismaReader = calismaCmd.ExecuteReader())
                            {
                                while (calismaReader.Read())
                                {
                                    rapor += $"- {DateTime.Parse(calismaReader.GetString(2)):dd.MM.yyyy}: " +
                                             $"{DateTime.Parse(calismaReader.GetString(3)):HH:mm} - {DateTime.Parse(calismaReader.GetString(4)):HH:mm}, " +
                                             $"Fazla Mesai: {calismaReader.GetDouble(5):F2} saat, Onay: {calismaReader.GetInt32(7) == 1}, " +
                                             $"Durum: {calismaReader.GetString(8)}, Not: {(calismaReader.IsDBNull(6) ? "" : calismaReader.GetString(6))}\n";
                                }
                            }
                        }


                        rapor += "İzinler:\n";
                        using (var izinCmd = new SQLiteCommand("SELECT * FROM Izinler WHERE PersonelID = @PersonelID", conn))
                        {
                            izinCmd.Parameters.AddWithValue("@PersonelID", personelID);
                            using (var izinReader = izinCmd.ExecuteReader())
                            {
                                while (izinReader.Read())
                                {
                                    rapor += $"- {DateTime.Parse(izinReader.GetString(2)):dd.MM.yyyy} - {DateTime.Parse(izinReader.GetString(3)):dd.MM.yyyy}: " +
                                             $"{izinReader.GetString(4)}, {izinReader.GetDouble(5)} gün, Onay: {izinReader.GetInt32(7) == 1}, " +
                                             $"Durum: {izinReader.GetString(9)}, Açıklama: {(izinReader.IsDBNull(6) ? "" : izinReader.GetString(6))}, " +
                                             $"Talep: {DateTime.Parse(izinReader.GetString(8)):dd.MM.yyyy HH:mm}\n";
                                }
                            }
                        }
                        rapor += "\n";
                    }
                }
            }

            MessageBox.Show(rapor, "Rapor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void TxtArama_TextChanged(object sender, EventArgs e)
        {
            if (txtArama.Text == "Personel Ara..." || string.IsNullOrWhiteSpace(txtArama.Text))
            {
                VerileriYukle();
                return;
            }

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var filteredList = new List<Personel>();
                using (var cmd = new SQLiteCommand("SELECT * FROM Personel WHERE Ad LIKE @Ara OR Soyad LIKE @Ara", conn))
                {
                    cmd.Parameters.AddWithValue("@Ara", "%" + txtArama.Text.ToLower() + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            filteredList.Add(new Personel
                            {
                                PersonelID = reader.GetInt32(0),
                                Ad = reader.GetString(1),
                                Soyad = reader.GetString(2),
                                Departman = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Pozisyon = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Telefon = reader.IsDBNull(5) ? null : reader.GetString(5),
                                Eposta = reader.IsDBNull(6) ? null : reader.GetString(6),
                                Maas = reader.IsDBNull(7) ? 0 : reader.GetDecimal(7),
                                IseBaslamaTarihi = DateTime.Parse(reader.GetString(8)),
                                Foto = reader.IsDBNull(9) ? null : (byte[])reader["Foto"],
                                ToplamIzinGun = reader.GetInt32(10),
                                ToplamFazlaMesai = reader.GetDouble(11)
                            });
                        }
                    }
                }
                dgvPersonel.DataSource = filteredList;
            }
        }


        private void BtnFiltrele_Click(object sender, EventArgs e)
        {
            string seciliDepartman = cmbDepartmanFiltre.SelectedItem?.ToString();
            if (seciliDepartman == "Tümü" || string.IsNullOrEmpty(seciliDepartman))
            {
                VerileriYukle();
            }
            else
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    var filteredList = new List<Personel>();
                    using (var cmd = new SQLiteCommand("SELECT * FROM Personel WHERE Departman = @Departman", conn))
                    {
                        cmd.Parameters.AddWithValue("@Departman", seciliDepartman);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                filteredList.Add(new Personel
                                {
                                    PersonelID = reader.GetInt32(0),
                                    Ad = reader.GetString(1),
                                    Soyad = reader.GetString(2),
                                    Departman = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    Pozisyon = reader.IsDBNull(4) ? null : reader.GetString(4),
                                    Telefon = reader.IsDBNull(5) ? null : reader.GetString(5),
                                    Eposta = reader.IsDBNull(6) ? null : reader.GetString(6),
                                    Maas = reader.IsDBNull(7) ? 0 : reader.GetDecimal(7),
                                    IseBaslamaTarihi = DateTime.Parse(reader.GetString(8)),
                                    Foto = reader.IsDBNull(9) ? null : (byte[])reader["Foto"],
                                    ToplamIzinGun = reader.GetInt32(10),
                                    ToplamFazlaMesai = reader.GetDouble(11)
                                });
                            }
                        }
                    }
                    dgvPersonel.DataSource = filteredList;
                }
            }
        }


        private void DgvPersonel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedPersonelID = Convert.ToInt32(dgvPersonel.Rows[e.RowIndex].Cells["PersonelID"].Value);
                var personel = (dgvPersonel.DataSource as List<Personel>)?.Find(p => p.PersonelID == selectedPersonelID);
                if (personel != null)
                {
                    txtAd.Text = personel.Ad;
                    txtSoyad.Text = personel.Soyad;
                    txtDepartman.Text = personel.Departman;
                    txtPozisyon.Text = personel.Pozisyon;
                    txtTelefon.Text = personel.Telefon;
                    txtEposta.Text = personel.Eposta;
                    txtMaas.Text = personel.Maas.ToString();
                    dtpIseBaslama.Value = personel.IseBaslamaTarihi;
                    pbPersonelFoto.Image = personel.Foto != null ? ByteArrayToImage(personel.Foto) : null;

                    lblSeciliPersonel.Text = $"Seçili Personel: {personel.Ad} {personel.Soyad}";
                }
            }
        }


        private void DgvCalismaSaatleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedCalismaID = Convert.ToInt32(dgvCalismaSaatleri.Rows[e.RowIndex].Cells["CalismaID"].Value);
                var saat = (dgvCalismaSaatleri.DataSource as List<CalismaSaati>)?.Find(c => c.CalismaID == selectedCalismaID);
                if (saat != null)
                {
                    var personel = (dgvPersonel.DataSource as List<Personel>)?.Find(p => p.PersonelID == saat.PersonelID);
                    cmbSaatPersonelSec.SelectedValue = saat.PersonelID;
                    dtpSaatTarih.Value = saat.Tarih;
                    dtpGirisSaati.Value = saat.GirisSaati;
                    dtpCikisSaati.Value = saat.CikisSaati;
                    txtSaatNotlar.Text = saat.Notlar;
                    chkSaatOnay.Checked = saat.OnaylandiMi;
                    cmbSaatDurum.SelectedItem = saat.Durum;

                    lblSeciliPersonel.Text = $"Seçili Personel: {personel?.Ad} {personel?.Soyad}";
                }
            }
        }


        private void DgvIzinler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedIzinID = Convert.ToInt32(dgvIzinler.Rows[e.RowIndex].Cells["IzinID"].Value);
                var izin = (dgvIzinler.DataSource as List<Izin>)?.Find(i => i.IzinID == selectedIzinID);
                if (izin != null)
                {
                    var personel = (dgvPersonel.DataSource as List<Personel>)?.Find(p => p.PersonelID == izin.PersonelID);
                    cmbIzinPersonelSec.SelectedValue = izin.PersonelID;
                    dtpIzinBaslangic.Value = izin.Baslangic;
                    dtpIzinBitis.Value = izin.Bitis;
                    cmbIzinTuru.SelectedItem = izin.IzinTuru;
                    txtIzinAciklama.Text = izin.Aciklama;
                    chkIzinOnay.Checked = izin.OnaylandiMi;
                    cmbIzinDurum.SelectedItem = izin.Durum;

                    lblSeciliPersonel.Text = $"Seçili Personel: {personel?.Ad} {personel?.Soyad}";
                }
            }
        }


        private void GuncelleIstatistikler()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Personel", conn))
                {
                    lblToplamPersonel.Text = $"Toplam Personel: {cmd.ExecuteScalar()}";
                }
                using (var cmd = new SQLiteCommand("SELECT SUM(FazlaMesai) FROM CalismaSaatleri WHERE OnaylandiMi = 1", conn))
                {
                    lblToplamFazlaMesai.Text = $"Toplam Onaylı Fazla Mesai: {(cmd.ExecuteScalar() != DBNull.Value ? Convert.ToDouble(cmd.ExecuteScalar()) : 0):F2} saat";
                }
                using (var cmd = new SQLiteCommand("SELECT SUM(GunSayisi) FROM Izinler WHERE OnaylandiMi = 1", conn))
                {
                    lblToplamIzin.Text = $"Toplam Onaylı İzin: {(cmd.ExecuteScalar() != DBNull.Value ? Convert.ToDouble(cmd.ExecuteScalar()) : 0)} gün";
                }
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void ComboBoxlariDoldur()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var personelListesi = new List<Personel>();
                using (var cmd = new SQLiteCommand("SELECT * FROM Personel", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        personelListesi.Add(new Personel
                        {
                            PersonelID = reader.GetInt32(0),
                            Ad = reader.GetString(1),
                            Soyad = reader.GetString(2),
                            Departman = reader.IsDBNull(3) ? null : reader.GetString(3),
                            Pozisyon = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Telefon = reader.IsDBNull(5) ? null : reader.GetString(5),
                            Eposta = reader.IsDBNull(6) ? null : reader.GetString(6),
                            Maas = reader.IsDBNull(7) ? 0 : reader.GetDecimal(7),
                            IseBaslamaTarihi = DateTime.Parse(reader.GetString(8)),
                            Foto = reader.IsDBNull(9) ? null : (byte[])reader["Foto"],
                            ToplamIzinGun = reader.GetInt32(10),
                            ToplamFazlaMesai = reader.GetDouble(11)
                        });
                    }
                }
                cmbSaatPersonelSec.DataSource = personelListesi;
                cmbSaatPersonelSec.DisplayMember = "Ad";
                cmbSaatPersonelSec.ValueMember = "PersonelID";
                cmbIzinPersonelSec.DataSource = personelListesi.ToList(); 
                cmbIzinPersonelSec.DisplayMember = "Ad";
                cmbIzinPersonelSec.ValueMember = "PersonelID";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}