    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace WinFormsApp1
    {
        public partial class Form3 : Form
        {
            string[] ingkelimeler;
            string[] türkceleri;
            int[] randsayac;
            int sayac = 0;
            bool tıklama = true;
            bool cıkıs = false;

            public Form3(string[] ingkelimeler, string[] türkceleri)
            {

                InitializeComponent();
                this.ingkelimeler = ingkelimeler;
                this.türkceleri = türkceleri;
                randsayac = new int[ingkelimeler.Length];
                Random rnd = new Random();

                randsayac = Enumerable.Range(0, ingkelimeler.Length).OrderBy(x => rnd.Next()).ToArray();

            }


            private void label1_Click(object sender, EventArgs e)
            {

            }

      

            private void button2_Click(object sender, EventArgs e)
            {
            if (tıklama) { //ilk tıklamada sadece ingilizce kelimeyi yazıyor ve butonu değiştiriyor
            button2.Text = "Kontrol et";
            label1.Text = "ingilizce kelime: " + ingkelimeler[randsayac[sayac]];
                tıklama = false;
                return; 
            }
            if (cıkıs)
            {
                this.Hide();
                return;
            }


            string yazılan = textBox1.Text.Trim();
            string dogruCevap = türkceleri[randsayac[sayac]];
           
           
          

            if (yazılan.Equals(dogruCevap, StringComparison.OrdinalIgnoreCase ))
                {
                    label4.Text = "✅ Doğru bildin!";
                    sayac++;
                    textBox1.Clear();

                    if (sayac < türkceleri.Length)
                    {
                        label1.Text = "İngilizce kelime: " + ingkelimeler[randsayac[sayac]];
                    }
                    else
                    {
                        label4.Text = "🎉 Tüm kelimeleri bildin, tebrikler!";
                        button2.Text = "ÇIKIŞ YAP";
                        button2.ForeColor=Color.Red;
                        cıkıs = true;

                    }
                }
                else
                {
                    label4.Text = "❌ Yanlış! Tekrar dene.";
                
            }


            }

            private void Form3_FormClosing(object sender, FormClosingEventArgs e)
            {

            }

       
        }
    }
