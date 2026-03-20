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
- `Global Light 2D` n'est pas créé automatiquement par le template Universal 2D
  → à créer via `Hierarchy > Light > 2D > Global Light 2D`
- Les tags doivent être créés sans espace sinon `CompareTag` plante
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
- `Order in Layer` du Player à `3` pour passer devant tout
- `Tilemap_Ground` à `0`, `Tilemap_Corruption` à `2`
- `Composite Operation > Merge` = ancien `Used By Composite`
- Offset caméra Z à `-10` obligatoire en 2D
- Rigidbody2D du Tilemap en `Static`

---

### Session 04 — DayNightCycle · GlobalLight URP · ambiance
**Statut :** ✅ Terminée (2026-03-19)

#### Ce qui a été fait
| Étape | Action |
|---|---|
| 1 | `GlobalLight` créé via `Light > 2D > Global Light 2D` |
| 2 | `DayNightCycle.cs` créé dans `Scripts/Core/` |
| 3 | `GameManager` GameObject créé dans la Hierarchy |
| 4 | Cycle jour/nuit fonctionnel (60s jour / 40s nuit) |

#### Points de vigilance
- `dayDuration` et `nightDuration` réglables dans l'Inspector
- `public bool IsDay()` disponible pour les autres scripts
- Transition fluide via `Color.Lerp` et `Mathf.Lerp`

---

### Session 05 — Tuiles corrompues · purification au contact
**Statut :** ✅ Terminée (2026-03-19)

#### Ce qui a été fait
| Étape | Action |
|---|---|
| 1 | `Tilemap_Corruption` créée sur le Grid (Order in Layer 2) |
| 2 | Tuiles violettes placeholder peintes (`#4A0A6B`) |
| 3 | `CorruptionManager.cs` créé dans `Scripts/Core/` |
| 4 | `Purification.cs` créé dans `Scripts/Player/` |
| 5 | Purification fonctionnelle — tuiles disparaissent au contact |

#### Points de vigilance
- `Order in Layer` : Ground `0` · Corruption `2` · Player `3`
- `purificationRate` réglable dans l'Inspector (défaut 0.5s)
- `GetCorruptionCount()` disponible pour la jauge session 06

---

### Session 06 — SanctuaryZone · jauge de vie
**Statut :** ✅ Terminée (2026-03-19)

#### Ce qui a été fait
| Étape | Action |
|---|---|
| 1 | `SanctuaryZone` créé avec `Circle Collider 2D` (Is Trigger, Radius 3) |
| 2 | `SanctuaryHealth.cs` créé dans `Scripts/Core/` |
| 3 | `HealthBarUI.cs` créé dans `Scripts/UI/` |
| 4 | Canvas + Slider `HealthBar` créés en Screen Space Overlay |
| 5 | Jauge positionnée en haut à gauche (Anchor top left) |
| 6 | Jauge diminue uniquement la nuit — fonctionnel |

#### Points de vigilance
- `HealthBar` Slider doit être glissé dans `HealthBarUI` manuellement
- `onHealthChanged` branché sur `HealthBarUI > UpdateHealth`
- `onDeath` disponible pour le Game Over session 08
- `Heal()` disponible pour soigner le Sanctuaire plus tard
- `DayNightCycle` référencé dans `SanctuaryHealth` — dégâts uniquement la nuit

---

### Session 07 — EnemySpawner · pathfinding · vague nocturne
**Statut :** ✅ Terminée (2026-03-20)

#### Ce qui a été fait
| Étape | Action |
|---|---|
| 1 | Prefab `Enemy` créé (carré rouge, Rigidbody2D, Circle Collider 2D) |
| 2 | `EnemyAI.cs` créé dans `Scripts/Enemies/` |
| 3 | `EnemySpawner.cs` créé dans `Scripts/Enemies/` |
| 4 | Tag `Sanctuary` créé et assigné à `SanctuaryZone` |
| 5 | Ennemis spawent la nuit et se dirigent vers le Sanctuaire |
| 6 | Jauge descend uniquement la nuit avec les ennemis |

#### Points de vigilance
- `EnemyAI` doit être attaché au prefab `Enemy` (pas juste au GameObject)
- Tag `Sanctuary` sans espace sinon `CompareTag` plante
- `spawnRate` et `spawnRadius` réglables dans l'Inspector
- `if (dayNightCycle.IsDay()) return` dans `SanctuaryHealth` et `EnemySpawner`

---

### Session 08 — UI · Game Over · Restart
**Statut :** ✅ Terminée (2026-03-20)

#### Ce qui a été fait
| Étape | Action |
|---|---|
| 1 | `GameOverPanel` créé sur le Canvas (Panel noir semi-transparent) |
| 2 | `GameOverText` TextMeshPro créé ("GAME OVER") |
| 3 | `RestartButton` créé ("Recommencer") |
| 4 | `GameOverUI.cs` créé dans `Scripts/UI/` |
| 5 | `onDeath` branché sur `GameOverUI > ShowGameOver` |
| 6 | Bouton Restart branché sur `GameOverUI > Restart` |
| 7 | Boucle complète fonctionnelle |

#### Points de vigilance
- `Time.timeScale = 0f` pour pauser · `1f` pour reprendre
- `SceneManager.LoadScene` recharge la scène complète
- `GameOverPanel.SetActive(false)` au démarrage — caché par défaut

---

## 🎉 Prototype v1 complet !

### Boucle de jeu fonctionnelle
- ✅ Le druide bouge en top-down
- ✅ Tilemap forêt + caméra qui suit
- ✅ Cycle jour/nuit avec ambiance lumineuse
- ✅ Tuiles corrompues purifiables au contact
- ✅ Sanctuaire avec jauge de vie
- ✅ Ennemis nocturnes qui attaquent
- ✅ Game Over + Restart

### Prochaines étapes possibles
- [ ] Sprites pixel art (druide, ennemis, tuiles)
- [ ] Animations (marche 4 directions, purification)
- [ ] Sons et musique
- [ ] Menu principal
- [ ] Difficulté progressive (plus d'ennemis chaque nuit)
- [ ] Score / compteur de nuits survivées

---

## Structure du projet (Assets/)
```
Assets/
 ├── Mycora/
 │    ├── Scripts/
 │    │    ├── Player/
 │    │    │   ├── PlayerController.cs
 │    │    │   └── Purification.cs
 │    │    ├── Camera/
 │    │    │   └── CameraFollow.cs
 │    │    ├── Enemies/
 │    │    │   ├── EnemyAI.cs
 │    │    │   └── EnemySpawner.cs
 │    │    ├── UI/
 │    │    │   ├── HealthBarUI.cs
 │    │    │   └── GameOverUI.cs
 │    │    └── Core/
 │    │        ├── DayNightCycle.cs
 │    │        ├── CorruptionManager.cs
 │    │        └── SanctuaryHealth.cs
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
 │    │        └── Enemy.prefab
 │    ├── Scenes/
 │    │    ├── Production/
 │    │    │   └── Game.unity
 │    │    └── Sandbox/
 │    │        └── SampleScene.unity
 │    ├── Sprites/
 │    │    ├── Player/
 │    │    ├── Enemies/
 │    │    ├── Environment/
 │    │    │   ├── Tile_Ground_Placeholder
 │    │    │   └── Tile_Corruption_Placeholder
 │    │    └── UI/
 │    └── Tilemaps/
 │         └── Palettes/
 │             ├── Palette_Ground
 │             └── Palette_Corruption
 ├── ThirdParty/
 └── Settings/
```
