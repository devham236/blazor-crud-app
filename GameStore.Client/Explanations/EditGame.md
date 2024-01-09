# EditGame Component

```bash
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

