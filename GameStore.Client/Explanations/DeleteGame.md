# DeleteGame Component
Die 'DeleteGame' Komponente ist ein Bootstrap Modal Fenster, das geöffnet wird wenn man in der 'Home' Komponente auf den Delete button klickt.

```bash
<button class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#deleteModal" @onclick="(() => currentGame = game)">
    <i class="oi oi-x"></i>
</button>
```

Beim Klick des buttons wird eine