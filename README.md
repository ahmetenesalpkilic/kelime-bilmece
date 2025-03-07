# WinFormsApp1
Uygulama Akış Şeması:

1-) Form1 – Karşılama Ekranı

Uygulama başlatıldığında, Form1 bir karşılama ekranı olarak gösterilir.
Form1'de bir buton bulunur (örneğin "Başla").
Kullanıcı butona tıkladığında, Form2 açılır.


2-) Form2 – Kelime Girişi

Girilen sayı kadar eleman içeren iki adet Generic List oluşturulur:
İngilizce kelimeler listesi
Türkçe karşılıklar listesi
Kullanıcı, sırasıyla bir İngilizce kelime ve onun Türkçe karşılığını girer ve “Enter” tuşuna basar.
Her giriş sonrası sayaç güncellenir ve kelimeler ilgili listelere eklenir.
Tüm kelimeler girildiğinde, listeler Form3’e aktarılır.


3-) Form3 – Kelime Testi

Liste, aşağıdaki metod kullanılarak rastgele karıştırılır:
Enumerable.Range(0, ingkelimeler.Count).OrderBy(x => rnd.Next()).ToList();
Ekranda rastgele seçilen İngilizce kelime gösterilir.
Kullanıcı, bu kelimenin Türkçe karşılığını girer.
Doğru cevap verildiğinde sayaç artar ve bir sonraki kelime gösterilir.
Tüm kelimeler doğru cevaplandığında uygulama sona erer.
