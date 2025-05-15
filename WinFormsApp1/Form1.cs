using System.IO;  // StreamReader ve File i�in
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        List<string> ingkelimeler;
        List<string> t�rkceleri;
        int sayac = 0;
        bool txtbool = true;

        public Form1()
        {
            InitializeComponent();
            ingkelimeler = new List<string>();
            t�rkceleri = new List<string>();

         
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string masaustuYolu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string klasorAdi = "Kelimeler_Dosyasi";

            string[]directfiles=Directory.GetDirectories(masaustuYolu,"*Kelimeler_Dosyasi*");// masa�st�nde i�inde Kelimeler adl� dosylar� bulacak

            bool f = false;

            foreach (string file in directfiles) { if (file == klasorAdi) { f = true; } }

            string klasoryolu = Path.Combine(masaustuYolu, klasorAdi);
            if (f == false) { Directory.CreateDirectory(klasoryolu); } // Kelimeler Dosyas� klas�r� yoksa olusturur

            if (txtbool)
            {
                Form2 f2 = new Form2();
                this.Hide();
                f2.ShowDialog();
            }
            else
            {
                Form3 f3 = new Form3(ingkelimeler, t�rkceleri);
                this.Hide();
                f3.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Dosya se�ici penceresini olu�turuyoruz   
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Yaln�zca .txt dosyalar�n� g�sterecek �ekilde filtreleme
            openFileDialog.Filter = "Metin Dosyas� (*.txt)|*.txt";

            // Pencereyi a��yoruz ve kullan�c� bir dosya se�ti mi diye kontrol ediyoruz
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Se�ilen dosyan�n yolunu al�yoruz
                string dosyaYolu = openFileDialog.FileName;

                try
                {
                    // Dosya var m� kontrol ediyoruz ve i�eri�ini MessageBox ile yaz�yoruz
                    if (File.Exists(dosyaYolu))
                    {
                        // using blo�u ile StreamReader'� a��p, dosya i�leminden sonra otomatik olarak kapat�lmas�n� sa�l�yoruz
                        using (StreamReader sr = new StreamReader(dosyaYolu))
                        {
                            string sat�r;
                            while ((sat�r = sr.ReadLine()) != null)
                            {

                                string[] kelimeler = sat�r.Split(':');

                                if (kelimeler.Length == 2) // E�er sat�rda ":" varsa ve 2 kelime varsa
                                {
                                    ingkelimeler.Add(kelimeler[0].Trim());  // �ngilizce kelimeyi ekle
                                    t�rkceleri.Add(kelimeler[1].Trim());  // T�rk�e kelimeyi ekle
                                    sayac++;
                                }

                            }
                        }
                        txtbool = false;
                        MessageBox.Show("Dosyay� ba�ar�l� �ekilde kaydettiniz", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Dosya bulunamad�!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Dosya okuma hatas� durumunda kullan�c�ya bilgi veriyoruz
                    MessageBox.Show("Bir hata olu�tu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //button2.Visible = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
