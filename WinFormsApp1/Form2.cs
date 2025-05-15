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
        bool metinbelgesiüstüneyazmak = false;
        string Ydosyayolu;

        public Form2()
        {

            InitializeComponent();
            button3.Visible = false;
            label6.Visible = false;
            textBox3.Visible = false;
            label8.Visible = false;

           


        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void button2_Click_1(object sender, EventArgs e) // onayla butonu , tıklayınca kelımeyı girecegin yeri aktif ediyor(metin belgesi seçili değilse)
        {
            if (türkcekelimeler.Count == 0)
            {
                MessageBox.Show("Lütfen kelimeleri girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (metinbelgesiüstüneyazmak) // metin belgesinin üstüne yazma butonu aktif ise
            {
                //File.AppendText dosyanın üzerine yazmak için var
                using (StreamWriter sw = File.AppendText(Ydosyayolu))//metin belgesinin üstüne yazma işlemi
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
            else //metin belgesinin üstüne yazma butonu aktif değilse
            {
            button2.Visible = false;
            button3.Visible = true;
            label6.Visible = true;
            textBox3.Visible = true;

            }
           
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


                // Giriş yapılan kelimeleri diziye eklemeden önce dizide var mı kontrol et
                if(!ingkelimeler.Contains(textBox1.Text.Trim().ToLower()))
                { //dizide yoksa ekle
                ingkelimeler.Add(textBox1.Text.Trim().ToLower());
                türkcekelimeler.Add(textBox2.Text.Trim().ToLower());
                sayac++;
                }
                else {
                MessageBox.Show("Bu kelime daha önce girilmiş, tekrar dene.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);;
                    return;
                }//dizide varsa uyar

                // Kelime sayısını güncelle
                label5.Text = "Eklenen kelime sayısı: " + sayac;


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
                    using (StreamWriter sw = new StreamWriter(Ydosyayolu)) //metin belgesine yazma işlemi
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



        private void button5_Click(object sender, EventArgs e) // metin belgesinin üstüne yazmak için
        {
            // Kullanıcının metin belgesi üzerine yazmak istediğini belirten bayrağı true yapıyoruz
            metinbelgesiüstüneyazmak = true;

            label8.Visible = true; // Bilgilendirici metini aktif ediyoruz 

            // Masaüstü yolunu alıyoruz
            string masaustuYolu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Kelime dosyalarının bulunduğu klasör adı
            string klasorAdi = "Kelimeler_Dosyasi";

            // Klasörün tam yolu
            string klasorYolu = Path.Combine(masaustuYolu, klasorAdi);

            // OpenFileDialog nesnesi ile dosya seçici ekranı oluşturuyoruz
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Başlangıç olarak kullanıcıya "Kelimeler_Dosyasi" klasörünü açtırıyoruz
            openFileDialog.InitialDirectory = klasorYolu;

            // Sadece .txt uzantılı dosyaları göstersin
            openFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt";

            // Pencere başlığı
            openFileDialog.Title = "Bir metin dosyası seçin";

            // Kullanıcı dosya seçerse işleme devam et
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen dosyanın tam yolunu al
                 Ydosyayolu = openFileDialog.FileName;

                // Dosyayı satır satır okumak için StreamReader kullanıyoruz
                using (StreamReader sr = new StreamReader(Ydosyayolu))
                {
                    string satır;

                    // Satır bitene kadar oku
                    while ((satır = sr.ReadLine()) != null)
                    {
                        // Her satırda İngilizce ve Türkçe kelime ':' ile ayrılmış şekilde gelir
                        string[] kelimeler = satır.Split(':');

                        // Sadece 2 parça varsa (yani doğru formatta satırsa) işlem yap
                        if (kelimeler.Length == 2)
                        {
                            // İlk parça İngilizce, ikinci parça Türkçe kelime olacak şekilde listelere ekle
                            ingkelimeler.Add(kelimeler[0].Trim());
                            türkcekelimeler.Add(kelimeler[1].Trim());
                        }
                    }
                }

                // Bilgilendirme mesajı
                MessageBox.Show("Dosya başarıyla okundu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Kullanıcı dosya seçmezse uyarı ver
                MessageBox.Show("Herhangi bir dosya seçilmedi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




    }
    }

