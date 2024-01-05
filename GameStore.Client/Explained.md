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