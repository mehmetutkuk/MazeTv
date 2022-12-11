# MazeTv

The goal is to fetch data from `https://www.tvmaze.com/api` via Rest API and serve it with a specific model on the endpoint with pagination.
The response model example is below.

`[
{
"id": 1,
"name": "Game of Thrones",
"cast": [
{
"id": 7,
"name": "Mike Vogel",
"birthday": "1979-07-17"},
{
"id": 9,
"name": "Dean Norris",
"birthday": "1963-04-08"
}
]
},
{
"id": 4,
"name": "Big Bang Theory",
"cast": [
{
"id": 6,
"name": "Michael Emerson",
"birthday": "1950-01-01"
}
]
}
]`

When the project starts running, data from TvMaze the API begin with it without blocking endpoints to be usable. I used SQLite for data persistence. 
You can run the solution by starting the MazeTv API project via IIS.
