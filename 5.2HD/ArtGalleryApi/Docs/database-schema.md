# 🧩 Database Schema - Art Gallery API

## Database
- MongoDB
- Database Name: `ArtGalleryDB`

---

## 🎭 Collection: Artists

| Field     | Type       | Description                    |
|-----------|------------|--------------------------------|
| `_id`     | ObjectId   | Unique MongoDB ID              |
| `name`    | string     | Name of the artist             |
| `tribe`   | string     | Aboriginal tribe (optional)    |
| `biography` | string   | Short biography or description |

**Sample Document:**
```json
{
  "_id": "648ef7d18cfdd7ad0a1f2b70",
  "name": "Albert Namatjira",
  "tribe": "Arrernte",
  "biography": "Famous for watercolour landscapes"
}
```

---

## 🖼️ Collection: Artifacts

| Field      | Type       | Description                             |
|------------|------------|-----------------------------------------|
| `_id`      | ObjectId   | Unique MongoDB ID                       |
| `title`    | string     | Name/title of the artifact              |
| `description` | string | Description of the artwork              |
| `artistId` | ObjectId   | Reference to Artist._id                 |
| `tags`     | array<string> | Keywords or iconography associated   |

**Sample Document:**
```json
{
  "_id": "648efc449fe108763fbc45a1",
  "title": "Bush Medicine",
  "description": "Symbolic representation of native healing plants.",
  "artistId": "648ef7d18cfdd7ad0a1f2b70",
  "tags": ["medicine", "botany", "dot painting"]
}
```

---

## 🌐 Notes

- All collections are flexible schema (MongoDB)
- No enforced foreign key, but `artistId` provides a soft relation
- Can index `artistId` or `tags` for performance later
