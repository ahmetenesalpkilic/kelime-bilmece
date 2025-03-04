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
    public partial class Form2 : Form

    {
        string[] ingkelimeler;
        string[] türkcekelimeler;
        int sayac = 0;

        public Form2(int kelimesayisi)
        {
            InitializeComponent();
            ingkelimeler = new string[kelimesayisi];
            türkcekelimeler = new string[kelimesayisi];
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(ingkelimeler, türkcekelimeler);
            this.Hide();
            f3.ShowDialog();

        }

            private void textBox2_KeyDown(object sender, KeyEventArgs e)
            { //int control1, control2;
               


           
            if (e.KeyCode == Keys.Enter)
            {
               
                if(string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Lütfen her iki alanı da doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                 else if(int.TryParse(textBox1.Text, out int control1) || int.TryParse(textBox2.Text, out int control2)){
                    MessageBox.Show("Lütfen alanlara sayı girmeyin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kelime ekleme işlemine başla
                if (sayac < ingkelimeler.Length)
                {
                    // Giriş yapılan kelimeleri diziye ekle
                    ingkelimeler[sayac] = textBox1.Text.Trim();
                    türkcekelimeler[sayac] = textBox2.Text.Trim();
                    sayac++;

                    // Kelime sayısını güncelle
                    label5.Text = "Kelime sayısı: " + sayac + "/" + ingkelimeler.Length;

                    // TextBox'ları temizle
                    textBox1.Clear();
                    textBox2.Clear();
                }

                // Son kelime girildiyse ve tüm kelimeler tamamlandıysa uyarıyı göster
                if (sayac == ingkelimeler.Length)
                {
                    label4.Text = "✅ Tüm kelimeleri girdiniz. Lütfen onaylayınız.";
                    button2.Visible = true;  // Button2'yi görünür yap
                }

                // Enter tuşunun normal işlevini engelle (yani satır atlamayı engelle)
                e.SuppressKeyPress = true;
            }

            
        }
    }
}
