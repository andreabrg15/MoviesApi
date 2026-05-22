# Endpoints
## /genres
Al llamar a este endpoint con el método GET, devuelve la lista de géneros de películas guardados.
```
[
  {
    "id": 1,
    "name": "Action"
  },
  {
    "id": 2,
    "name": "Sci-Fi"
  },
  {
    "id": 3,
    "name": "Drama"
  },
  ...
]
```
## /movies
### GET
Un llamado a este endpoint con este método, devuelve la lista de películas guardadas.
```
[
  {
    "id": 1,
    "title": "Titanic",
    "description": "Jack and Rose story in a ship",
    "genre": "Drama",
    "releaseDate": "1998-01-01"
  },
  {
    "id": 2,
    "title": "Avengers",
    "description": "Earth's mighty superheroes",
    "genre": "Action",
    "releaseDate": "2012-05-04"
  },
]
```

### POST
Un llamado a este endpoint con este método se usa para guardar una nueva película, para ello se deben pasar los datos en formato JSON en el body del Request.
```
Request Body:
{
  "title": "Titulo de la película",
  "description": "Descripcion de la película",
  "genreId": 1,
  "releaseDate": "YYYY-MM-dd"
}
```

## /movies/{id}
### GET
Un llamado a este endpoint con este método, devuelve los detalles de la película guardada con ese id.
```
Ejemplo /movies/2
{
  "id": 2,
  "title": "Titanic",
  "description": "Jack and Rose story in a ship",
  "genreId": 3,
  "releaseDate": "1997-07-25"
}
```

### PUT
Un llamado a este endpoint con este método se usa para modificar la película guardada con ese id, para ello igual que con el método POST se deben pasar los datos en formato JSON en el body del Request.

### DELETE
Un llamado a este endpoint con este método se usa para borrar la película guardada con ese id.
