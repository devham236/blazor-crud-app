# Home Component

```bash
@page "/"
@using Models
```

'@page "/"' bedeutet das diese Komponente auf der root route "/" liegt.
'@using Models' importiert den namespace bzw. den Ordner "Models" um Zugriff auf die Classes in diesem Ordner zu haben.

```bash
@if (games is null)
{
    <p><em>Loading...</em></p>
}
else
{
    <table class="table table-striped table-bordered table-hover">
        <thead class="table-dark">
            <th>Id</th>
            <th>Name</th>
            <th>Genre</th>
            <th>Price</th>
            <th>Release Date</th>
            <th>Id</th>
        </thead>

        <tbody>
            @foreach (var game in games)
            {
                <tr>
                    <td>@game.Id</td>
                    <td>@game.Name</td>
                    <td>@game.Genre</td>
                    <td>@game.Price</td>
                    <td>@game.ReleaseDate.ToString("MM/dd/yyyy")</td>
                </tr>
            }
        </tbody>
    </table>
}
```

In der Komponente wird überprüft ob die "games" array gleich null ist, also noch nicht vorhanden ist. Wenn "games" nicht vorhanden ist, wird ein p-tag mit einem Loading text angezeigt, wenn "games" vorhanden ist, wird eine Tabelle mit ein paar table heads und ein table body angezeigt in der durch die "games" array iteriert wird und für jedes "game" eine row wiedergegeben wird.

```bash
@code {
    private Game[]? games;

    protected override void OnInitialized()
    {
        games = GameClient.GetGames();
    }
}
```

Der '@code' block in einer Razor Komponente erlaubt es dir C# Code in einer Komponente einzubetten, ähnlich wie der Raum in einer React Komponente oberhalb des 'return' Blocks.
Zunächst wird eine private Variable (man kann nur in diesem Block auf diese Variable zugreifen) namens 'games' mit dem Typ 'Game[]?' deklariert. Das bedeutet diese array kann nur objects enthalten die denen in der 'Game' class entsprechen. Die 'Game' class dient also als Blueprint für die einzelnen objects.
Die 'OnInitialized' method ist ähnlich wie ein useEffect in react wenn eine Komponente mounts, wenn die Komponente initialisiert wird, wird der Block ausgeführt. Darin wird die zuvor deklarierte mit dem Rückgabewert von der 'GetGames()' function in der 'GameClient' class gleichgesetzt.
Wie bei einer React Komponente die ein State für eine leere array zunächst initialisiert und dann ein useEffect ausführt, in dem data von irgendwo extern gefetcht wird und dann mit der leeren array gleichgesetzt wird.



# Game Class

```bash
namespace GameStore.Client.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
```
Die 'Game' class definiert die Struktur eines 'Game' objects, dieses object hat eine Id, Name, Genre, Price und DateTime property


# GameClient Class

```bash
using GameStore.Client.Models;

namespace GameStore.Client
{
    public static class GameClient
    {
        private static readonly List<Game> games = new()
        {
            new Game(){
            Id = 1,
            Name = "Street Fighter",
            Genre = "Fighting",
            Price = 19.99M,
            ReleaseDate = new DateTime(1991, 2, 1)
            },
            new Game(){
            Id = 2,
            Name = "Final Fantasy 14",
            Genre = "RPG",
            Price = 59.99M,
            ReleaseDate = new DateTime(2010, 9, 30)
            },
            new Game(){
            Id = 3,
            Name = "FIFA 23",
            Genre = "Sports",
            Price = 69.99M,
            ReleaseDate = new DateTime(2022, 9, 27)
            },
        };

        public static Game[] GetGames(){
            return games.ToArray();
        }
    }
}
```
Die 'GameClient' class importiert zunächst die 'Game' class um einzelne objects, die der 'Game' class entsprechen, zu erstellen.
In der 'GameClient' class wird eine Liste mit 3 'Game' objects erstellt, die der Struktur in der 'Game' class entsprechen.
Die 'GetGames' method gibt eine array mit 'Game' objects wieder, hier wird die zuvor erstellte Liste in eine Array mit 'ToArray()' umgewandelt.