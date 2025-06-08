# 📚 API Endpoints - Art Gallery API

## Base URL
```
https://localhost:{PORT}/api/
```

---

## 🎭 Artists Endpoints

| Method | Route                 | Description             |
|--------|-----------------------|-------------------------|
| GET    | `/artists`            | Get all artists         |
| GET    | `/artists/{id}`       | Get artist by ID        |
| POST   | `/artists`            | Create a new artist     |
| PUT    | `/artists/{id}`       | Update existing artist  |
| DELETE | `/artists/{id}`       | Delete an artist        |

**Sample JSON Request:**
```json
{
  "name": "Emily Kngwarreye",
  "tribe": "Anmatyerre",
  "biography": "Renowned aboriginal artist from the Utopia region."
}
```

---

## 🖼️ Artifacts Endpoints *(planned)*

| Method | Route                   | Description               |
|--------|-------------------------|---------------------------|
| GET    | `/artifacts`            | Get all artifacts         |
| GET    | `/artifacts/{id}`       | Get artifact by ID        |
| POST   | `/artifacts`            | Create a new artifact     |
| PUT    | `/artifacts/{id}`       | Update an artifact        |
| DELETE | `/artifacts/{id}`       | Delete an artifact        |

**Sample JSON Request:**
```json
{
  "title": "Desert Dreaming",
  "description": "A painting of sand dunes in dot art style.",
  "artistId": "648ef7d18cfdd7ad0a1f2b70",
  "tags": ["dot painting", "dreamtime", "landscape"]
}
```

---

## 🔐 Authorization *(Future Integration)*
- All routes currently open
- Planned to protect `POST`, `PUT`, `DELETE` with OAuth
- Integration with Auth0 for secure login and roles
