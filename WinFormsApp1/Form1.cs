using System.IO;  // StreamReader ve File i�in
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        List<string> ingkelimeler;
        List<string> t�rkceleri;
        int sayac = 0;
        bool txtbool = true;
        string metinbelgesi;

        public Form1()
        {
            InitializeComponent();
            ingkelimeler = new List<string>();
            t�rkceleri = new List<string>();

            // Form y�klendi�inde otomatik olarak dosyalar� indirip kaydedecek
            this.Load += async (s, e) => await DownloadMultipleFilesAsync();

            this.Load += async (s, e) => await DownloadSoundEffectsFilesAsync();

        }


        //A�a��daki metot verilen URL'ler �zerinden indirme yap�p Kelimeler_Dosyasi'nin i�ine atar
        private async Task DownloadMultipleFilesAsync() 
        {
            string masaustuYolu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //masa�st� yolu

            string klasorAdi = "Kelimeler_Dosyasi";

            string klasorYolu = Path.Combine(masaustuYolu, klasorAdi); //klas�r�n tam yolunu olu�turuyoruz1

            string[] metinbelgesiadlari = {"a1_kelimeler", "a2_kelimeler", "b1_kelimeler", "b2_kelimeler",
            "c1_kelimeler","c2_kelimeler"};
            //metin belgelerine verilecek adlar

            if (!Directory.Exists(klasorYolu))//Dosya yoksa olusturuyoruz
            {
                Directory.CreateDirectory(klasorYolu); 
            }


            List<string> urls = new List<string>()
            {
               "https://drive.usercontent.google.com/u/0/uc?id=1qVYkQxtpV6AvejdIetNqC9FGZVrUS-cT&export=download",
               "https://drive.usercontent.google.com/u/0/uc?id=16vRL1Tk0Eexw6ejIPidMzD3cKWnJJ6sQ&export=download",
               "https://drive.usercontent.google.com/u/0/uc?id=1esgw3u2W0UECrS_tahKSCzZd_sL8jvX8&export=download",
               "https://drive.usercontent.google.com/u/0/uc?id=1UTmTibjSTSAGy7qjGoqul_I964fLrSY9&export=download",
               "https://drive.usercontent.google.com/u/0/uc?id=1672F54o5EDHpcYgF9cDbPC5rDshzZjIx&export=download",
               "https://drive.usercontent.google.com/u/0/uc?id=1EyQe-si_mFTmKkCnOsPaz1BkxymP9LWy&export=download"

            };


            // HttpClient nesnesini olu�turuyoruz (internet �zerinden dosya indirmek i�in)
            using (HttpClient client = new HttpClient())
            {
                // D�ng� ile t�m linkleri tek tek indiriyoruz
                for (int i = 0; i < urls.Count; i++)
                {
                    // Kaydedilecek dosya ad�: default1.txt, default2.txt, vb.
                    string dosyaAdi = metinbelgesiadlari[i]+".txt";

                    // Dosyan�n tam kaydedilece�i yol
                    string hedefDosya = Path.Combine(klasorYolu, dosyaAdi);


                    // Dosya zaten varsa indirmeye gerek yok
                    if (!File.Exists(hedefDosya))
                    {
                        try
                        {
                            // Dosyay� byte dizisi olarak indiriyoruz
                            var content = await client.GetByteArrayAsync(urls[i]);

                            // �ndirilen dosyay� diske yaz�yoruz
                            File.WriteAllBytes(hedefDosya, content);
                        }
                        catch (Exception ex)
                        {
                            // E�er indirme s�ras�nda hata olursa kullan�c�ya bildiriyoruz
                            MessageBox.Show($"{dosyaAdi} indirilemedi: " + ex.Message);
                        }
                    } 

                }  } }



        //Sound Effect'leri indiren metod

        private async Task DownloadSoundEffectsFilesAsync()
        {

            string masaustuYolu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //masa�st� yolu

            string klasorAdi = "Kelimeler_Dosyasi";

            string sesEfektleri = "Sound_Effects";

            string klasorYolu = Path.Combine(masaustuYolu, klasorAdi, sesEfektleri); //klas�r�n tam yolunu olu�turuyoruz

            string[] sesefektleri = { "CorrectSound.mp3" };


            if (!Directory.Exists(klasorYolu)) //"Sound_Effects" adl� klas�r yoksa olu�tur
            {
                Directory.CreateDirectory(klasorYolu);
            }

            List<string> urls = new List<string>() {
            "https://drive.usercontent.google.com/u/0/uc?id=1w1QScq90_fCukrlY8an2a04SGo5KDLw5&export=download"
            };

            // HttpClient nesnesini olu�turuyoruz (internet �zerinden dosya indirmek i�in)
            using (HttpClient client = new HttpClient())
            {
                for (int i = 0; i < urls.Count; i++) //Linklerden teker teker indirmeler yap�l�r
                {
                    string dosyaadi = sesefektleri[i]; //dosya adlar�n� giriyoruz

                    string dosyayolu = Path.Combine(klasorYolu, dosyaadi);// indirilecek dosyan�n , dosya yolunu girdik

                    if (!Directory.Exists(dosyayolu))
                    {
                        try { 
                            var content=await client.GetByteArrayAsync(urls[i]); //urldekini byte byte indiriyouz

                            File.WriteAllBytes(dosyayolu,content); //dosyay� yaz�yoruz(dosyan�nyolu,bytelar)
                        
                        }
                        catch(Exception ex) {
                            // E�er indirme s�ras�nda hata olursa kullan�c�ya bildiriyoruz
                            MessageBox.Show($"{dosyaadi} indirilemedi: " + ex.Message);
                        }
                    }

                }


            }
        }









        private void button1_Click(object sender, EventArgs e)//onayla
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
                metinbelgesi=Path.GetFileName(metinbelgesi);
                Form3 f3 = new Form3(ingkelimeler, t�rkceleri, metinbelgesi);
                this.Hide();
                f3.ShowDialog();
            }
        }




        private void button2_Click(object sender, EventArgs e) //Metin belgesi se�me butonu
        {
            // Dosya se�ici penceresini olu�turuyoruz   
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Yaln�zca .txt dosyalar�n� g�sterecek �ekilde filtreleme
            openFileDialog.Filter = "Metin Dosyas� (*.txt)|*.txt";

            // Pencereyi a��yoruz ve kullan�c� bir dosya se�ti mi diye kontrol ediyoruz
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Se�ilen dosyan�n yolunu al�yoruz
                metinbelgesi = openFileDialog.FileName;

                try
                {
                    // Dosya var m� kontrol ediyoruz ve i�eri�ini MessageBox ile yaz�yoruz
                    if (File.Exists(metinbelgesi))
                    {
                        // using blo�u ile StreamReader'� a��p, dosya i�leminden sonra otomatik olarak kapat�lmas�n� sa�l�yoruz
                        using (StreamReader sr = new StreamReader(metinbelgesi))
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
                        label2.Text = "          Metin Belgesini eklediniz \n       Kelime Bulmaya ge�mek i�in \n          Onayla Butonuna T�klay�n";
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
