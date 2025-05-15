using System.IO;  // StreamReader ve File için
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        List<string> ingkelimeler;
        List<string> türkceleri;
        int sayac = 0;
        bool txtbool = true;

        public Form1()
        {
            InitializeComponent();
            ingkelimeler = new List<string>();
            türkceleri = new List<string>();

         
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string masaustuYolu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string klasorAdi = "Kelimeler_Dosyasi";

            string[]directfiles=Directory.GetDirectories(masaustuYolu,"*Kelimeler_Dosyasi*");// masaüstünde içinde Kelimeler adlý dosylarý bulacak

            bool f = false;

            foreach (string file in directfiles) { if (file == klasorAdi) { f = true; } }

            string klasoryolu = Path.Combine(masaustuYolu, klasorAdi);
            if (f == false) { Directory.CreateDirectory(klasoryolu); } // Kelimeler Dosyasý klasörü yoksa olusturur

            if (txtbool)
            {
                Form2 f2 = new Form2();
                this.Hide();
                f2.ShowDialog();
            }
            else
            {
                Form3 f3 = new Form3(ingkelimeler, türkceleri);
                this.Hide();
                f3.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Dosya seçici penceresini oluþturuyoruz   
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Yalnýzca .txt dosyalarýný gösterecek þekilde filtreleme
            openFileDialog.Filter = "Metin Dosyasý (*.txt)|*.txt";

            // Pencereyi açýyoruz ve kullanýcý bir dosya seçti mi diye kontrol ediyoruz
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen dosyanýn yolunu alýyoruz
                string dosyaYolu = openFileDialog.FileName;

                try
                {
                    // Dosya var mý kontrol ediyoruz ve içeriðini MessageBox ile yazýyoruz
                    if (File.Exists(dosyaYolu))
                    {
                        // using bloðu ile StreamReader'ý açýp, dosya iþleminden sonra otomatik olarak kapatýlmasýný saðlýyoruz
                        using (StreamReader sr = new StreamReader(dosyaYolu))
                        {
                            string satýr;
                            while ((satýr = sr.ReadLine()) != null)
                            {

                                string[] kelimeler = satýr.Split(':');

                                if (kelimeler.Length == 2) // Eðer satýrda ":" varsa ve 2 kelime varsa
                                {
                                    ingkelimeler.Add(kelimeler[0].Trim());  // Ýngilizce kelimeyi ekle
                                    türkceleri.Add(kelimeler[1].Trim());  // Türkçe kelimeyi ekle
                                    sayac++;
                                }

                            }
                        }
                        txtbool = false;
                        MessageBox.Show("Dosyayý baþarýlý þekilde kaydettiniz", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Dosya bulunamadý!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Dosya okuma hatasý durumunda kullanýcýya bilgi veriyoruz
                    MessageBox.Show("Bir hata oluþtu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
