using System;

namespace BorcNot
{
    public class BorcKayit
    {
        public int Id { get; set; } // SQLite otomatik artan ID verecek
        public string Isim { get; set; }
        public decimal ToplamMiktar { get; set; } // İlk girilen ana para
        public decimal KalanMiktar { get; set; }  // Kısmi ödemeler düşüldükten sonra kalan
        public string Tur { get; set; }          // "Borcum Var" veya "Alacağım Var"
        public string DovizTuru { get; set; }    // "TL", "USD", "EUR", "ALTIN"
        public decimal DovizKuru { get; set; }   // İşlem anındaki veya güncel kur oranı
        public DateTime VadeTarihi { get; set; }
        public string Aciklama { get; set; }
        public bool OdediMi { get; set; }

        // ListBox'ta nasıl görüneceğini güncelledik
        public override string ToString()
        {
            string durum = OdediMi ? "[KAPANDI] " : (KalanMiktar < ToplamMiktar ? "[KISMİ ÖDEME] " : "");
            string tarihStr = VadeTarihi.ToString("dd.MMMM.yyyy");
            string paraBirimiSembol = DovizTuru == "TL" ? "₺" : (DovizTuru == "USD" ? "$" : (DovizTuru == "EUR" ? "€" : "GR"));

            return $"{durum}{Isim} -> Kalan: {KalanMiktar:N2} {paraBirimiSembol} / Toplam: {ToplamMiktar:N2} {paraBirimiSembol} ({Tur}) | Vade: {tarihStr}";
        }
    }
}