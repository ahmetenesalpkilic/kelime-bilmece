1. Form1 – Karşılama Ekranı
Uygulama başlatıldığında, Form1 karşılama ekranı olarak gösterilir.

Form1'de bir buton bulunur (örneğin "Başla").

Kullanıcı, bu butona tıkladığında Form2 açılır.

Ayrıca, Kelimeler_Dosyasi adında bir dosya oluşturulur ve masaüstüne kaydedilir. (Önceden oluşturduğunuz bilmediğiniz kelimelerle ilgili metin belgesini de ekleyebilirsiniz.)

2. Form2 – Kelime Girişi
Kullanıcı, girilecek kelime sayısını belirler.

Girilen sayı kadar eleman içeren iki adet Generic List oluşturulur:

İngilizce kelimeler listesi

Türkçe karşılıklar listesi

Kullanıcı, sırasıyla bir İngilizce kelime ve onun Türkçe karşılığını girer ve Enter tuşuna basar.

Her giriş sonrası sayaç güncellenir ve kelimeler ilgili listelere eklenir.

Kullanıcıdan, kelimeleri kaydetmek için bir dosya ismi alınır ve bu dosya metin belgesine yazılır, ardından Kelimeler_Dosyasi'na kaydedilir.

Tüm kelimeler girildikten sonra, listeler Form3'e aktarılır.

3. Form3 – Kelime Testi
Girilen kelimeler, aşağıdaki metot kullanılarak rastgele karıştırılır:
Enumerable.Range(0, ingkelimeler.Count).OrderBy(x => rnd.Next()).ToList();
Ekranda rastgele seçilen İngilizce kelime gösterilir.

Kullanıcı, bu kelimenin Türkçe karşılığını girer.

Doğru cevap verildiğinde sayaç artar ve bir sonraki kelime gösterilir.

Tüm kelimeler doğru cevaplandığında uygulama sona erer.
