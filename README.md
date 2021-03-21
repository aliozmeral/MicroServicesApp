
Açıklama:

- Contact.Api ve Report.Api olmak üzere 2 adet microservices hazırlandı.
- Bu iki microservice birbirleriyle DotNetCoreCAP (RabbitMQ üzerinden) kütüphanesi aracılığı ile Procuder ve Consumer olarak haberleşmekte.
- Report Api 'den DotNetCoreCAP ile Contact.Api bilgileri tetiklenmekte ve rapor talebi için tekrar Contact.Api'den RabbitMQ kuyruğuna iletilmekte.
- Proje start edildiğinde Contact.Api (http://localhost:5000/swagger/index.html) ve Report.Api (http://localhost:5002/report)

Kullanılan Teknolojiler.
- .Net Core WEB API (.net 5.0) ve swagger ,Entity Framework (@"Data Source =(localdb)\MSSQLLocalDB; Initial Catalog =MicroserviceExampleDB;Trusted_Connection=True;MultipleActiveResultSets = true")
- MongoDB 
(docker pull mongo // mongodb docker install /
docker run -d -p 27017:27017 --name contact-mongo mongo ) --Contact Bilgileri için.
- RabbitMQ 
 ($ docker run -d --hostname my-rabbit --name some-rabbit rabbitmq:3-management)


Contact Api Bilgileri :
http://localhost:5000/swagger/index.html 

Report.Api 
http://localhost:5002/report link 'i url den rapor talebi için çağırılarak Contact Api ile haberleşmesi debug edilebilir.

