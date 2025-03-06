# WinFormsApp1
Uygulama Akış Şeması:
1-)
Form1 – Kelime Sayısı Girişi

Kullanıcı, bilinmeyen kelime sayısını girer.
Girilen sayı doğrulanır ve saklanır.
Onaylandıktan sonra sayı, Form2’ye parametre olarak aktarılır.

2-)
Form2 – Kelime Girişi

Girilen sayı kadar eleman içeren iki adet string dizisi oluşturulur:
İngilizce kelimeler dizisi
Türkçe karşılıklar dizisi
Kullanıcı, sırasıyla bir İngilizce kelime ve onun Türkçe karşılığını girer ve “Enter” tuşuna basar.
Her giriş sonrası sayaç güncellenir ve kelime dizilere eklenir.
Tüm kelimeler girildiğinde, diziler Form3’e aktarılır.

3-)
Form3 – Kelime Testi

Dizi, Enumerable.Range(0, ingkelimeler.Length).OrderBy(x => rnd.Next()).ToArray(); metodu ile rastgele karıştırılır.
Ekranda rastgele seçilen İngilizce kelime gösterilir.
Kullanıcı, bu kelimenin Türkçe karşılığını girer.
Doğru cevap verildiğinde sayaç artar ve bir sonraki kelime gösterilir.
Tüm kelimeler doğru cevaplandığında uygulama sona erer.
