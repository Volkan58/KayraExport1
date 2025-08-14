Bir Solution oluşturduktan sonra WebApplication oluşturup, istenen basit yapıdaki DTOS ve Models Klasörlerini oluşturup Model tanımlaması yaptım product id ve tip tanımlaması belirtilmediği için Guid olarak id tutmayı tercih ettim .
Yine belirtilmediği için bazı değerler null geçilebilir ayarlaması yaptım.
Tek dto içerisinde tanımlanabilirdi fakat ben ayırmayı seçtim.
Paketleri kurmaya başladım .
Ef Core Design
Mictosoft Ef Sql
Microsoft Ef Tools
Swashbuckle Core

-  yine belirtilmediği için fluentApi tercih ettim ve BaseContext içerisinde yazmak istemedim , ayırdım
Repository oluşturup git tarafında create yaptım.
Adımlara baseDbContext oluşturarak devam ediyorum.
Repository ekledim fakat global yada Gelişmiş repository eklemedim ayrıca belirtilmediği için.
Servisleri oluşturdum.
DI ayrı yazmak istedim programcs kalabalık olmasın diye.
Swagger programcs yapılandırmasını yaptım .
migration attım.
Controller test ettim.

Gönderilen taskta fazla detaylı olmayan birinci Taskı bitirdim.
