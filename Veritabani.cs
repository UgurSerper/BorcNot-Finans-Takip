using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace BorcNot
{
    public static class Veritabani
    {
        private static string dbYolu = "borcnot.db";
        private static string baglantiCumlesi = $"Data Source={dbYolu};Version=3;";

        public static void IlkKurulumYap()
        {
            if (!File.Exists(dbYolu))
            {
                SQLiteConnection.CreateFile(dbYolu);
            }

            using (var baglanti = new SQLiteConnection(baglantiCumlesi))
            {
                baglanti.Open();

                string borclarTablosu = @"
                    CREATE TABLE IF NOT EXISTS Borclar (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Isim TEXT NOT NULL,
                        ToplamMiktar REAL NOT NULL,
                        KalanMiktar REAL NOT NULL,
                        Tur TEXT NOT NULL,
                        DovizTuru TEXT NOT NULL,
                        DovizKuru REAL NOT NULL,
                        VadeTarihi TEXT NOT NULL,
                        Aciklama TEXT,
                        OdediMi INTEGER DEFAULT 0
                    );";

                string odemeGecmisiTablosu = @"
                    CREATE TABLE IF NOT EXISTS OdemeGecmisi (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        BorcId INTEGER NOT NULL,
                        OdenenMiktar REAL NOT NULL,
                        OdemeTarihi TEXT NOT NULL,
                        FOREIGN KEY(BorcId) REFERENCES Borclar(Id) ON DELETE CASCADE
                    );";

                using (var komut = new SQLiteCommand(borclarTablosu, baglanti)) { komut.ExecuteNonQuery(); }
                using (var komut = new SQLiteCommand(odemeGecmisiTablosu, baglanti)) { komut.ExecuteNonQuery(); }
            }
        }

        public static void KayitEkle(BorcKayit kayit)
        {
            using (var baglanti = new SQLiteConnection(baglantiCumlesi))
            {
                baglanti.Open();
                string sorgu = @"INSERT INTO Borclar (Isim, ToplamMiktar, KalanMiktar, Tur, DovizTuru, DovizKuru, VadeTarihi, Aciklama, OdediMi) 
                                 VALUES (@isim, @toplam, @kalan, @tur, @doviz, @kur, @vade, @aciklama, @odedi)";

                using (var komut = new SQLiteCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@isim", kayit.Isim);
                    komut.Parameters.AddWithValue("@toplam", kayit.ToplamMiktar);
                    komut.Parameters.AddWithValue("@kalan", kayit.KalanMiktar);
                    komut.Parameters.AddWithValue("@tur", kayit.Tur);
                    komut.Parameters.AddWithValue("@doviz", kayit.DovizTuru);
                    komut.Parameters.AddWithValue("@kur", kayit.DovizKuru);
                    komut.Parameters.AddWithValue("@vade", kayit.VadeTarihi.ToString("yyyy-MM-dd"));
                    komut.Parameters.AddWithValue("@aciklama", kayit.Aciklama);
                    komut.Parameters.AddWithValue("@odedi", kayit.OdediMi ? 1 : 0);
                    komut.ExecuteNonQuery();
                }
            }
        }

        public static List<BorcKayit> TumKayitlariGetir()
        {
            List<BorcKayit> liste = new List<BorcKayit>();
            using (var baglanti = new SQLiteConnection(baglantiCumlesi))
            {
                baglanti.Open();
                string sorgu = "SELECT * FROM Borclar";
                using (var komut = new SQLiteCommand(sorgu, baglanti))
                using (var dr = komut.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        liste.Add(new BorcKayit
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Isim = dr["Isim"].ToString(),
                            ToplamMiktar = Convert.ToDecimal(dr["ToplamMiktar"]),
                            KalanMiktar = Convert.ToDecimal(dr["KalanMiktar"]),
                            Tur = dr["Tur"].ToString(),
                            DovizTuru = dr["DovizTuru"].ToString(),
                            DovizKuru = Convert.ToDecimal(dr["DovizKuru"]),
                            VadeTarihi = Convert.ToDateTime(dr["VadeTarihi"]),
                            Aciklama = dr["Aciklama"].ToString(),
                            OdediMi = Convert.ToInt32(dr["OdediMi"]) == 1
                        });
                    }
                }
            }
            return liste;
        }

        public static void KayitSil(int id)
        {
            using (var baglanti = new SQLiteConnection(baglantiCumlesi))
            {
                baglanti.Open();
                using (var komut = new SQLiteCommand("DELETE FROM Borclar WHERE Id = @id", baglanti))
                {
                    komut.Parameters.AddWithValue("@id", id);
                    komut.ExecuteNonQuery();
                }
            }
        }

        public static void KismiOdemeYap(int borcId, decimal miktar)
        {
            using (var baglanti = new SQLiteConnection(baglantiCumlesi))
            {
                baglanti.Open();

                string logSorgu = "INSERT INTO OdemeGecmisi (BorcId, OdenenMiktar, OdemeTarihi) VALUES (@borcId, @miktar, @tarih)";
                using (var komut = new SQLiteCommand(logSorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@borcId", borcId);
                    komut.Parameters.AddWithValue("@miktar", miktar);
                    komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    komut.ExecuteNonQuery();
                }

                string guncelleSorgu = @"UPDATE Borclar 
                                         SET KalanMiktar = KalanMiktar - @miktar
                                         WHERE Id = @borcId";
                using (var komut = new SQLiteCommand(guncelleSorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@miktar", miktar);
                    komut.Parameters.AddWithValue("@borcId", borcId);
                    komut.ExecuteNonQuery();
                }

                // Borç tamamen bitti mi kontrol edip bayrağı güncelle
                string kontrolSorgu = "UPDATE Borclar SET OdediMi = 1 WHERE Id = @borcId AND KalanMiktar <= 0";
                using (var komut = new SQLiteCommand(kontrolSorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@borcId", borcId);
                    komut.ExecuteNonQuery();
                }
            }
        }
    }
}