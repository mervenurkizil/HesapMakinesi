using System;
using Microsoft.Maui.Controls;

namespace HesapMakinesi.Views
{
    public partial class BilimselSayfasi : ContentPage
    {
        private double sayi1 = 0;
        private double sayi2 = 0;
        private string suAnkiIslem = null;
        private bool islemYapildi = false;
        private double hafiza = 0;
        private bool parantezAcik = false;

        public BilimselSayfasi()
        {
            InitializeComponent();
        }

        private void RakamButon_Clicked(object sender, EventArgs e)
        {
            Button buton = (Button)sender;
            string rakam = buton.Text;

            if (SonucEkrani.Text == "0" || islemYapildi)
            {
                SonucEkrani.Text = rakam;
                islemYapildi = false;
            }
            else
            {
                SonucEkrani.Text += rakam;
            }
        }

        private void IslemButon_Clicked(object sender, EventArgs e)
        {
            Button buton = (Button)sender;

            if (suAnkiIslem != null && !islemYapildi)
            {
                // Önceki işlemi tamamla
                HesaplaVeSonucuGoster();
            }

            try
            {
                sayi1 = double.Parse(SonucEkrani.Text);
                suAnkiIslem = buton.Text;
                IslemGecmisi.Text = $"{FormatSayi(sayi1)} {suAnkiIslem}";
                islemYapildi = true;
            }
            catch (Exception ex)
            {
                SonucEkrani.Text = "Hata";
            }
        }

        private void EsittirButon_Clicked(object sender, EventArgs e)
        {
            HesaplaVeSonucuGoster();
        }

        private void HesaplaVeSonucuGoster()
        {
            try
            {
                sayi2 = double.Parse(SonucEkrani.Text);
                double sonuc = 0;

                switch (suAnkiIslem)
                {
                    case "+":
                        sonuc = sayi1 + sayi2;
                        break;
                    case "-":
                        sonuc = sayi1 - sayi2;
                        break;
                    case "×":
                        sonuc = sayi1 * sayi2;
                        break;
                    case "÷":
                        if (sayi2 == 0)
                        {
                            SonucEkrani.Text = "Sıfıra bölünemez";
                            IslemGecmisi.Text = "";
                            islemYapildi = true;
                            suAnkiIslem = null;
                            return;
                        }
                        sonuc = sayi1 / sayi2;
                        break;
                    case "xʸ":
                        sonuc = Math.Pow(sayi1, sayi2);
                        break;
                    case "mod":
                        sonuc = sayi1 % sayi2;
                        break;
                }

                IslemGecmisi.Text = $"{FormatSayi(sayi1)} {suAnkiIslem} {FormatSayi(sayi2)} =";
                SonucEkrani.Text = FormatSayi(sonuc);
                sayi1 = sonuc;
                islemYapildi = true;
                suAnkiIslem = null;
            }
            catch (Exception ex)
            {
                SonucEkrani.Text = "Hata";
            }
        }

        private void BilimselButon_Clicked(object sender, EventArgs e)
        {
            Button buton = (Button)sender;
            string islem = buton.Text;

            try
            {
                double ekrandakiSayi = double.Parse(SonucEkrani.Text);
                double sonuc = 0;

                switch (islem)
                {
                    case "sin":
                        sonuc = Math.Sin(DerecedenRadyana(ekrandakiSayi));
                        break;
                    case "cos":
                        sonuc = Math.Cos(DerecedenRadyana(ekrandakiSayi));
                        break;
                    case "tan":
                        sonuc = Math.Tan(DerecedenRadyana(ekrandakiSayi));
                        break;
                    case "x²":
                        sonuc = Math.Pow(ekrandakiSayi, 2);
                        break;
                    case "√":
                        if (ekrandakiSayi < 0)
                        {
                            SonucEkrani.Text = "Geçersiz Giriş";
                            return;
                        }
                        sonuc = Math.Sqrt(ekrandakiSayi);
                        break;
                    case "log":
                        if (ekrandakiSayi <= 0)
                        {
                            SonucEkrani.Text = "Geçersiz Giriş";
                            return;
                        }
                        sonuc = Math.Log10(ekrandakiSayi);
                        break;
                    case "ln":
                        if (ekrandakiSayi <= 0)
                        {
                            SonucEkrani.Text = "Geçersiz Giriş";
                            return;
                        }
                        sonuc = Math.Log(ekrandakiSayi);
                        break;
                }

                IslemGecmisi.Text = $"{islem}({FormatSayi(ekrandakiSayi)}) =";
                SonucEkrani.Text = FormatSayi(sonuc);
                sayi1 = sonuc;
                islemYapildi = true;
            }
            catch (Exception ex)
            {
                SonucEkrani.Text = "Hata";
            }
        }

        private double DerecedenRadyana(double derece)
        {
            return derece * (Math.PI / 180.0);
        }

        private void SabitButon_Clicked(object sender, EventArgs e)
        {
            Button buton = (Button)sender;
            string sabit = buton.Text;

            switch (sabit)
            {
                case "π":
                    SonucEkrani.Text = FormatSayi(Math.PI);
                    break;
                case "e":
                    SonucEkrani.Text = FormatSayi(Math.E);
                    break;
            }

            islemYapildi = true;
        }

        private void TemizleButon_Clicked(object sender, EventArgs e)
        {
            SonucEkrani.Text = "0";
            IslemGecmisi.Text = "";
            sayi1 = 0;
            sayi2 = 0;
            suAnkiIslem = null;
            islemYapildi = false;
            parantezAcik = false;
        }

        private void VirguButon_Clicked(object sender, EventArgs e)
        {
            if (!SonucEkrani.Text.Contains(","))
            {
                SonucEkrani.Text += ",";
            }
        }

        private void HafizaButon_Clicked(object sender, EventArgs e)
        {
            Button buton = (Button)sender;
            string islem = buton.Text;

            try
            {
                double suAnkiDeger = double.Parse(SonucEkrani.Text);

                switch (islem)
                {
                    case "MC": // Memory Clear
                        hafiza = 0;
                        break;
                    case "MR": // Memory Recall
                        SonucEkrani.Text = FormatSayi(hafiza);
                        islemYapildi = true;
                        break;
                    case "M+": // Memory Add
                        hafiza += suAnkiDeger;
                        islemYapildi = true;
                        break;
                    case "M-": // Memory Subtract
                        hafiza -= suAnkiDeger;
                        islemYapildi = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                SonucEkrani.Text = "Hata";
            }
        }

        private void ParantezButon_Clicked(object sender, EventArgs e)
        {
           
            Button buton = (Button)sender;
            string parantez = buton.Text;

            if (parantez == "(")
            {
                parantezAcik = true;
               
            }
            else if (parantez == ")" && parantezAcik)
            {
                parantezAcik = false;
              
            }
        }

        private void IsaretDegistirButon_Clicked(object sender, EventArgs e)
        {
            try
            {
                double suAnkiDeger = double.Parse(SonucEkrani.Text);
                suAnkiDeger = -suAnkiDeger;
                SonucEkrani.Text = FormatSayi(suAnkiDeger);
            }
            catch (Exception ex)
            {
                SonucEkrani.Text = "Hata";
            }
        }

        private string FormatSayi(double sayi)
        {
            if (sayi == Math.Floor(sayi))
            {
                return sayi.ToString("0");
            }
            else
            {
                
                return sayi.ToString();
            }
        }
    }
}