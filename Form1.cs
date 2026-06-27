using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BorcNot
{
    public partial class Form1 : Form
    {
        private List<BorcKayit> tumKayitlar = new List<BorcKayit>();

        // Varsayılan sabit kurlar
        private decimal dolarKuru = 46.23m;
        private decimal euroKuru = 53.48m;

        public Form1()
        {
            InitializeComponent();

            listBoxNotlar.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxNotlar.DrawItem += ListBoxNotlar_DrawItem;

            this.Load += Form1_Load;
            buttonEkle.Click += buttonEkle_Click;
            buttonOdedi.Click += buttonOdedi_Click;
            buttonSil.Click += buttonSil_Click;
            buttonKismiOdeme.Click += buttonKismiOdeme_Click;
            textBoxAra.TextChanged += textBoxAra_TextChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Veritabani.IlkKurulumYap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı başlatılamadı: " + ex.Message);
            }

            if (comboBoxTur.Items.Count > 0) comboBoxTur.SelectedIndex = 0;
            if (comboBoxDoviz.Items.Count > 0) comboBoxDoviz.SelectedIndex = 0;

            YenileVeListele();
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxIsim.Text) || numericUpDownMiktar.Value <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir isim ve miktar girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string secilenDoviz = comboBoxDoviz.SelectedItem?.ToString() ?? "TL";
            decimal gecerliKur = 1.0m;

            if (secilenDoviz == "USD") gecerliKur = dolarKuru;
            else if (secilenDoviz == "EUR") gecerliKur = euroKuru;

            BorcKayit yeniKayit = new BorcKayit
            {
                Isim = textBoxIsim.Text.Trim(),
                ToplamMiktar = numericUpDownMiktar.Value,
                KalanMiktar = numericUpDownMiktar.Value,
                Tur = comboBoxTur.SelectedItem?.ToString() ?? "Borcum Var",
                DovizTuru = secilenDoviz,
                DovizKuru = gecerliKur,
                VadeTarihi = dateTimePickerVade.Value,
                Aciklama = textBoxAciklama.Text.Trim(),
                OdediMi = false
            };

            Veritabani.KayitEkle(yeniKayit);
            YenileVeListele();
            FormuTemizle();
        }

        private void buttonKismiOdeme_Click(object sender, EventArgs e)
        {
            if (listBoxNotlar.SelectedItem == null)
            {
                MessageBox.Show("Lütfen kısmi ödeme yapmak için listeden bir kayıt seçin.", "Uyarı");
                return;
            }

            BorcKayit secili = (BorcKayit)listBoxNotlar.SelectedItem;
            decimal odenen = numericUpDownKismiMiktar.Value;

            if (odenen <= 0 || odenen > secili.KalanMiktar)
            {
                MessageBox.Show($"Lütfen 0'dan büyük ve kalan borçtan ({secili.KalanMiktar:N2}) küçük bir miktar girin!", "Hata");
                return;
            }

            Veritabani.KismiOdemeYap(secili.Id, odenen);
            MessageBox.Show($"{odenen:N2} tutarındaki ödeme kayda geçildi.", "Başarılı");

            numericUpDownKismiMiktar.Value = 0;
            YenileVeListele();
        }

        private void buttonOdedi_Click(object sender, EventArgs e)
        {
            if (listBoxNotlar.SelectedItem == null)
            {
                MessageBox.Show("Lütfen kapatmak için bir kayıt seçin.", "Uyarı");
                return;
            }

            BorcKayit secili = (BorcKayit)listBoxNotlar.SelectedItem;
            Veritabani.KismiOdemeYap(secili.Id, secili.KalanMiktar);
            YenileVeListele();
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            if (listBoxNotlar.SelectedItem == null)
            {
                MessageBox.Show("Lütfen tamamen silmek istediğiniz kaydı seçin.", "Uyarı");
                return;
            }

            DialogResult cevap = MessageBox.Show("Bu kaydı veritabanından kalıcı olarak silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                BorcKayit secili = (BorcKayit)listBoxNotlar.SelectedItem;
                Veritabani.KayitSil(secili.Id);
                YenileVeListele();
            }
        }

        private void textBoxAra_TextChanged(object sender, EventArgs e)
        {
            ListeleFiltrele();
        }

        private void YenileVeListele()
        {
            tumKayitlar = Veritabani.TumKayitlariGetir();
            ListeleFiltrele();
        }

        private void ListeleFiltrele()
        {
            listBoxNotlar.Items.Clear();
            string aramaMetni = textBoxAra.Text.ToLower().Trim();

            var filtrelenmis = tumKayitlar
                .Where(k => k.Isim.ToLower().Contains(aramaMetni) || k.Aciklama.ToLower().Contains(aramaMetni))
                .ToList();

            foreach (var kayit in filtrelenmis)
            {
                listBoxNotlar.Items.Add(kayit);
            }

            decimal toplamBorcTL = 0;
            decimal toplamAlacakTL = 0;

            foreach (var k in tumKayitlar.Where(x => !x.OdediMi))
            {
                decimal tlKarsiligi = k.KalanMiktar * k.DovizKuru;

                if (k.Tur != null && k.Tur.StartsWith("Bor", StringComparison.OrdinalIgnoreCase))
                {
                    toplamBorcTL += tlKarsiligi;
                }
                else if (k.Tur != null && k.Tur.StartsWith("Ala", StringComparison.OrdinalIgnoreCase))
                {
                    toplamAlacakTL += tlKarsiligi;
                }
            }

            labelBorcToplam.Text = $"Toplam Borç : {toplamBorcTL:N2} TL";
            labelAlacakToplam.Text = $"Toplam Alacak : {toplamAlacakTL:N2} TL";
        }

        private void ListBoxNotlar_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            BorcKayit kayit = (BorcKayit)listBoxNotlar.Items[e.Index];
            Color yaziRengi = Color.Black;

            if (kayit.OdediMi) yaziRengi = Color.Gray;
            else if (kayit.Tur != null && kayit.Tur.StartsWith("Bor", StringComparison.OrdinalIgnoreCase)) yaziRengi = Color.DarkRed;
            else if (kayit.Tur != null && kayit.Tur.StartsWith("Ala", StringComparison.OrdinalIgnoreCase)) yaziRengi = Color.DarkGreen;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);
            }

            using (Brush brush = new SolidBrush(yaziRengi))
            {
                Font yaziFontu = e.Font;
                if (kayit.OdediMi) yaziFontu = new Font(e.Font, FontStyle.Strikeout);

                e.Graphics.DrawString(kayit.ToString(), yaziFontu, brush, e.Bounds);
            }
            e.DrawFocusRectangle();
        }

        private void FormuTemizle()
        {
            textBoxIsim.Clear();
            numericUpDownMiktar.Value = 0;
            textBoxAciklama.Clear();
            dateTimePickerVade.Value = DateTime.Now;
            if (comboBoxTur.Items.Count > 0) comboBoxTur.SelectedIndex = 0;
            if (comboBoxDoviz.Items.Count > 0) comboBoxDoviz.SelectedIndex = 0;
            textBoxIsim.Focus();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void buttonWhatsApp_Click(object sender, EventArgs e)
        {
            if (listBoxNotlar.SelectedItem == null)
            {
                MessageBox.Show("Lütfen mesaj göndermek için listeden bir kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string telefon = textBoxTelefon.Text.Trim();
            if (string.IsNullOrEmpty(telefon) || telefon.Length < 10)
            {
                MessageBox.Show("Lütfen geçerli bir telefon numarası girin (Örn: 5551234567).", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Listeden seçili kişiyi alalım
            BorcKayit secili = (BorcKayit)listBoxNotlar.SelectedItem;

            // 1. Telefon Numarasını Formatlama (Boşlukları, parantezleri temizleme)
            telefon = telefon.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "");
            if (telefon.StartsWith("0")) telefon = telefon.Substring(1); // Başında 0 varsa sil
            if (!telefon.StartsWith("90")) telefon = "90" + telefon; // Başına Türkiye alan kodu (90) ekle

            // 2. Mesaj Şablonunu Hazırlama
            string islemTuru = secili.Tur.StartsWith("Bor", StringComparison.OrdinalIgnoreCase) ? "borç" : "alacak";
            string mesaj = $"Merhaba {secili.Isim}. Güncel finansal durum bilgilendirmesidir:\n\n" +
                           $"Kalan {islemTuru} miktarı: {secili.KalanMiktar:N2} {secili.DovizTuru}\n" +
                           $"Vade Tarihi: {secili.VadeTarihi:dd.MM.yyyy}\n\n" +
                           $"İyi günler dileriz.";

            // 3. Mesajı İnternet Linkine (URL) Dönüştürme
            string urlFormatliMesaj = Uri.EscapeDataString(mesaj);
            string whatsappUrl = $"https://wa.me/{telefon}?text={urlFormatliMesaj}";

            // 4. WhatsApp'ı Açma Emri
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = whatsappUrl,
                    UseShellExecute = true // Sistemin varsayılan tarayıcısını tetikler
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("WhatsApp bağlantısı açılırken bir hata oluştu: " + ex.Message);
            }
        }
    }
}