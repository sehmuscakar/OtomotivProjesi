# 🚗 OtoGaleri | Web Tabanlı Otomobil Galerisi Projesi

Merhaba! Bu proje,  **N-Tier Architecture** (Katmanlı Mimari) yapısına sahip, içerik yönetim sistemi (CMS) ile zenginleştirilmiş bir **web tabanlı araç galerisi** uygulamasıdır.

---

## 🧩 Proje Özellikleri

- ✅ N-Tier Architecture (Katmanlı Mimari)
- 🔐 Identity sistemi (Login, Register, Mail Onayı, Profil Güncelleme)
- 📨 İletişim & Araç Talep formlarında e-posta gönderimi
- 📌 CMS (Content Management System) ile içerik güncelleme
- 📦 Areas kullanımı (Admin ve kullanıcı alanları ayrımı)
- 🔢 RowOrder algoritması (içerik sıralama)
- 🖼️ Portfolio sistemi (galeri mantığı)
- 🔎 İlgili ID ile detay sayfasına yönlendirme
- ❌ Özel 404 hata sayfası
- 🔓 Çıkış yap (Logout) özelliği
- 🏠 Index sayfasında sayfa bileşenleri (ViewComponent ile)

---

## 🛠️ Kullanılan Katmanlar ve Yapılar

### 📁 CoreLayer
- `IEntity`, `IDto`, `IEntityRepository` gibi temel arabirimler

### 💼 BusinessLayer
- `Manager` sınıfları (`CarManager`, `BrandManager` vs.)
- `Abstract` klasöründe iş mantığı arayüzleri
- `Concrete` klasöründe uygulama sınıfları

### 🧬 DataAccessLayer
- Entity Framework kullanılarak veri erişimi
- `ProjeContext.cs`: Veritabanı yapılandırması
- `Dtos`: Admin paneli için özel DTO'lar

### 🌐 OtoGaleriPresentationLayer
- `Areas/Admin`: Admin alanı ve controller’lar
- `Controllers`: Kullanıcıya açık controller’lar
- `ViewComponents`: Sayfa bileşenleri (örneğin: `CarViewComponent`)
- `Views`: Razor View sayfaları
- `Models`: ViewModel dosyaları

---

## 👤 Identity Özellikleri

- 📨 Mail onay kodu ile kayıt doğrulama
- 🔐 Giriş (Login) ve Kayıt (Register)
- 👤 Profil bilgilerini güncelleme (sadece oturum açmış kullanıcılar)
- 🚪 Güvenli çıkış yap (Logout)

---

## 📧 Mail Gönderim Özelliği

- 📮 `Contact` ve `CarRequestForm` formları üzerinden e-posta gönderimi
- ✔️ Form doğrulama ve backend kontrol mekanizmaları mevcut

---

## 🖼️ CMS (İçerik Yönetim Sistemi)

- 📝 Admin paneli ile içerikleri yönetme
- 📁 Hakkımızda, Hizmetler, Galeri, Takım vb. bölümleri yönetme
- 🔁 İçerik sıralama işlemleri (RowOrder algoritması)

---

## 🔗 Örnek Sayfalar

| Sayfa         | Açıklama                                    |
|---------------|---------------------------------------------|
| 🏠 Anasayfa    | Hero alanı, slider, hizmetler ve araçlar    |
| 🚘 Araçlar     | Araç listesi, kategoriye göre filtreleme     |
| 👥 Takım       | Firma ve ekip bilgileri                     |
| 📮 İletişim    | Form aracılığıyla mesaj gönderimi            |
| 🧾 Araç Talebi | Kullanıcılar araç talebinde bulunabilir     |

---

## 💻 Kullanılan Teknolojiler

- ASP.NET Core MVC `7.0`
- Entity Framework Core
- AutoMapper
- SQL Server
- Bootstrap 5
- C#
- LINQ

---

## 🔐 Giriş & Kayıt

Kullanıcılar sisteme:
- ✔️ Kayıt olabilir (e-mail onaylı)
- ✔️ Giriş yapabilir
- ✔️ Profil bilgilerini güncelleyebilir

---

## ❗ Hata Sayfası

- 📄 `404 Not Found` özel sayfası
- ⚠️ Beklenmeyen hatalar için yönlendirme

---
