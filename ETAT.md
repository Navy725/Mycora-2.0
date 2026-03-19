# MYCORA 2.0 — État du projet

## Moteur & config
- Unity 6.4 LTS — version 6000.4.0f1
- Pipeline : URP (template "Universal 2D")
- Genre : survie pixel art top-down
- Concept : un druide purifie une forêt corrompue le jour,
  défend son Sanctuaire la nuit

## Dépôt Git
- GitHub : https://github.com/Navy725/Mycora-2.0
- Branche principale : `main`
- Workflow de commit : `git add .` → `git commit -m "message"` → `git push`
- Premier commit : `init : projet Mycora 2.0 vierge Unity 6.4`

## Adaptations Unity 6 à retenir
- `rb.velocity` est renommé → `rb.linearVelocity`
- New Input System : on utilise les **callbacks** (`OnMove`)
  et non l'ancien `Input.GetAxisRaw`
- Utiliser `Invoke Unity Events` plutôt que `Send Messages` (plus fiable)
- `Tilemap Collider 2D` : l'option s'appelle `Composite Operation > Merge`
  et non `Used By Composite`
- Template "Universal 2D" préconfigure URP + caméra orthographique
  + paramètres 2D

---

## Sessions

### Session 01 — PlayerController.cs
**Statut :** ✅ Terminée (2026-03-19)

#### Ce qui a été fait
| Étape | Fichier | Concept clé |
|---|---|---|
| 1 | `PlayerController.cs` | Awake · Update · FixedUpdate · Rigidbody2D · New Input System |
| 2 | Structure projet | Dossier `Mycora/Scripts/Player/` créé |

#### Points de vigilance
- Utiliser `linearVelocity` (Unity 6) et non l'ancien `velocity`
- `Animator` protégé avec `if (animator == null) return`

---

### Session 02 — Setup Inspector & premier test
**Statut :** ✅ Terminée (2026-03-19)

#### Ce qui a été fait
| Étape | Action |
|---|---|
| 1 | Scène `Game.unity` créée dans `Scenes/Production/` |
| 2 | `SampleScene` déplacée dans `Scenes/Sandbox/` |
| 3 | GameObject `Player` (Square placeholder) créé |
| 4 | `Rigidbody2D` configuré (Gravity Scale 0, Freeze Rotation Z) |
| 5 | Asset `PlayerInputActions` créé avec bindings AZERTY (Z/Q/S/D) |
| 6 | Composant `Player Input` en mode `Invoke Unity Events` |
| 7 | `PlayerController.cs` réécrit pour le top-down |
| 8 | Premier test OK — mouvement 4 directions fonctionnel |

#### Points de vigilance
- Bindings AZERTY : Z/Q/S/D
- `Invoke Unity Events` utilisé à la place de `Send Messages`
- `Animator` protégé avec `if (animator == null) return`
- `Gravity Scale` à `0` sur le Rigidbody2D (top-down)

---

### Session 03 — Tilemap forêt + caméra
**Statut :** ✅ Terminée (2026-03-19)

#### Ce qui a été fait
| Étape | Action |
|---|---|
| 1 | Scène `Game.unity` ouverte dans `Scenes/Production/` |
| 2 | Grid + `Tilemap_Ground` créés |
| 3 | Sprite placeholder créé dans `Sprites/Environment/` |
| 4 | Tile Palette `Palette_Ground` créée dans `Tilemaps/Palettes/` |
| 5 | Sol peint en tuiles blanches |
| 6 | `Tilemap Collider 2D` + `Composite Collider 2D` (Merge) ajoutés |
| 7 | `CameraFollow.cs` créé dans `Scripts/Camera/` |
| 8 | Caméra suit le Player avec lissage |

#### Points de vigilance
- `Order in Layer` du Player à `1` pour passer devant le Tilemap
- `Composite Operation > Merge` = ancien `Used By Composite`
- Offset caméra Z à `-10` obligatoire en 2D
- Rigidbody2D du Tilemap en `Static`

---

### Session 04 — DayNightCycle · GlobalLight URP · ambiance
**Statut :** 🔜 À venir

---

## Backlog global
- [ ] Session 04 — DayNightCycle · GlobalLight URP · ambiance
- [ ] Session 05 — Tuiles corrompues · purification au contact
- [ ] Session 06 — SanctuaryZone · jauge de vie
- [ ] Session 07 — EnemySpawner · pathfinding · vague nocturne
- [ ] Session 08 — UI · game over · restart · boucle complète

---

## Structure du projet (Assets/)
```
Assets/
 ├── Mycora/
 │    ├── Scripts/
 │    │    ├── Player/
 │    │    │   └── PlayerController.cs
 │    │    ├── Camera/
 │    │    │   └── CameraFollow.cs
 │    │    ├── Enemies/
 │    │    ├── UI/
 │    │    └── Core/
 │    ├── Animations/
 │    │    └── Player/
 │    ├── Audio/
 │    │    ├── Music/
 │    │    └── SFX/
 │    ├── Input/
 │    │    └── PlayerInputActions.inputactions
 │    ├── Prefabs/
 │    │    ├── Player/
 │    │    └── Enemies/
 │    ├── Scenes/
 │    │    ├── Production/
 │    │    │   └── Game.unity
 │    │    └── Sandbox/
 │    │        └── SampleScene.unity
 │    ├── Sprites/
 │    │    ├── Player/
 │    │    ├── Enemies/
 │    │    ├── Environment/
 │    │    │   └── Tile_Ground_Placeholder
 │    │    └── UI/
 │    └── Tilemaps/
 │         └── Palettes/
 │             └── Palette_Ground
 ├── ThirdParty/
 └── Settings/
```
