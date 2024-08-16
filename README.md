# Student Portal API

Bu proje, bir üniversite sistemi gibi düşünülebilecek basit bir öğrenci portalı API'sidir. Modern yazılım mimarisi prensiplerini izleyerek, Entity Framework Core ve Code First yaklaşımı ile Microsoft SQL Server veritabanı kullanılarak geliştirilmiştir. API, öğrencilerin ve derslerin yönetimini sağlar ve kullanıcı kimlik doğrulaması için JWT (JSON Web Token) kullanır. Proje, Onion Architecture prensipleri doğrultusunda katmanlı bir yapıya sahiptir.

## Proje Mimarisi

Proje, bağımlılıkları yönetmek ve kodu daha düzenli hale getirmek için Onion Architecture prensipleri doğrultusunda katmanlı bir mimari kullanır. Her katman belirli bir sorumluluğa sahiptir ve sadece kendisinden daha düşük seviyeli katmanlara bağımlıdır.

### 1. Core Katmanı

Bu katman, uygulamanın iş mantığını ve kurallarını içerir. İki yapıdan oluşur:

- **Domain**:
  - Uygulamanın temel yapı taşlarını (Entities) tanımlar. Örneğin, `Student` ve `Course` entity'leri burada bulunur.
  - İş kurallarını ve doğrulamalarını içerir.
  - Veritabanı veya diğer altyapı teknolojilerinden bağımsızdır.

- **Application**:
  - Use case'leri ve iş mantığının uygulanmasını içerir.
  - Domain katmanındaki entity'leri ve arayüzleri kullanarak iş operasyonlarını gerçekleştirir.
  - Veritabanı veya diğer altyapı teknolojilerinden bağımsızdır.
  - CQRS (Command Query Responsibility Segregation) desenini kullanarak komutları ve sorguları ayırır.

### 2. Infrastructure Katmanı

Bu katman, uygulamanın altyapısal bileşenlerini içerir. Temelde iki yapıdan oluşur ancak bu projede SignalR temeli atılmıştır:

- **Infrastructure**:
  - Uygulama genelinde kullanılan ortak altyapı bileşenlerini içerir.
  - Örneğin, e-posta gönderme, logging gibi işlemler için servisler burada bulunabilir.

- **Persistence**:
  - Veritabanı erişimini yönetir.
  - Entity Framework Core kullanarak veritabanı işlemlerini gerçekleştirir.
  - Repository desenini kullanarak veritabanı erişimini soyutlar.
  - Domain katmanındaki entity'leri veritabanı tablolarına eşler.

- **SignalR**:
  - Gerçek zamanlı iletişim için SignalR Hub'larını içerir.
  - Örneğin, öğrenci portalında yeni bir duyuru yayınlandığında veya bir ders güncellendiğinde, SignalR kullanılarak bağlı olan tüm kullanıcılara anında bildirim gönderilebilir.

### 3. Presentation Katmanı

Bu katman, kullanıcı arayüzünü ve API'yi içerir. Tek bir yapıdan oluşur:

- **API (.NET Web API)**:
  - Uygulamanın dış dünyaya açılan kapısıdır.
  - HTTP isteklerini alır ve Application katmanındaki use case'leri çağırarak işler.
  - JSON formatında yanıtlar döndürür.
  - Kullanıcı kimlik doğrulaması ve yetkilendirme için JWT (JSON Web Token) kullanır.

## Kimlik Doğrulama ve Yetkilendirme

Proje, kullanıcı kimlik doğrulaması ve yetkilendirme için JWT (JSON Web Token) kullanır. Kullanıcılar, kullanıcı adı ve şifreleriyle giriş yaparak bir Access Token ve bir Refresh Token alırlar.

- **Access Token**: API'ye erişmek için kullanılır ve sınırlı bir geçerlilik süresine sahiptir.
- **Refresh Token**: Access Token'ın süresi dolduğunda yeni bir Access Token almak için kullanılır ve daha uzun bir geçerlilik süresine sahiptir.

## Proje Detayları

- **Student (Öğrenci)**: Öğrenci bilgilerini içerir (Ad, Soyad, Bölüm, vb.).
- **Course (Ders)**: Ders bilgilerini içerir (Ders Adı, Ders Kodu, vb.).
- **AppUser**: Uygulama kullanıcılarını temsil eder.
- **AppRole**: Kullanıcı rollerini temsil eder.

## Kurulum ve Çalıştırma

1. **Projeyi klonlayın:**
   ```bash
   git clone https://github.com/mevlutayilmaz/simple-web-api.git
   
2. **`StudentPortal.API` klasörüne gidin.**

3. **`appsettings.json` dosyasında veritabanı bağlantı bilgilerini ayarlayın.**

4. **Paketleri yükleyin:**
   ```bash
   dotnet restore
   
5. **Veritabanını oluşturun ve migrate edin:**
   ```bash
   dotnet ef database update

6. **Projeyi çalıştırın:**
   ```bash
   dotnet run

## Sonuç

Bu proje, temiz bir mimari ve modern teknolojiler kullanarak geliştirilmiş, güvenli ve ölçeklenebilir bir öğrenci portalı API'sidir. Proje, katmanlı yapısı sayesinde bakımı ve geliştirilmesi kolaydır.

