# MYCORA 2.0 — État du projet

## Moteur & config
- Unity 6.4 LTS — version 6000.4.0f1
- Pipeline : URP (template "Universal 2D")
- Genre : survie pixel art top-down
- Concept : un druide purifie une forêt corrompue le jour, défend son Sanctuaire la nuit

## Dépôt Git
- GitHub : https://github.com/Navy725/Mycora-2.0
- Branche principale : `main`
- Workflow de commit : `git add .` → `git commit -m "message"` → `git push`
- Premier commit : `init : projet Mycora 2.0 vierge Unity 6.4`

## Adaptations Unity 6 à retenir
- `rb.collisionDetectionMode = Continuous` est déprécié → on utilise `rb.interpolation = Interpolate`
- New Input System installé par défaut → réglé sur "Both" pour garder `Input.GetAxisRaw`
- Template "Universal 2D" préconfigure URP + caméra orthographique + paramètres 2D

---

## Sessions

### Session 01 — Le joueur dans la forêt
**Statut :** à venir
**Objectif :** un druide (placeholder) qui marche sur un sol de forêt (Tilemap), suivi par une caméra

#### Plan
| Étape | Script / Composant | Concept clé |
|---|---|---|
| 1 | `PlayerController.cs` | Awake / Update / FixedUpdate · Rigidbody2D · Input.GetAxisRaw |
| 2 | Tilemap (sol forêt) | Grid · Tilemap · TilemapCollider2D · peindre des tuiles |
| 3 | `CameraFollow.cs` | LateUpdate · Vector3.Lerp · référencer un Transform |

#### Résultat attendu
On lance le jeu, on marche dans une forêt verte (placeholder), la caméra suit doucement.

---

## Backlog global
- [ ] Session 02 — DayNightCycle · GlobalLight URP · ambiance
- [ ] Session 03 — Tuiles corrompues · purification au contact
- [ ] Session 04 — SanctuaryZone · jauge de vie
- [ ] Session 05 — EnemySpawner · pathfinding · vague nocturne
- [ ] Session 06 — UI · game over · restart · boucle complète

---

## Structure cible du projet (Assets/)
```
Assets/
 ├── Scripts/
 │    ├── Player/
 │    │    ├── PlayerController.cs
 │    │    └── CameraFollow.cs
 │    └── World/
 ├── Tilemaps/
 │    └── Palettes/
 ├── Sprites/
 │    └── Placeholders/
 └── Scenes/
      └── Game.unity
```
