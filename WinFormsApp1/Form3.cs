﻿using System;
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
using Microsoft.VisualBasic.Devices;
using NAudio.Wave;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        List<string> ingkelimeler;
        List<string> türkceleri;
        List<int> randsayac;
        Dictionary<string,string> silinecektemp= new Dictionary<string,string>();
        int sayac = 0;
        bool tıklama = true;
        bool cıkıs = false;
        string secilenMetinbelgesi;
        string masaUstuYol=Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string metinBelgesiYol;




        public Form3(List<string> ingkelimeler, List<string> türkceleri,string secilenMetinbelgesi)
        {
            InitializeComponent();
            this.secilenMetinbelgesi= secilenMetinbelgesi; 
            this.ingkelimeler = ingkelimeler;
            this.türkceleri = türkceleri;

            metinBelgesiYol = Path.Combine(masaUstuYol, "Kelimeler_Dosyasi", secilenMetinbelgesi ); //Metin belgesine ulasıyoruz
            label8.Text = secilenMetinbelgesi+" adlı metin belgesi seçildi!";


            Random rnd = new Random();
            randsayac = Enumerable.Range(0, ingkelimeler.Count).OrderBy(x => rnd.Next()).ToList();

            



        }



          private void metinbelgesineyaz() //Metin Belgesine Yaz Metodunda ilk olarak Listede olan kelımelerı kaldırıp ondan sonra yazacak
          {
            if (türkceleri.Count >= silinecektemp.Count) { //silinecekler kelimelerimizden az ise

            for (int i = 0; i < silinecektemp.Count; i++) {
                var tempeleman = silinecektemp.ElementAt(i); // ilk indisteki 2'liyi aldık

                string ingTemp = tempeleman.Key;
                string trTemp  = tempeleman.Value; //türkcesını ve ıngılızcesını attık

                    ingkelimeler.Remove(ingTemp);
                    türkceleri.Remove(trTemp);
                    //Kelimeleri listeden cıkardık (Remove String icin, remove at indis icin)


                }

                StreamWriter sw = new StreamWriter(metinBelgesiYol);

            for(int i=0; i<türkceleri.Count; i++)
            {
                sw.WriteLine(ingkelimeler[i] + ":" + türkceleri[i]);
            }
            sw.Close();
            }


            else // Eger tum kelimeler silindiye metin belgesini bosalt
            {
                StreamWriter sw = new StreamWriter(metinBelgesiYol);
                sw.Write("");
                sw.Close();
            }




        }




        private void button2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false; // yeni kelime geleceği zaman türkçesini gör butonu  kaldırılır
            if (tıklama)
            {
                // İlk tıklamada sadece İngilizce kelimeyi göster
                button2.Text = "Kontrol et";
                label1.Text = "İngilizce kelime : " + ingkelimeler[randsayac[sayac]];
                tıklama = false;
                return;
            }

            if (cıkıs)
            {
                // Çıkış yap (formu kapat)
                metinbelgesineyaz();    
                this.Close(); // veya Application.Exit();
                return;
            }



            string yazılan = textBox1.Text.Trim().ToLower();
            string dogruCevap = türkceleri[randsayac[sayac]];

            //boşluk girildiyse uyarı ver
            if (yazılan == "") { MessageBox.Show("Boşluk Girmeyiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }


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





            if (puan >= 65) //kelime kontrol bloğu
            {
                string masaustuYolu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string klasoradi = "Kelimeler_Dosyasi";
                string dosyaadi = "Sound_Effects";
                string secilecekdosya = "CorrectSound.mp3";

                string yol = Path.Combine(masaustuYolu, klasoradi, dosyaadi, secilecekdosya);

                WindowsMediaPlayer player = new WindowsMediaPlayer();
                player.settings.volume = 25;
                player.URL = yol; // MP3 dosya yolunu buraya yaz
                player.controls.play();


                label4.Text = "✅ Doğru bildin!";
                sayac++;
                textBox1.Clear();


                if (sayac < türkceleri.Count) //sorulacak kelime kaldı mı kontrol
                {
                    label1.Text = "İngilizce kelime : " + ingkelimeler[randsayac[sayac]];
                }
                else //soracak kelime kalmadıysa --> tüm kelimeleri bilindi..
                {
                    
                   
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

        private void button1_Click(object sender, EventArgs e) // Değiştir adlı buton
        {
            checkBox1.Checked = false; // yeni kelime geleceği zaman türkçesini gör butonu  kaldırılır

            // Mevcut kelimeyi sona ekle
            ingkelimeler.Add(ingkelimeler[randsayac[sayac]]);
            türkceleri.Add(türkceleri[randsayac[sayac]]);

            // Yeni kelimenin indeksini rastsal sıraya ekle
            randsayac.Add(ingkelimeler.Count - 1);

            // Sonraki soruya geç
            sayac++;

            // Eğer hala kelime kaldıysa yeni soruyu göster
            if (sayac < randsayac.Count)
            {
                label1.Text = "İngilizce kelime : " + ingkelimeler[randsayac[sayac]];
                textBox1.Clear();
                label4.Text = "";
            }
            else
            {
                label1.Text = "Kelime kalmadı.";
                button2.Enabled = false;
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label1.Text = "İngilizce kelime : " + ingkelimeler[randsayac[sayac]] + " (" + türkceleri[randsayac[sayac]] + ")";
            }
            else
            {
                label1.Text = "İngilizce kelime : " + ingkelimeler[randsayac[sayac]];
            }
        }


        //--------------------------------------------------
        private void button3_Click(object sender, EventArgs e) // Kelime Sil butonu
        {
            DialogResult cevap = MessageBox.Show("Silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);

            if (cevap == DialogResult.Yes)
            {
                // Evet'e basıldıysa burası çalışır
                // Burada kelimeleri bir listeye atarız

                silinecektemp.Add(ingkelimeler[randsayac[sayac]], türkceleri[randsayac[sayac]]);

                sayac++;

                MessageBox.Show("Silme işlemi başarılı.");

                if (sayac==türkceleri.Count())
                {
                   
                    label1.Text = "İngilizce kelime : ";
                    label4.Text = "🎉 Tüm kelimeleri bildin, tebrikler!";
                    button2.Text = "ÇIKIŞ YAP";
                    button2.ForeColor = Color.Red;
                    cıkıs = true;
                    return;
                }

                label1.Text = "İngilizce kelime : " + ingkelimeler[randsayac[sayac]]; //yeni kelimeye geçtik

                

               
            }
            else
            {
                // Hayır'a basıldıysa hiçbir şey yapma ya da istersen iptal mesajı ver
                MessageBox.Show("Silme işlemi iptal edildi.");
            }

            //----------------------------------------------
        }
    }

}