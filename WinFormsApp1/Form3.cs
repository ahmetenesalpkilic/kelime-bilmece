    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Media;
    using WMPLib;

namespace WinFormsApp1
    {
    public partial class Form3 : Form
    {
        List<string> ingkelimeler;
        List<string> türkceleri;
        List<int> randsayac;
        int sayac = 0;
        bool tıklama = true;
        bool cıkıs = false;

        public Form3(List<string> ingkelimeler, List<string> türkceleri)
        {
            InitializeComponent();

            this.ingkelimeler = ingkelimeler;
            this.türkceleri = türkceleri;

            Random rnd = new Random();
            randsayac = Enumerable.Range(0, ingkelimeler.Count).OrderBy(x => rnd.Next()).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tıklama)
            {
                // İlk tıklamada sadece İngilizce kelimeyi göster
                button2.Text = "Kontrol et";
                label1.Text = "İngilizce kelime: " + ingkelimeler[randsayac[sayac]];
                tıklama = false;
                return;
            }

            if (cıkıs)
            {
                // Çıkış yap (formu kapat)
                this.Close(); // veya Application.Exit();
                return;
            }

            string yazılan = textBox1.Text.Trim();
            string dogruCevap = türkceleri[randsayac[sayac]];

            if (yazılan.Equals(dogruCevap, StringComparison.OrdinalIgnoreCase))
            {
                SystemSounds.Asterisk.Play();
                label4.Text = "✅ Doğru bildin!";
                sayac++;
                textBox1.Clear();
                

                if (sayac < türkceleri.Count)
                {
                    label1.Text = "İngilizce kelime: " + ingkelimeler[randsayac[sayac]];
                }
                else
                {
                  //  WindowsMediaPlayer player = new WindowsMediaPlayer();
                  // player.URL = "C:\\Users\\ahmet\\Videos\\4K Video Downloader+\\senmisin.mp3"; // MP3 dosya yolunu buraya yaz
                  //  player.controls.play();

                    label4.Text = "🎉 Tüm kelimeleri bildin, tebrikler!";
                    button2.Text = "ÇIKIŞ YAP";
                    button2.ForeColor = Color.Red;
                    cıkıs = true;
                }
            }
            else
            {
                SystemSounds.Hand.Play();
                label4.Text = "❌ Yanlış! Tekrar dene.";

            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }

}
