# EditGame Component

```csharp
@inject NavigationManager NavigationManager
```

Mit NavigationManager haben wir Zugriff auf 'Routing functionality' innerhalb einer Komponente, ähnlich wie 'Link' und 'Path' in einer React Komponente.
Der erste Ausdruck bezeichnet das gewünschte Object bzw. das gewünschte 'package', der zweite Ausdruck bezeichnet den Namen der Variable, also unter welchen Namen das Objekt verfügbar ist (ähnlich wie import as "" from "")

```bash
<div class="row">
    <div class="col-sm-4">
        <EditForm Model="@game" OnSubmit="HandleSubmit">
            <div class="mb-3">
                <label for="name" class="form-label">Name:</label>
                <InputText id="name" @bind-Value="game.Name" class="form-control"></InputText>

            </div>
            <div class="mb-3">
                <label for="genre" class="form-label">Genre:</label>
                <InputSelect id="genre" @bind-Value="game.Genre" class="form-select">
                    <option value="">Select Genre</option>
                    <option value="Fighting">Fighting</option>
                    <option value="Kids and Family">Kids and Family</option>
                    <option value="Racing">Racing</option>
                    <option value="RPG">RPG</option>
                    <option value="Sports">Sports</option>
                </InputSelect>
            </div>
            <div class="mb-3">
                <label for="price" class="form-label">Price:</label>
                <InputNumber id="price" @bind-Value="game.Price" class="form-control"></InputNumber>
            </div>
            <div class="mb-3">
                <label for="releaseDate" class="form-label">Release Date:</label>
                <InputDate id="releaseDate" @bind-Value="game.ReleaseDate" class="form-control"></InputDate>
            </div>
            <button type="submit" class="btn btn-primary">Save</button>
            <button type="button" class="btn btn-secondary" @onclick="@Cancel">Cancel</button>
        </EditForm>
    </div>
</div>
```

Die 'EditGame' Komponente enthält eine 'EditForm' Komponente, ist eine eingebaute Blazor Komponente. Die Form Komponente hat einen 'onSubmit' handler die eine 'HandleSubmit' function auslöst.
Das 'Model=@game' bedeutet das die inputs in dem Form Element mit der 'game' variable verbunden ist, die 'game' Variable hat die 'Game' class als Typ.
In dem Form-Element sind mehrere divs mit label und input zu sehen. Jedes input hat eine '@bind-value' property die mit der entsprechenden property vom 'game' object verbunden ist. Ähnlich wie ein onChange handler bei einer React Komponente die dann den entsprechenden state verändert.
Zuletzt sind noch zwei button enthalten, einer ist der 'submit' button, der den onSubmit Handler auslöst wenn dieser geklickt wird, und der andere ist der 'save' button der die 'Cancel' function auslöst, wenn dieser geklickt wird.

```csharp
@code {
    private Game game = new()
        {
            Name = string.Empty,
            Genre = string.Empty,
            ReleaseDate = DateTime.UtcNow
        };

    private void HandleSubmit()
    {
        GameClient.AddGame(game);
        NavigationManager.NavigateTo("/");
    }

    private void Cancel()
    {
        NavigationManager.NavigateTo("/");
    }
}
```

Zunächst wird ein object mit der 'Game' class als typ und ein paar leeren properties initialisiert. Diese properties ändern ihren wert wenn in die entsprechenden inputs etwas eingegeben wird bzw. diese verändert werden.
Die 'HandleSubmit' function wird ausgelöst wenn der 'submit' button im Form-Element geklickt wird.
Darin wird die 'AddGame()' function in der 'GameClient' claass mit der zuvor erstellten 'game' variable, also dem object bzw. den properties des objects das mit den inputs verbunden ist, als argument ausgelöst.
Danach wird der User zum root path ("/") mithilfe der injection des NavigationManager navigiert.
Die 'Cancel' function wird ausgelöst wenn der 'cancel' button geklickt wird, dadurch wird der User zum root path ("/") navigiert

```csharp
public static void AddGame(Game game)
{
    game.Id = games.Max(game => game.Id) + 1;
    games.Add(game);
}
```

Die 'AddGame' function in der 'GameClient' class hat keinen Rückgabewert und hat 'game' mit dem typ 'Game' als Parameter.
Zunächst wird eine Id an den 'game' Parameter angeheftet bevor dieses der 'games' array bzw. list hinzugefügt wird. Die Id hat den höchsten Wert einer Id property eines einzelnen game in der 'games' array plus 1. Damit hat jedes neu hinzugefügte Spiel immer die Id des vorherigen letzten hinzugefügten spiel plus 1.
Danach wird mithilfe der '.Add()' method der game Parameter der 'games' list hinzugefügt.


# Edit existing Game functionality
Zurzeit wird die 'EditGame' Komponente aufgerufen, wenn man auf den 'New Game' button in der 'Home' Komponente klickt.
Mit folgenden Functions und Ergänzungen in der 'EditGame' Komponente, wird das bearbeiten von bereits in der Liste vorhandenen Games ermöglicht. Im Grunde checkt die Komponente zunächst ob eine 'Id' als Parameter vorliegt bzw. gleich null ist oder nicht, abhängig davon werden unterschiedliche HTML Elemente angezeigt und unterschiedliche code blocks ausgeführt.

```csharp
[Parameter]
public int? Id { get; set; }
    
private Game? game;

private string title = string.Empty;
```