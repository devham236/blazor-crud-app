# DeleteGame Component
Die 'DeleteGame' Komponente ist ein Bootstrap Modal Fenster, das geöffnet wird wenn man in der 'Home' Komponente auf den Delete button klickt.

```bash
<button class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#deleteModal" @onclick="(() => currentGame = game)">
    <i class="oi oi-x"></i>
</button>
```

Beim Klick des buttons wird eine callback ausgelöst, darin wird die currentgame variable mit der Instanz des aktuellen game in der games list gleichgesetzt.

In der Komponente wird ein Modal gerendert:
```bash
<h3>DeleteGame</h3>
<div class="modal fade" id="deleteModal" tabindex="-1" aria-labelledby="deleteModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="deleteModalLabel">@title</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-footer">
        <button @onclick="@Cancel" type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
        <button @onclick="@Confirm" type="button" class="btn btn-primary" data-bs-dismiss="modal">Delete</button>
      </div>
    </div>
  </div>
</div>
```
Der Title ist dynamisch und zeigt immer den Namen des Spiels an welches gelöscht werden soll.
Außerdem sind zwei buttons enthalten, einer für die Bestätigung des Löschvorgangs und einer fürs abbrechen.

```csharp
@code {
    [Parameter]
    public Game? Game {get; set;}

    [Parameter]
    public EventCallback<bool> OnClose {get; set;}

    private string title = string.Empty;

    protected override void OnParametersSet()
    {
        title = $"Delete {Game?.Name}?";
    }

    private void Confirm()
    {
        OnClose.InvokeAsync(true);
    }

    private void Cancel()
    {
        OnClose.InvokeAsync(false);
    }
}
```
Die 'Game' Variable repräsentiert das zu löschende Spiel, diese gewinnen wir durch einen Parameter.
'OnClose' ist ein 'EventCallback', diese methode ist mit der 'OnDeleteModalClose' methode in der 'Home' Komponente 'verbunden'.