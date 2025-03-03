using System.Drawing;
using System.Windows.Forms;
using System;

namespace PersonelTakipSistemiDetayli
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPersonel = new System.Windows.Forms.TabPage();
            this.dgvPersonel = new System.Windows.Forms.DataGridView();
            this.pbPersonelFoto = new System.Windows.Forms.PictureBox();
            this.btnFotoSec = new System.Windows.Forms.Button();
            this.lblAd = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.lblDepartman = new System.Windows.Forms.Label();
            this.txtDepartman = new System.Windows.Forms.TextBox();
            this.lblPozisyon = new System.Windows.Forms.Label();
            this.txtPozisyon = new System.Windows.Forms.TextBox();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.lblEposta = new System.Windows.Forms.Label();
            this.txtEposta = new System.Windows.Forms.TextBox();
            this.lblMaas = new System.Windows.Forms.Label();
            this.txtMaas = new System.Windows.Forms.TextBox();
            this.lblIseBaslama = new System.Windows.Forms.Label();
            this.dtpIseBaslama = new System.Windows.Forms.DateTimePicker();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.cmbDepartmanFiltre = new System.Windows.Forms.ComboBox();
            this.btnFiltrele = new System.Windows.Forms.Button();
            this.lblSeciliPersonel = new System.Windows.Forms.Label();
            this.tabCalisma = new System.Windows.Forms.TabPage();
            this.dgvCalismaSaatleri = new System.Windows.Forms.DataGridView();
            this.lblSaatPersonel = new System.Windows.Forms.Label();
            this.cmbSaatPersonelSec = new System.Windows.Forms.ComboBox();
            this.lblSaatTarih = new System.Windows.Forms.Label();
            this.dtpSaatTarih = new System.Windows.Forms.DateTimePicker();
            this.lblGirisSaati = new System.Windows.Forms.Label();
            this.dtpGirisSaati = new System.Windows.Forms.DateTimePicker();
            this.lblCikisSaati = new System.Windows.Forms.Label();
            this.dtpCikisSaati = new System.Windows.Forms.DateTimePicker();
            this.lblSaatNotlar = new System.Windows.Forms.Label();
            this.txtSaatNotlar = new System.Windows.Forms.TextBox();
            this.chkSaatOnay = new System.Windows.Forms.CheckBox();
            this.lblSaatDurum = new System.Windows.Forms.Label();
            this.cmbSaatDurum = new System.Windows.Forms.ComboBox();
            this.btnSaatEkle = new System.Windows.Forms.Button();
            this.btnSaatGuncelle = new System.Windows.Forms.Button();
            this.btnSaatSil = new System.Windows.Forms.Button();
            this.tabIzin = new System.Windows.Forms.TabPage();
            this.dgvIzinler = new System.Windows.Forms.DataGridView();
            this.lblIzinPersonel = new System.Windows.Forms.Label();
            this.cmbIzinPersonelSec = new System.Windows.Forms.ComboBox();
            this.dtpIzinBaslangic = new System.Windows.Forms.DateTimePicker();
            this.dtpIzinBitis = new System.Windows.Forms.DateTimePicker();
            this.lblIzinTuru = new System.Windows.Forms.Label();
            this.cmbIzinTuru = new System.Windows.Forms.ComboBox();
            this.lblIzinAciklama = new System.Windows.Forms.Label();
            this.txtIzinAciklama = new System.Windows.Forms.TextBox();
            this.chkIzinOnay = new System.Windows.Forms.CheckBox();
            this.lblIzinDurum = new System.Windows.Forms.Label();
            this.cmbIzinDurum = new System.Windows.Forms.ComboBox();
            this.btnIzinEkle = new System.Windows.Forms.Button();
            this.btnIzinGuncelle = new System.Windows.Forms.Button();
            this.btnIzinSil = new System.Windows.Forms.Button();
            this.tabIstatistik = new System.Windows.Forms.TabPage();
            this.lblToplamPersonel = new System.Windows.Forms.Label();
            this.lblToplamFazlaMesai = new System.Windows.Forms.Label();
            this.lblToplamIzin = new System.Windows.Forms.Label();
            this.btnRaporOlustur = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPersonel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonelFoto)).BeginInit();
            this.tabCalisma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalismaSaatleri)).BeginInit();
            this.tabIzin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzinler)).BeginInit();
            this.tabIstatistik.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPersonel);
            this.tabControl.Controls.Add(this.tabCalisma);
            this.tabControl.Controls.Add(this.tabIzin);
            this.tabControl.Controls.Add(this.tabIstatistik);
            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1048, 650);
            this.tabControl.TabIndex = 0;
            // 
            // tabPersonel
            // 
            this.tabPersonel.Controls.Add(this.dgvPersonel);
            this.tabPersonel.Controls.Add(this.pbPersonelFoto);
            this.tabPersonel.Controls.Add(this.btnFotoSec);
            this.tabPersonel.Controls.Add(this.lblAd);
            this.tabPersonel.Controls.Add(this.txtAd);
            this.tabPersonel.Controls.Add(this.lblSoyad);
            this.tabPersonel.Controls.Add(this.txtSoyad);
            this.tabPersonel.Controls.Add(this.lblDepartman);
            this.tabPersonel.Controls.Add(this.txtDepartman);
            this.tabPersonel.Controls.Add(this.lblPozisyon);
            this.tabPersonel.Controls.Add(this.txtPozisyon);
            this.tabPersonel.Controls.Add(this.lblTelefon);
            this.tabPersonel.Controls.Add(this.txtTelefon);
            this.tabPersonel.Controls.Add(this.lblEposta);
            this.tabPersonel.Controls.Add(this.txtEposta);
            this.tabPersonel.Controls.Add(this.lblMaas);
            this.tabPersonel.Controls.Add(this.txtMaas);
            this.tabPersonel.Controls.Add(this.lblIseBaslama);
            this.tabPersonel.Controls.Add(this.dtpIseBaslama);
            this.tabPersonel.Controls.Add(this.btnEkle);
            this.tabPersonel.Controls.Add(this.btnGuncelle);
            this.tabPersonel.Controls.Add(this.btnSil);
            this.tabPersonel.Controls.Add(this.btnTemizle);
            this.tabPersonel.Controls.Add(this.txtArama);
            this.tabPersonel.Controls.Add(this.cmbDepartmanFiltre);
            this.tabPersonel.Controls.Add(this.btnFiltrele);
            this.tabPersonel.Controls.Add(this.lblSeciliPersonel);
            this.tabPersonel.Location = new System.Drawing.Point(4, 22);
            this.tabPersonel.Name = "tabPersonel";
            this.tabPersonel.Size = new System.Drawing.Size(1040, 624);
            this.tabPersonel.TabIndex = 0;
            this.tabPersonel.Text = "Personel Yönetimi";
            // 
            // dgvPersonel
            // 
            this.dgvPersonel.Location = new System.Drawing.Point(10, 50);
            this.dgvPersonel.Name = "dgvPersonel";
            this.dgvPersonel.ReadOnly = true;
            this.dgvPersonel.Size = new System.Drawing.Size(700, 550);
            this.dgvPersonel.TabIndex = 0;
            this.dgvPersonel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPersonel_CellClick);
            // 
            // pbPersonelFoto
            // 
            this.pbPersonelFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPersonelFoto.Location = new System.Drawing.Point(720, 50);
            this.pbPersonelFoto.Name = "pbPersonelFoto";
            this.pbPersonelFoto.Size = new System.Drawing.Size(150, 150);
            this.pbPersonelFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPersonelFoto.TabIndex = 1;
            this.pbPersonelFoto.TabStop = false;
            // 
            // btnFotoSec
            // 
            this.btnFotoSec.Location = new System.Drawing.Point(720, 210);
            this.btnFotoSec.Name = "btnFotoSec";
            this.btnFotoSec.Size = new System.Drawing.Size(150, 30);
            this.btnFotoSec.TabIndex = 2;
            this.btnFotoSec.Text = "Fotoğraf Seç";
            this.btnFotoSec.Click += new System.EventHandler(this.BtnFotoSec_Click);
            // 
            // lblAd
            // 
            this.lblAd.Location = new System.Drawing.Point(720, 250);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(50, 20);
            this.lblAd.TabIndex = 3;
            this.lblAd.Text = "Ad:";
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(780, 250);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(150, 20);
            this.txtAd.TabIndex = 4;
            // 
            // lblSoyad
            // 
            this.lblSoyad.Location = new System.Drawing.Point(720, 280);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(50, 20);
            this.lblSoyad.TabIndex = 5;
            this.lblSoyad.Text = "Soyad:";
            // 
            // txtSoyad
            // 
            this.txtSoyad.Location = new System.Drawing.Point(780, 280);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(150, 20);
            this.txtSoyad.TabIndex = 6;
            // 
            // lblDepartman
            // 
            this.lblDepartman.Location = new System.Drawing.Point(720, 310);
            this.lblDepartman.Name = "lblDepartman";
            this.lblDepartman.Size = new System.Drawing.Size(50, 20);
            this.lblDepartman.TabIndex = 7;
            this.lblDepartman.Text = "Departman:";
            // 
            // txtDepartman
            // 
            this.txtDepartman.Location = new System.Drawing.Point(780, 310);
            this.txtDepartman.Name = "txtDepartman";
            this.txtDepartman.Size = new System.Drawing.Size(150, 20);
            this.txtDepartman.TabIndex = 8;
            // 
            // lblPozisyon
            // 
            this.lblPozisyon.Location = new System.Drawing.Point(720, 340);
            this.lblPozisyon.Name = "lblPozisyon";
            this.lblPozisyon.Size = new System.Drawing.Size(50, 20);
            this.lblPozisyon.TabIndex = 9;
            this.lblPozisyon.Text = "Pozisyon:";
            // 
            // txtPozisyon
            // 
            this.txtPozisyon.Location = new System.Drawing.Point(780, 340);
            this.txtPozisyon.Name = "txtPozisyon";
            this.txtPozisyon.Size = new System.Drawing.Size(150, 20);
            this.txtPozisyon.TabIndex = 10;
            // 
            // lblTelefon
            // 
            this.lblTelefon.Location = new System.Drawing.Point(720, 370);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(50, 20);
            this.lblTelefon.TabIndex = 11;
            this.lblTelefon.Text = "Telefon:";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(780, 370);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(150, 20);
            this.txtTelefon.TabIndex = 12;
            // 
            // lblEposta
            // 
            this.lblEposta.Location = new System.Drawing.Point(720, 400);
            this.lblEposta.Name = "lblEposta";
            this.lblEposta.Size = new System.Drawing.Size(50, 20);
            this.lblEposta.TabIndex = 13;
            this.lblEposta.Text = "E-posta:";
            // 
            // txtEposta
            // 
            this.txtEposta.Location = new System.Drawing.Point(780, 400);
            this.txtEposta.Name = "txtEposta";
            this.txtEposta.Size = new System.Drawing.Size(150, 20);
            this.txtEposta.TabIndex = 14;
            // 
            // lblMaas
            // 
            this.lblMaas.Location = new System.Drawing.Point(720, 430);
            this.lblMaas.Name = "lblMaas";
            this.lblMaas.Size = new System.Drawing.Size(50, 20);
            this.lblMaas.TabIndex = 15;
            this.lblMaas.Text = "Maaş:";
            // 
            // txtMaas
            // 
            this.txtMaas.Location = new System.Drawing.Point(780, 430);
            this.txtMaas.Name = "txtMaas";
            this.txtMaas.Size = new System.Drawing.Size(150, 20);
            this.txtMaas.TabIndex = 16;
            // 
            // lblIseBaslama
            // 
            this.lblIseBaslama.Location = new System.Drawing.Point(720, 460);
            this.lblIseBaslama.Name = "lblIseBaslama";
            this.lblIseBaslama.Size = new System.Drawing.Size(70, 20);
            this.lblIseBaslama.TabIndex = 17;
            this.lblIseBaslama.Text = "İşe Başlama:";
            // 
            // dtpIseBaslama
            // 
            this.dtpIseBaslama.Location = new System.Drawing.Point(796, 460);
            this.dtpIseBaslama.Name = "dtpIseBaslama";
            this.dtpIseBaslama.Size = new System.Drawing.Size(150, 20);
            this.dtpIseBaslama.TabIndex = 18;
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(720, 500);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(70, 30);
            this.btnEkle.TabIndex = 19;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.Click += new System.EventHandler(this.BtnEkle_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(800, 500);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(70, 30);
            this.btnGuncelle.TabIndex = 20;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(880, 500);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(70, 30);
            this.btnSil.TabIndex = 21;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(960, 500);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(70, 30);
            this.btnTemizle.TabIndex = 22;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.Click += new System.EventHandler(this.BtnTemizle_Click);
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(10, 20);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(200, 20);
            this.txtArama.TabIndex = 23;
            this.txtArama.TextChanged += new System.EventHandler(this.TxtArama_TextChanged);
            this.txtArama.Enter += new System.EventHandler(this.TxtArama_Enter);
            this.txtArama.Leave += new System.EventHandler(this.TxtArama_Leave);
            // 
            // cmbDepartmanFiltre
            // 
            this.cmbDepartmanFiltre.Items.AddRange(new object[] {
            "Tümü"});
            this.cmbDepartmanFiltre.Location = new System.Drawing.Point(220, 20);
            this.cmbDepartmanFiltre.Name = "cmbDepartmanFiltre";
            this.cmbDepartmanFiltre.Size = new System.Drawing.Size(150, 21);
            this.cmbDepartmanFiltre.TabIndex = 24;
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.Location = new System.Drawing.Point(380, 20);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.Size = new System.Drawing.Size(70, 20);
            this.btnFiltrele.TabIndex = 25;
            this.btnFiltrele.Text = "Filtrele";
            this.btnFiltrele.Click += new System.EventHandler(this.BtnFiltrele_Click);
            // 
            // lblSeciliPersonel
            // 
            this.lblSeciliPersonel.Location = new System.Drawing.Point(720, 540);
            this.lblSeciliPersonel.Name = "lblSeciliPersonel";
            this.lblSeciliPersonel.Size = new System.Drawing.Size(200, 20);
            this.lblSeciliPersonel.TabIndex = 26;
            this.lblSeciliPersonel.Text = "Seçili Personel: Yok";
            // 
            // tabCalisma
            // 
            this.tabCalisma.Controls.Add(this.dgvCalismaSaatleri);
            this.tabCalisma.Controls.Add(this.lblSaatPersonel);
            this.tabCalisma.Controls.Add(this.cmbSaatPersonelSec);
            this.tabCalisma.Controls.Add(this.lblSaatTarih);
            this.tabCalisma.Controls.Add(this.dtpSaatTarih);
            this.tabCalisma.Controls.Add(this.lblGirisSaati);
            this.tabCalisma.Controls.Add(this.dtpGirisSaati);
            this.tabCalisma.Controls.Add(this.lblCikisSaati);
            this.tabCalisma.Controls.Add(this.dtpCikisSaati);
            this.tabCalisma.Controls.Add(this.lblSaatNotlar);
            this.tabCalisma.Controls.Add(this.txtSaatNotlar);
            this.tabCalisma.Controls.Add(this.chkSaatOnay);
            this.tabCalisma.Controls.Add(this.lblSaatDurum);
            this.tabCalisma.Controls.Add(this.cmbSaatDurum);
            this.tabCalisma.Controls.Add(this.btnSaatEkle);
            this.tabCalisma.Controls.Add(this.btnSaatGuncelle);
            this.tabCalisma.Controls.Add(this.btnSaatSil);
            this.tabCalisma.Location = new System.Drawing.Point(4, 22);
            this.tabCalisma.Name = "tabCalisma";
            this.tabCalisma.Size = new System.Drawing.Size(1040, 624);
            this.tabCalisma.TabIndex = 1;
            this.tabCalisma.Text = "Çalışma Saatleri";
            // 
            // dgvCalismaSaatleri
            // 
            this.dgvCalismaSaatleri.Location = new System.Drawing.Point(10, 50);
            this.dgvCalismaSaatleri.Name = "dgvCalismaSaatleri";
            this.dgvCalismaSaatleri.ReadOnly = true;
            this.dgvCalismaSaatleri.Size = new System.Drawing.Size(700, 550);
            this.dgvCalismaSaatleri.TabIndex = 0;
            this.dgvCalismaSaatleri.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCalismaSaatleri_CellClick);
            // 
            // lblSaatPersonel
            // 
            this.lblSaatPersonel.Location = new System.Drawing.Point(720, 50);
            this.lblSaatPersonel.Name = "lblSaatPersonel";
            this.lblSaatPersonel.Size = new System.Drawing.Size(70, 20);
            this.lblSaatPersonel.TabIndex = 1;
            this.lblSaatPersonel.Text = "Personel:";
            // 
            // cmbSaatPersonelSec
            // 
            this.cmbSaatPersonelSec.Location = new System.Drawing.Point(790, 50);
            this.cmbSaatPersonelSec.Name = "cmbSaatPersonelSec";
            this.cmbSaatPersonelSec.Size = new System.Drawing.Size(150, 21);
            this.cmbSaatPersonelSec.TabIndex = 2;
            // 
            // lblSaatTarih
            // 
            this.lblSaatTarih.Location = new System.Drawing.Point(720, 80);
            this.lblSaatTarih.Name = "lblSaatTarih";
            this.lblSaatTarih.Size = new System.Drawing.Size(70, 20);
            this.lblSaatTarih.TabIndex = 3;
            this.lblSaatTarih.Text = "Tarih:";
            // 
            // dtpSaatTarih
            // 
            this.dtpSaatTarih.Location = new System.Drawing.Point(790, 80);
            this.dtpSaatTarih.Name = "dtpSaatTarih";
            this.dtpSaatTarih.Size = new System.Drawing.Size(150, 20);
            this.dtpSaatTarih.TabIndex = 4;
            // 
            // lblGirisSaati
            // 
            this.lblGirisSaati.Location = new System.Drawing.Point(720, 110);
            this.lblGirisSaati.Name = "lblGirisSaati";
            this.lblGirisSaati.Size = new System.Drawing.Size(70, 20);
            this.lblGirisSaati.TabIndex = 5;
            this.lblGirisSaati.Text = "Giriş Saati:";
            // 
            // dtpGirisSaati
            // 
            this.dtpGirisSaati.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpGirisSaati.Location = new System.Drawing.Point(790, 110);
            this.dtpGirisSaati.Name = "dtpGirisSaati";
            this.dtpGirisSaati.ShowUpDown = true;
            this.dtpGirisSaati.Size = new System.Drawing.Size(150, 20);
            this.dtpGirisSaati.TabIndex = 6;
            // 
            // lblCikisSaati
            // 
            this.lblCikisSaati.Location = new System.Drawing.Point(720, 140);
            this.lblCikisSaati.Name = "lblCikisSaati";
            this.lblCikisSaati.Size = new System.Drawing.Size(70, 20);
            this.lblCikisSaati.TabIndex = 7;
            this.lblCikisSaati.Text = "Çıkış Saati:";
            // 
            // dtpCikisSaati
            // 
            this.dtpCikisSaati.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpCikisSaati.Location = new System.Drawing.Point(790, 140);
            this.dtpCikisSaati.Name = "dtpCikisSaati";
            this.dtpCikisSaati.ShowUpDown = true;
            this.dtpCikisSaati.Size = new System.Drawing.Size(150, 20);
            this.dtpCikisSaati.TabIndex = 8;
            // 
            // lblSaatNotlar
            // 
            this.lblSaatNotlar.Location = new System.Drawing.Point(720, 170);
            this.lblSaatNotlar.Name = "lblSaatNotlar";
            this.lblSaatNotlar.Size = new System.Drawing.Size(50, 20);
            this.lblSaatNotlar.TabIndex = 9;
            this.lblSaatNotlar.Text = "Notlar:";
            // 
            // txtSaatNotlar
            // 
            this.txtSaatNotlar.Location = new System.Drawing.Point(720, 190);
            this.txtSaatNotlar.Multiline = true;
            this.txtSaatNotlar.Name = "txtSaatNotlar";
            this.txtSaatNotlar.Size = new System.Drawing.Size(150, 60);
            this.txtSaatNotlar.TabIndex = 10;
            // 
            // chkSaatOnay
            // 
            this.chkSaatOnay.Location = new System.Drawing.Point(720, 260);
            this.chkSaatOnay.Name = "chkSaatOnay";
            this.chkSaatOnay.Size = new System.Drawing.Size(150, 20);
            this.chkSaatOnay.TabIndex = 11;
            this.chkSaatOnay.Text = "Onaylandı";
            // 
            // lblSaatDurum
            // 
            this.lblSaatDurum.Location = new System.Drawing.Point(720, 290);
            this.lblSaatDurum.Name = "lblSaatDurum";
            this.lblSaatDurum.Size = new System.Drawing.Size(50, 20);
            this.lblSaatDurum.TabIndex = 12;
            this.lblSaatDurum.Text = "Durum:";
            // 
            // cmbSaatDurum
            // 
            this.cmbSaatDurum.Items.AddRange(new object[] {
            "Tamamlandı",
            "Beklemede",
            "İptal"});
            this.cmbSaatDurum.Location = new System.Drawing.Point(720, 310);
            this.cmbSaatDurum.Name = "cmbSaatDurum";
            this.cmbSaatDurum.Size = new System.Drawing.Size(150, 21);
            this.cmbSaatDurum.TabIndex = 13;
            // 
            // btnSaatEkle
            // 
            this.btnSaatEkle.Location = new System.Drawing.Point(720, 340);
            this.btnSaatEkle.Name = "btnSaatEkle";
            this.btnSaatEkle.Size = new System.Drawing.Size(70, 30);
            this.btnSaatEkle.TabIndex = 14;
            this.btnSaatEkle.Text = "Ekle";
            this.btnSaatEkle.Click += new System.EventHandler(this.BtnSaatEkle_Click);
            // 
            // btnSaatGuncelle
            // 
            this.btnSaatGuncelle.Location = new System.Drawing.Point(800, 340);
            this.btnSaatGuncelle.Name = "btnSaatGuncelle";
            this.btnSaatGuncelle.Size = new System.Drawing.Size(70, 30);
            this.btnSaatGuncelle.TabIndex = 15;
            this.btnSaatGuncelle.Text = "Güncelle";
            this.btnSaatGuncelle.Click += new System.EventHandler(this.BtnSaatGuncelle_Click);
            // 
            // btnSaatSil
            // 
            this.btnSaatSil.Location = new System.Drawing.Point(880, 340);
            this.btnSaatSil.Name = "btnSaatSil";
            this.btnSaatSil.Size = new System.Drawing.Size(70, 30);
            this.btnSaatSil.TabIndex = 16;
            this.btnSaatSil.Text = "Sil";
            this.btnSaatSil.Click += new System.EventHandler(this.BtnSaatSil_Click);
            // 
            // tabIzin
            // 
            this.tabIzin.Controls.Add(this.dgvIzinler);
            this.tabIzin.Controls.Add(this.lblIzinPersonel);
            this.tabIzin.Controls.Add(this.cmbIzinPersonelSec);
            this.tabIzin.Controls.Add(this.dtpIzinBaslangic);
            this.tabIzin.Controls.Add(this.dtpIzinBitis);
            this.tabIzin.Controls.Add(this.lblIzinTuru);
            this.tabIzin.Controls.Add(this.cmbIzinTuru);
            this.tabIzin.Controls.Add(this.lblIzinAciklama);
            this.tabIzin.Controls.Add(this.txtIzinAciklama);
            this.tabIzin.Controls.Add(this.chkIzinOnay);
            this.tabIzin.Controls.Add(this.lblIzinDurum);
            this.tabIzin.Controls.Add(this.cmbIzinDurum);
            this.tabIzin.Controls.Add(this.btnIzinEkle);
            this.tabIzin.Controls.Add(this.btnIzinGuncelle);
            this.tabIzin.Controls.Add(this.btnIzinSil);
            this.tabIzin.Location = new System.Drawing.Point(4, 22);
            this.tabIzin.Name = "tabIzin";
            this.tabIzin.Size = new System.Drawing.Size(1040, 624);
            this.tabIzin.TabIndex = 2;
            this.tabIzin.Text = "İzin Takibi";
            // 
            // dgvIzinler
            // 
            this.dgvIzinler.Location = new System.Drawing.Point(10, 50);
            this.dgvIzinler.Name = "dgvIzinler";
            this.dgvIzinler.ReadOnly = true;
            this.dgvIzinler.Size = new System.Drawing.Size(735, 550);
            this.dgvIzinler.TabIndex = 0;
            this.dgvIzinler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvIzinler_CellClick);
            // 
            // lblIzinPersonel
            // 
            this.lblIzinPersonel.Location = new System.Drawing.Point(776, 50);
            this.lblIzinPersonel.Name = "lblIzinPersonel";
            this.lblIzinPersonel.Size = new System.Drawing.Size(57, 20);
            this.lblIzinPersonel.TabIndex = 1;
            this.lblIzinPersonel.Text = "Personel:";
            // 
            // cmbIzinPersonelSec
            // 
            this.cmbIzinPersonelSec.Location = new System.Drawing.Point(839, 47);
            this.cmbIzinPersonelSec.Name = "cmbIzinPersonelSec";
            this.cmbIzinPersonelSec.Size = new System.Drawing.Size(134, 21);
            this.cmbIzinPersonelSec.TabIndex = 2;
            // 
            // dtpIzinBaslangic
            // 
            this.dtpIzinBaslangic.Location = new System.Drawing.Point(776, 77);
            this.dtpIzinBaslangic.Name = "dtpIzinBaslangic";
            this.dtpIzinBaslangic.Size = new System.Drawing.Size(197, 20);
            this.dtpIzinBaslangic.TabIndex = 3;
            // 
            // dtpIzinBitis
            // 
            this.dtpIzinBitis.Location = new System.Drawing.Point(776, 107);
            this.dtpIzinBitis.Name = "dtpIzinBitis";
            this.dtpIzinBitis.Size = new System.Drawing.Size(197, 20);
            this.dtpIzinBitis.TabIndex = 4;
            // 
            // lblIzinTuru
            // 
            this.lblIzinTuru.Location = new System.Drawing.Point(776, 137);
            this.lblIzinTuru.Name = "lblIzinTuru";
            this.lblIzinTuru.Size = new System.Drawing.Size(50, 20);
            this.lblIzinTuru.TabIndex = 5;
            this.lblIzinTuru.Text = "İzin Türü:";
            // 
            // cmbIzinTuru
            // 
            this.cmbIzinTuru.Items.AddRange(new object[] {
            "Yıllık",
            "Hastalık",
            "Ücretsiz",
            "Doğum",
            "Evlilik"});
            this.cmbIzinTuru.Location = new System.Drawing.Point(776, 157);
            this.cmbIzinTuru.Name = "cmbIzinTuru";
            this.cmbIzinTuru.Size = new System.Drawing.Size(197, 21);
            this.cmbIzinTuru.TabIndex = 6;
            // 
            // lblIzinAciklama
            // 
            this.lblIzinAciklama.Location = new System.Drawing.Point(776, 187);
            this.lblIzinAciklama.Name = "lblIzinAciklama";
            this.lblIzinAciklama.Size = new System.Drawing.Size(50, 20);
            this.lblIzinAciklama.TabIndex = 7;
            this.lblIzinAciklama.Text = "Açıklama:";
            // 
            // txtIzinAciklama
            // 
            this.txtIzinAciklama.Location = new System.Drawing.Point(776, 207);
            this.txtIzinAciklama.Multiline = true;
            this.txtIzinAciklama.Name = "txtIzinAciklama";
            this.txtIzinAciklama.Size = new System.Drawing.Size(197, 60);
            this.txtIzinAciklama.TabIndex = 8;
            // 
            // chkIzinOnay
            // 
            this.chkIzinOnay.Location = new System.Drawing.Point(776, 277);
            this.chkIzinOnay.Name = "chkIzinOnay";
            this.chkIzinOnay.Size = new System.Drawing.Size(150, 20);
            this.chkIzinOnay.TabIndex = 9;
            this.chkIzinOnay.Text = "Onaylandı";
            // 
            // lblIzinDurum
            // 
            this.lblIzinDurum.Location = new System.Drawing.Point(776, 307);
            this.lblIzinDurum.Name = "lblIzinDurum";
            this.lblIzinDurum.Size = new System.Drawing.Size(50, 20);
            this.lblIzinDurum.TabIndex = 10;
            this.lblIzinDurum.Text = "Durum:";
            // 
            // cmbIzinDurum
            // 
            this.cmbIzinDurum.Items.AddRange(new object[] {
            "Onaylandı",
            "Beklemede",
            "Reddedildi"});
            this.cmbIzinDurum.Location = new System.Drawing.Point(776, 327);
            this.cmbIzinDurum.Name = "cmbIzinDurum";
            this.cmbIzinDurum.Size = new System.Drawing.Size(197, 21);
            this.cmbIzinDurum.TabIndex = 11;
            // 
            // btnIzinEkle
            // 
            this.btnIzinEkle.Location = new System.Drawing.Point(772, 354);
            this.btnIzinEkle.Name = "btnIzinEkle";
            this.btnIzinEkle.Size = new System.Drawing.Size(64, 30);
            this.btnIzinEkle.TabIndex = 12;
            this.btnIzinEkle.Text = "Ekle";
            this.btnIzinEkle.Click += new System.EventHandler(this.BtnIzinEkle_Click);
            // 
            // btnIzinGuncelle
            // 
            this.btnIzinGuncelle.Location = new System.Drawing.Point(839, 354);
            this.btnIzinGuncelle.Name = "btnIzinGuncelle";
            this.btnIzinGuncelle.Size = new System.Drawing.Size(64, 30);
            this.btnIzinGuncelle.TabIndex = 13;
            this.btnIzinGuncelle.Text = "Güncelle";
            this.btnIzinGuncelle.Click += new System.EventHandler(this.BtnIzinGuncelle_Click);
            // 
            // btnIzinSil
            // 
            this.btnIzinSil.Location = new System.Drawing.Point(909, 357);
            this.btnIzinSil.Name = "btnIzinSil";
            this.btnIzinSil.Size = new System.Drawing.Size(64, 30);
            this.btnIzinSil.TabIndex = 14;
            this.btnIzinSil.Text = "Sil";
            this.btnIzinSil.Click += new System.EventHandler(this.BtnIzinSil_Click);
            // 
            // tabIstatistik
            // 
            this.tabIstatistik.Controls.Add(this.lblToplamPersonel);
            this.tabIstatistik.Controls.Add(this.lblToplamFazlaMesai);
            this.tabIstatistik.Controls.Add(this.lblToplamIzin);
            this.tabIstatistik.Controls.Add(this.btnRaporOlustur);
            this.tabIstatistik.Location = new System.Drawing.Point(4, 22);
            this.tabIstatistik.Name = "tabIstatistik";
            this.tabIstatistik.Size = new System.Drawing.Size(1040, 624);
            this.tabIstatistik.TabIndex = 3;
            this.tabIstatistik.Text = "İstatistikler";
            // 
            // lblToplamPersonel
            // 
            this.lblToplamPersonel.Location = new System.Drawing.Point(10, 50);
            this.lblToplamPersonel.Name = "lblToplamPersonel";
            this.lblToplamPersonel.Size = new System.Drawing.Size(200, 20);
            this.lblToplamPersonel.TabIndex = 0;
            this.lblToplamPersonel.Text = "Toplam Personel: 0";
            // 
            // lblToplamFazlaMesai
            // 
            this.lblToplamFazlaMesai.Location = new System.Drawing.Point(10, 80);
            this.lblToplamFazlaMesai.Name = "lblToplamFazlaMesai";
            this.lblToplamFazlaMesai.Size = new System.Drawing.Size(200, 20);
            this.lblToplamFazlaMesai.TabIndex = 1;
            this.lblToplamFazlaMesai.Text = "Toplam Fazla Mesai: 0 saat";
            // 
            // lblToplamIzin
            // 
            this.lblToplamIzin.Location = new System.Drawing.Point(10, 110);
            this.lblToplamIzin.Name = "lblToplamIzin";
            this.lblToplamIzin.Size = new System.Drawing.Size(200, 20);
            this.lblToplamIzin.TabIndex = 2;
            this.lblToplamIzin.Text = "Toplam İzin: 0 gün";
            // 
            // btnRaporOlustur
            // 
            this.btnRaporOlustur.Location = new System.Drawing.Point(10, 140);
            this.btnRaporOlustur.Name = "btnRaporOlustur";
            this.btnRaporOlustur.Size = new System.Drawing.Size(150, 30);
            this.btnRaporOlustur.TabIndex = 3;
            this.btnRaporOlustur.Text = "Rapor Oluştur";
            this.btnRaporOlustur.Click += new System.EventHandler(this.BtnRaporOlustur_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1070, 700);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kage Personel Takip Sistemi v2.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPersonel.ResumeLayout(false);
            this.tabPersonel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonelFoto)).EndInit();
            this.tabCalisma.ResumeLayout(false);
            this.tabCalisma.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalismaSaatleri)).EndInit();
            this.tabIzin.ResumeLayout(false);
            this.tabIzin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzinler)).EndInit();
            this.tabIstatistik.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private TabControl tabControl;
        private TabPage tabPersonel;
        private TabPage tabCalisma;
        private TabPage tabIzin;
        private TabPage tabIstatistik;
        private DataGridView dgvPersonel;
        private PictureBox pbPersonelFoto;
        private Button btnFotoSec;
        private Label lblAd;
        private TextBox txtAd;
        private Label lblSoyad;
        private TextBox txtSoyad;
        private Label lblDepartman;
        private TextBox txtDepartman;
        private Label lblPozisyon;
        private TextBox txtPozisyon;
        private Label lblTelefon;
        private TextBox txtTelefon;
        private Label lblEposta;
        private TextBox txtEposta;
        private Label lblMaas;
        private TextBox txtMaas;
        private Label lblIseBaslama;
        private DateTimePicker dtpIseBaslama;
        private Button btnEkle;
        private Button btnGuncelle;
        private Button btnSil;
        private Button btnTemizle;
        private TextBox txtArama;
        private ComboBox cmbDepartmanFiltre;
        private Button btnFiltrele;
        private Label lblSeciliPersonel;
        private DataGridView dgvCalismaSaatleri;
        private Label lblSaatPersonel;
        private ComboBox cmbSaatPersonelSec;
        private Label lblSaatTarih;
        private DateTimePicker dtpSaatTarih;
        private Label lblGirisSaati;
        private DateTimePicker dtpGirisSaati;
        private Label lblCikisSaati;
        private DateTimePicker dtpCikisSaati;
        private Label lblSaatNotlar;
        private TextBox txtSaatNotlar;
        private CheckBox chkSaatOnay;
        private Label lblSaatDurum;
        private ComboBox cmbSaatDurum;
        private Button btnSaatEkle;
        private Button btnSaatGuncelle;
        private Button btnSaatSil;
        private DataGridView dgvIzinler;
        private Label lblIzinPersonel;
        private ComboBox cmbIzinPersonelSec;
        private DateTimePicker dtpIzinBaslangic;
        private DateTimePicker dtpIzinBitis;
        private Label lblIzinTuru;
        private ComboBox cmbIzinTuru;
        private Label lblIzinAciklama;
        private TextBox txtIzinAciklama;
        private CheckBox chkIzinOnay;
        private Label lblIzinDurum;
        private ComboBox cmbIzinDurum;
        private Button btnIzinEkle;
        private Button btnIzinGuncelle;
        private Button btnIzinSil;
        private Label lblToplamPersonel;
        private Label lblToplamFazlaMesai;
        private Label lblToplamIzin;
        private Button btnRaporOlustur;
    }
}