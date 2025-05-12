using System;
using System.Collections;
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
    public partial class Form2 : Form

    {
        List<string> ingkelimeler = new List<string>();
        List<string> türkcekelimeler = new List<string>();
        int sayac = 0;

        public Form2()
        {

            InitializeComponent();
            button3.Visible = false;
            label6.Visible = false;
            textBox3.Visible = false;


        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void button2_Click_1(object sender, EventArgs e) // onayla butonu , tıklayınca kelımeyı girecegin yeri aktif ediyor
        {
            if (türkcekelimeler.Count == 0)
            {
                MessageBox.Show("Lütfen kelimeleri girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            button2.Visible = false;
            button3.Visible = true;
            label6.Visible = true;
            textBox3.Visible = true;
        }



        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {
                button1.Visible = true;

                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Lütfen her iki alanı da doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (int.TryParse(textBox1.Text, out int control1) || int.TryParse(textBox2.Text, out int control2))
                {
                    MessageBox.Show("Lütfen alanlara sayı girmeyin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kelime ekleme işlemine başla


                // Giriş yapılan kelimeleri diziye ekle
                ingkelimeler.Add(textBox1.Text.Trim().ToLower());
                türkcekelimeler.Add(textBox2.Text.Trim().ToLower());
                sayac++;

                // Kelime sayısını güncelle
                label5.Text = "Kelime sayısı: " + sayac;


                // TextBox'ları temizle
                textBox1.Clear();
                textBox2.Clear();


                // Son kelime girildiyse ve tüm kelimeler tamamlandıysa uyarıyı göster


                // Enter tuşunun normal işlevini engelle (yani satır atlamayı engelle)
                e.SuppressKeyPress = true;
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    textBox1.Focus();
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {   //kelimeleri elde tutuyoruz
            var tr = ingkelimeler[ingkelimeler.Count - 1];
            var ing = türkcekelimeler[ingkelimeler.Count - 1];
            //kelimeleri çıkarıyoruz
            ingkelimeler.RemoveAt(ingkelimeler.Count - 1);
            türkcekelimeler.RemoveAt(türkcekelimeler.Count - 1);

            label5.Text = "Kelime sayısı: " + (--sayac);
            MessageBox.Show("Son girdiğiniz kelime ikilisi geri alındı! \n Geri alınan kelimeler: {{" + tr + " , " + ing + "}}", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (sayac == 0)
            {
                button1.Visible = false;
            }

        }

        private void button3_Click(object sender, EventArgs e) //Metin belgesinin kaydolacagı buton
        {
            string masaustuYolu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string klasorAdi = "Kelimeler_Dosyasi";

            string metinbelgesi = textBox3.Text + ".txt";

            string Ydosyayolu = Path.Combine(masaustuYolu, klasorAdi, metinbelgesi);//yazılacak metın belgesının yol

            string klasoryolu = Path.Combine(masaustuYolu, klasorAdi);// Kelımeler Dosyasının yolu




            string[] files = Directory.GetFiles(klasoryolu, $"*{metinbelgesi}*");



            if (files.Contains(Ydosyayolu)) // eger bu dosya yollu bır uzantı varsa pop up cıkart
            {
                MessageBox.Show("Girdiiğiniz isimli metin belgesi bulunuyor tekrar deneyin", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                using (StreamWriter sw = new StreamWriter(Ydosyayolu))
                {
                    for (int i = 0; i < türkcekelimeler.Count; i++)
                    {
                        sw.WriteLine((string)ingkelimeler[i] + ":" + (string)türkcekelimeler[i]);
                    }
                }
                Form3 f3 = new Form3(ingkelimeler, türkcekelimeler);
                this.Hide();
                f3.ShowDialog();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //ingilizcesini girdikten sonra, alttaki textboxa yazma eventi başlar
            {
                e.SuppressKeyPress = true;
                textBox2.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
            
        }
    }
}
