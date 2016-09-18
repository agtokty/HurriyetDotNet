# HurriyetDotNet
Hurriyet Api DotNet Client

Bu istemci H�rriyet'in sunumu� oldu�u [Api](https://developers.hurriyet.com.tr/)'yi kullanmak i�in yaz�lm��t�r.

HurriyetDotNet'i kullanabilmek i�in api anahtar�na ihtiyac�n�z vard�r. 
Api anahtar�n� [H�rriyet developers](https://developers.hurriyet.com.tr)'a �ye olduktan sonra alabilirsiniz.


NuGet �zerinden indirebilirsiniz.

	PM> Install-Package HurriyetDotNet

HurriyetDotNet Kullan�m�
============

HurriyetDotNet ile veri �ekmek olduk�a basittir. Tek yapman�z gereken HurriyetClient s�n�f�n� ge�erli bir api anahtar�yla
olu�turmakt�r.

```C#
HurriyetClient client = new HurriyetClient("API_KEY");
```

Olu�turdu�unuz HurriyetClient nesnesiyle ile sistemdeki.

- Haberlere - *ArticleClient*,
- K��e yaz�lar�na - *ColumnsClient*,
- Haber i�i foto galerilerine  - *NewsPhotoGalleryClient*,
- Sayfalar� ve sayfalara atanm�� haberleri  - *PageClient*,
- Klas�rleri - *PathClient*,
- Yazarlar�  - *WriterClient* kullanarak eri�ebilirsiniz

�al��ma zaman�nda api anahtar�n� a�a��daki gibi de�i�tirebilirsiniz.

```C#
HurriyetClient client = new HurriyetClient("API_KEY");
.
.

Authentication auth = new Authentication("API_KEY2");
client.Authenticator = auth;
//Bundan sonraki istekler g�ncel api anahtar�(API_KEY2) ile yap�l�r.
```


Examples
--------------
```C#
Authentication auth = new Authentication("API_KEY");
HurriyetClient client = new HurriyetClient(auth);

//Id de�eri 570167e867b0a90bdc503452 olan yazar� getirmek i�in.
Writer wrt = client.Writers.GetWriter("570167e867b0a90bdc503452");
```
