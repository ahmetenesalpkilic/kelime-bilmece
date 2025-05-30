using System.IO;  // StreamReader ve File için
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        List<string> ingkelimeler;
        List<string> türkceleri;
        int sayac = 0;
        bool txtbool = true;
        string metinbelgesi;

        public Form1()
        {
            InitializeComponent();
            ingkelimeler = new List<string>();
            türkceleri = new List<string>();

            // Form yüklendiðinde otomatik olarak dosyalarý indirip kaydedecek
            this.Load += async (s, e) => await DownloadMultipleFilesAsync();

            this.Load += async (s, e) => await DownloadSoundEffectsFilesAsync();

        }


        //Aþaðýdaki metot verilen URL'ler üzerinden indirme yapýp Kelimeler_Dosyasi'nin içine atar
        private async Task DownloadMultipleFilesAsync() 
        {
            string masaustuYolu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //masaüstü yolu

            string klasorAdi = "Kelimeler_Dosyasi";

            string klasorYolu = Path.Combine(masaustuYolu, klasorAdi); //klasörün tam yolunu oluþturuyoruz1

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


            // HttpClient nesnesini oluþturuyoruz (internet üzerinden dosya indirmek için)
            using (HttpClient client = new HttpClient())
            {
                // Döngü ile tüm linkleri tek tek indiriyoruz
                for (int i = 0; i < urls.Count; i++)
                {
                    // Kaydedilecek dosya adý: default1.txt, default2.txt, vb.
                    string dosyaAdi = metinbelgesiadlari[i]+".txt";

                    // Dosyanýn tam kaydedileceði yol
                    string hedefDosya = Path.Combine(klasorYolu, dosyaAdi);


                    // Dosya zaten varsa indirmeye gerek yok
                    if (!File.Exists(hedefDosya))
                    {
                        try
                        {
                            // Dosyayý byte dizisi olarak indiriyoruz
                            var content = await client.GetByteArrayAsync(urls[i]);

                            // Ýndirilen dosyayý diske yazýyoruz
                            File.WriteAllBytes(hedefDosya, content);
                        }
                        catch (Exception ex)
                        {
                            // Eðer indirme sýrasýnda hata olursa kullanýcýya bildiriyoruz
                            MessageBox.Show($"{dosyaAdi} indirilemedi: " + ex.Message);
                        }
                    } 

                }  } }



        //Sound Effect'leri indiren metod

        private async Task DownloadSoundEffectsFilesAsync()
        {

            string masaustuYolu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //masaüstü yolu

            string klasorAdi = "Kelimeler_Dosyasi";

            string sesEfektleri = "Sound_Effects";

            string klasorYolu = Path.Combine(masaustuYolu, klasorAdi, sesEfektleri); //klasörün tam yolunu oluþturuyoruz

            string[] sesefektleri = { "CorrectSound.mp3" };


            if (!Directory.Exists(klasorYolu)) //"Sound_Effects" adlý klasör yoksa oluþtur
            {
                Directory.CreateDirectory(klasorYolu);
            }

            List<string> urls = new List<string>() {
            "https://drive.usercontent.google.com/u/0/uc?id=1w1QScq90_fCukrlY8an2a04SGo5KDLw5&export=download"
            };

            // HttpClient nesnesini oluþturuyoruz (internet üzerinden dosya indirmek için)
            using (HttpClient client = new HttpClient())
            {
                for (int i = 0; i < urls.Count; i++) //Linklerden teker teker indirmeler yapýlýr
                {
                    string dosyaadi = sesefektleri[i]; //dosya adlarýný giriyoruz

                    string dosyayolu = Path.Combine(klasorYolu, dosyaadi);// indirilecek dosyanýn , dosya yolunu girdik

                    if (!Directory.Exists(dosyayolu))
                    {
                        try { 
                            var content=await client.GetByteArrayAsync(urls[i]); //urldekini byte byte indiriyouz

                            File.WriteAllBytes(dosyayolu,content); //dosyayý yazýyoruz(dosyanýnyolu,bytelar)
                        
                        }
                        catch(Exception ex) {
                            // Eðer indirme sýrasýnda hata olursa kullanýcýya bildiriyoruz
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
                metinbelgesi=Path.GetFileName(metinbelgesi);
                Form3 f3 = new Form3(ingkelimeler, türkceleri, metinbelgesi);
                this.Hide();
                f3.ShowDialog();
            }
        }




        private void button2_Click(object sender, EventArgs e) //Metin belgesi seçme butonu
        {
            // Dosya seçici penceresini oluþturuyoruz   
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Yalnýzca .txt dosyalarýný gösterecek þekilde filtreleme
            openFileDialog.Filter = "Metin Dosyasý (*.txt)|*.txt";

            // Pencereyi açýyoruz ve kullanýcý bir dosya seçti mi diye kontrol ediyoruz
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen dosyanýn yolunu alýyoruz
                metinbelgesi = openFileDialog.FileName;

                try
                {
                    // Dosya var mý kontrol ediyoruz ve içeriðini MessageBox ile yazýyoruz
                    if (File.Exists(metinbelgesi))
                    {
                        // using bloðu ile StreamReader'ý açýp, dosya iþleminden sonra otomatik olarak kapatýlmasýný saðlýyoruz
                        using (StreamReader sr = new StreamReader(metinbelgesi))
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
                        label2.Text = "          Metin Belgesini eklediniz \n       Kelime Bulmaya geçmek için \n          Onayla Butonuna Týklayýn";
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
