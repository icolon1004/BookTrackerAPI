# 📚 Book Tracker API

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white)
![Status](https://img.shields.io/badge/Status-Active-success)

A RESTful API for tracking books you've read, managing reading lists, and analyzing reading habits. Built with ASP.NET Core 8 as a portfolio project.

## 🌟 Features

- ✅ **Full CRUD Operations** - Create, read, update, and delete books
- ✅ **Reading Status Tracking** - Want to Read, Currently Reading, Finished
- ✅ **Ratings & Reviews** - 5-star rating system with personal notes
- ✅ **Search Functionality** - Search by title, author, or genre
- ✅ **Reading Statistics** - Track books read, pages read, average ratings
- ✅ **Genre Analytics** - Breakdown of books by genre
- ✅ **RESTful Design** - Proper HTTP methods and status codes

## 🛠️ Technologies Used

- **Framework:** ASP.NET Core 8.0
- **Language:** C#
- **Architecture:** Service/Controller pattern with Dependency Injection
- **Data Storage:** In-memory (database coming in v2.0)
- **API Documentation:** Swagger/OpenAPI

## 📋 API Endpoints

### Books
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/books` | Get all books (with optional filters) |
| GET | `/api/books/{id}` | Get a specific book by ID |
| POST | `/api/books` | Add a new book to library |
| PUT | `/api/books/{id}` | Update book details |
| DELETE | `/api/books/{id}` | Remove book from library |
| GET | `/api/books/search?query={text}` | Search books |

### Statistics
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/statistics/summary` | Get overall reading statistics |
| GET | `/api/statistics/genres` | Get genre breakdown |

## 🚀 How to Run

### Prerequisites
- .NET 8.0 SDK
- Visual Studio 2022 (or VS Code)
- Postman (for testing)

### Steps
1. Clone this repository
```bash
git clone https://github.com/YOUR_USERNAME/BookTrackerAPI.git
cd BookTrackerAPI
```

2. Open in Visual Studio
```bash
# Or open the .sln file in Visual Studio
```

3. Run the application
```bash
dotnet run
# Or press F5 in Visual Studio
```

4. API will be available at `https://localhost:7005` (or your port)

5. Test the API using Postman or Swagger UI at `https://localhost:7005/swagger`

## 📖 Example Usage

### Get All Books
```http
GET /api/books
```

**Response:**
```json
[
  {
    "id": 1,
    "title": "The Hobbit",
    "author": "J.R.R. Tolkien",
    "status": 2,
    "rating": 5,
    "genres": ["Fantasy", "Adventure"]
  }
]
```

### Add a New Book
```http
POST /api/books
Content-Type: application/json

{
  "title": "1984",
  "author": "George Orwell",
  "pageCount": 328,
  "genres": ["Science Fiction", "Dystopian"],
  "status": 0
}
```

### Get Reading Statistics
```http
GET /api/statistics/summary
```

**Response:**
```json
{
  "totalBooks": 10,
  "booksRead": 6,
  "currentlyReading": 2,
  "averageRating": 4.3,
  "totalPagesRead": 2847,
  "favoriteGenre": "Fantasy"
}
```

## 📚 What I Learned

Building this project taught me:

- **RESTful API Design** - Proper HTTP methods, status codes, and resource modeling
- **ASP.NET Core** - Controllers, routing, middleware, dependency injection
- **C# Best Practices** - LINQ, async/await, nullable types, DTOs
- **API Architecture** - Service layer pattern, separation of concerns
- **Error Handling** - Validation, proper error responses
- **API Documentation** - Swagger/OpenAPI integration
- **Version Control** - Git workflow and GitHub collaboration

## 🔮 Future Enhancements

- [ ] Add SQL database with Entity Framework Core
- [ ] Implement user authentication (JWT)
- [ ] Add user-specific book libraries
- [ ] Deploy to Azure
- [ ] Build React frontend
- [ ] Add AI-powered book recommendations
- [ ] Import books from Goodreads
- [ ] Add reading goals and challenges

## 🎯 Project Goals

This project was built to:
- Demonstrate full-stack development skills
- Practice modern C# and .NET development
- Build a portfolio piece for job applications
- Learn RESTful API best practices
- Prepare for software developer interviews

## 👤 Author

**Isaiah Colon**  
Aspiring Software Developer

- GitHub: [@icolon1004](https://github.com/icolon1004)
- LinkedIn: [Your LinkedIn](https://linkedin.com/in/isaiah-colon-1b534a211)
- Email: iecolon1004@gmail.com

## 📄 License

This project is open source and available under the MIT License.

---

⭐ If you find this project helpful, please consider giving it a star!