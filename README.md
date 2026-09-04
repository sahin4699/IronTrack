# 🏋️‍♂️ IronTrack - Workout Tracker Web API

IronTrack, ağırlık antrenmanlarını ve set bazlı gelişimleri takip etmek amacıyla geliştirilmiş modern, hafif ve RESTful bir Web API projesidir.

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white)
![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white)

---

## 🚀 Özellikler

- **RESTful Mimarisi:** Antrenman setleri üzerinde tam CRUD operasyonları (Create, Read, Update, Delete).
- **PR (Personal Record) Analizi:** Seçilen egzersiz için kaldırılan maksimum kiloyu hesaplayan özel endpoint.
- **Dahili Dashboard:** API ile tam entegre, animasyonlu ve karanlık neon temalı arayüz.
- **OpenAPI / Swagger:** Uçtan uca endpoint test olanağı.

---

## 📡 API Endpoint'leri

| Metot | Endpoint | Açıklama |
| :--- | :--- | :--- |
| `GET` | `/api/WorkoutLogs` | Tüm antrenman kayıtlarını listeler |
| `POST` | `/api/WorkoutLogs` | Yeni bir set kaydeder |
| `GET` | `/api/WorkoutLogs/pr/{exerciseName}` | Belirtilen hareket için maksimum kiloyu (PR) döner |
| `PUT` | `/api/WorkoutLogs/{id}` | İlgili seti günceller |
| `DELETE` | `/api/WorkoutLogs/{id}` | İlgili seti veritabanından siler |

---

## 🛠️ Kurulum & Çalıştırma

```bash
git clone [https://github.com/sahin4699/IronTrack.git](https://github.com/sahin4699/IronTrack.git)
cd IronTrack
dotnet restore
dotnet ef database update
dotnet run


Tarayıcıdan erişim:

Dashboard: http://localhost:5207

Swagger UI: http://localhost:5207/swagger
