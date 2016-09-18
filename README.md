# HurriyetDotNet
Hurriyet Api DotNet Client

Bu istemci Hürriyet'in sunumuþ olduðu [Api](https://developers.hurriyet.com.tr/)'yi kullanmak için yazýlmýþtýr.

HurriyetDotNet'i kullanabilmek için api anahtarýna ihtiyacýnýz vardýr. 
Api anahtarýný [Hürriyet developers](https://developers.hurriyet.com.tr)'a üye olduktan sonra alabilirsiniz.


NuGet üzerinden indirebilirsiniz.

	PM> Install-Package HurriyetDotNet

HurriyetDotNet Kullanýmý
============

HurriyetDotNet ile veri çekmek oldukça basittir. Tek yapmanýz gereken HurriyetClient sýnýfýný geçerli bir api anahtarýyla
oluþturmaktýr.

```C#
HurriyetClient client = new HurriyetClient("API_KEY");
```

Oluþturduðunuz HurriyetClient nesnesiyle ile sistemdeki.

- Haberlere - *ArticleClient*,
- Köþe yazýlarýna - *ColumnsClient*,
- Haber içi foto galerilerine  - *NewsPhotoGalleryClient*,
- Sayfalarý ve sayfalara atanmýþ haberleri  - *PageClient*,
- Klasörleri - *PathClient*,
- Yazarlarý  - *WriterClient* kullanarak eriþebilirsiniz

Çalýþma zamanýnda api anahtarýný aþaðýdaki gibi deðiþtirebilirsiniz.

```C#
HurriyetClient client = new HurriyetClient("API_KEY");
.
.

Authentication auth = new Authentication("API_KEY2");
client.Authenticator = auth;
//Bundan sonraki istekler güncel api anahtarý(API_KEY2) ile yapýlýr.
```


Examples
--------------
```C#
Authentication auth = new Authentication("API_KEY");
HurriyetClient client = new HurriyetClient(auth);

//Id deðeri 570167e867b0a90bdc503452 olan yazarý getirmek için.
Writer wrt = client.Writers.GetWriter("570167e867b0a90bdc503452");
```
