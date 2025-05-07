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
    using DuoVia.FuzzyStrings;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


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

            string yazılan = textBox1.Text.Trim().ToLower();
            string dogruCevap = türkceleri[randsayac[sayac]];




            //fuzzy logic (bulanık mantık) ile kontrol yapacağız ----------------------------------------------
            int puan = 0;

            if (dogruCevap.Length == yazılan.Length) { puan += 10; } //eger iki kelimenin boyutları aynı ise 10 puan ekle

            if (dogruCevap[0] == yazılan[0]) { puan += 5; }// eger iki kelimenin ilk harfleri aynı ise 5 puan ekle

            HashSet<char> harflercevap = new HashSet<char>(dogruCevap);//cevabın harf çeşit sayısını bir charliste atıyor
            HashSet<char> harfleryazılan = new HashSet<char>(yazılan);  //cevabın harf çeşit sayısını bir charliste atıyor

            if (harflercevap.Count == harfleryazılan.Count) { puan += 5; }// harf çeşit sayıları aynı ise 5 puan

            int harfcesitsayac = 0;

            foreach (char harf in harflercevap)
            {
                if (harfleryazılan.Contains(harf)) { harfcesitsayac++; }
            }
            if (harfcesitsayac == harfleryazılan.Count) { puan += 10; }// iki kelimenin harf çeşitleri aynı ise 10 puan

            int fark = dogruCevap.LevenshteinDistance(yazılan);
            //Levenshtein Distance (Levenshtein Mesafesi), iki metin (string) arasındaki farkı ölçmek için kullanılan bir algoritmadır
            // kelime - elme => fark = 1; kelime - kelime => fark = 1; 
            // ve bunu kullanmak için FuzzyStrings adında NuGet paketi yükledik

            for (int i = 0; i < (7 - fark); i++)//fark 0 ise 70, 1 ise 60 ,2 ise 50 puan ekleyecek ...
            {
                puan += 10;
            }
            //fuzzy logic (bulanık mantık) ile kontrol tamamlandı ----------------------------------------------




            if (puan >= 70) //kelime kontrol bloğu
            {
                SystemSounds.Asterisk.Play();
                label4.Text = "✅ Doğru bildin!";
                sayac++;
                textBox1.Clear();


                if (sayac < türkceleri.Count) //sorulacak kelime kaldı mı kontrol
                {
                    label1.Text = "İngilizce kelime: " + ingkelimeler[randsayac[sayac]];
                }
                else //soracak kelime kalmadıysa --> tüm kelimeleri bilindi..
                {
                    //  WindowsMediaPlayer player = new WindowsMediaPlayer();
                    // player.URL = "C:\\Users\\ahmet\\Videos\\4K Video Downloader+\\senmisin.mp3"; // MP3 dosya yolunu buraya yaz
                    //  player.controls.play();

                    label1.Text = "İngilizce kelime";
                    label4.Text = "🎉 Tüm kelimeleri bildin, tebrikler!";
                    button2.Text = "ÇIKIŞ YAP";
                    button2.ForeColor = Color.Red;
                    cıkıs = true;
                }
            }
            else // eger girilen kelime yanlış ise 
            {
                SystemSounds.Hand.Play();
                label4.Text = "❌ Yanlış! Tekrar dene.";

            }
        }


        private void Form3_FormClosing(object sender, FormClosingEventArgs e) { Application.Exit(); }
        
        private void Form3_Load(object sender, EventArgs e) { }

       


        private void textBox1_KeyDown(object sender, KeyEventArgs e) // textboxta enter'a==button
        // kontrol butonu ile aynı işleve sahiptir
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                button2.PerformClick(); // Butonun Click olayını tetikler
            }

        }
    }

}
