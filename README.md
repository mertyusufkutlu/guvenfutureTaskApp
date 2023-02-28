# Guven Future Mülakat Proje Dokümanı

- #### Kullanılan kütüphaneler :  AutoMapper, Newtonsoft.Json, EntityFrameworkCore, DependencyInjection, JwtBearer, MediatR

- #### Kullanılan Design Patterler :  Onion Architecture, CQRS, Repository Pattern


- Proje çalışmadan önce local veritabanına (MSSQL) `etradeAPIDb` adında bir veritabanı oluşturmak veya connectionstring'i kendinize göre düzenlemeniz gerekir.

- Proje codefirst olup İlk açılışta connection sağlandıktan sonra update-database yapmak yeterli olacaktır.



***Verilen task için tüm API'lerin açıklaması aşağıda mevcuttur*** :



## Yeni Kullanıcı Oluştur
```http
  POST /api/Auth/register
```
| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `userName` | `string` | Yeni kullanıcı adı |
| `passowrd` | `string` | Yeni kullanıcı şifresi |
#### Açıklama
- Burada Id,CreatedAt gibi Base proplar'ı doldurmaya gerek yoktur otomatik atayacaktır. Arka tarafta passwordHash ve passwordSalt tutulup eşleştirilir.



## Kullanıcı Girişi

```http
  POST /api/Auth/login
```
| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `userName` | `string` | Kullanıcı adı |
| `passowrd` | `string` | Kullanıcı şifresi |

#### Açıklama
- Kullanıcı adı ve şifre doğru ise JWT Bearer token üretecektir



## Ürünlerin tamamını listeleyen API
```http
  GET api/Products/GetAll
```
#### Açıklama
- Herhangi bir parametresi yoktur GetAll hepsini listeleyecektir



## Ürün Kategorisi Ekleme
```http
  POST api/ProductGroup
```
| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `name` | `string` | Ürünün Eşleşeceği Ürün Kategorisinin Adı |

#### Açıklama
- Ürün kategorisinin adını girmemiz yeterli olacaktır Base'den Guid olarak bir Guid değeri basılacak sonrasında ürün eklerken bu Kategori ile eşleştirebileceğiz.


## Ürün Ekleme
```http
  POST api/Products
```
| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `name` | `string` | Ürün Adı |
| `stock` | `int` | Ürün Stok Miktarı |
| `price` | `float` | Ürün Fiyatı |
| `productGroupId` | `Guid` | Ürünün Hangi Kategoriye ait olduğu |

#### Açıklama
- Ürün eklemek için kategorisi olması gerekir bu yüzden öncelikle kategori ekleyip sonra ürün eklemek önerilir



## Ürün Silme
```http
  DELETE api/Products/{id}
```
| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `id` | `Guid` | ÜrünId'si |

#### Açıklama
- Ürün silmek için sadece ilgili ürünün Guid'sini girmek yeterlidir.



## Müşteri Bazlı Sepete Ürün Ekleme
```http
  POST api/CustomerBasket
```
| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `userId` | `Guid` | Kullanıcı Id'si |
| `productId` | `Guid` | Ürün Id'si |

#### Açıklama
- Kullanıcı bazlı sepete ürün eklemek için UserId ve ProductId değerlerini CustomerBasket tablosuna insert işlemi yapılır.
