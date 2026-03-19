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
- New Input System : on utilise les **callbacks** (`OnMove`, `OnJump`)
  et non l'ancien `Input.GetAxisRaw`
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

#### Points de vigilance pour la suite
- `groundLayer` doit être assigné dans l'Inspector
- `groundCheck` = Transform enfant à créer manuellement sous le Player
- Utiliser `linearVelocity` (Unity 6) et non l'ancien `velocity`

---

### Session 02 — Setup Inspector & premier test
**Statut :** 🔜 À venir
**Objectif :** brancher le PlayerController dans Unity et voir le joueur bouger

#### Plan
| Étape | Action | Concept clé |
|---|---|---|
| 1 | Créer l'asset `InputActions` | Actions Map · Binding WASD + Gamepad |
| 2 | Composant `Player Input` | Lier InputActions au GameObject |
| 3 | GameObject `GroundCheck` | Transform enfant · Physics2D.OverlapCircle |
| 4 | Configurer `Rigidbody2D` | Freeze Rotation Z · Collision Detection |
| 5 | Premier Play Mode | Tester mouvement + saut |

#### Résultat attendu
On lance le jeu, le druide (placeholder) se déplace et saute.

---

### Session 03 — Le monde : Tilemap forêt + caméra
**Statut :** 🔜 À venir
**Objectif :** un sol de forêt (Tilemap) et une caméra qui suit le joueur

#### Plan
| Étape | Script / Composant | Concept clé |
|---|---|---|
| 1 | Tilemap (sol forêt) | Grid · Tilemap · TilemapCollider2D · peindre des tuiles |
| 2 | `CameraFollow.cs` | LateUpdate · Vector3.Lerp · référencer un Transform |

#### Résultat attendu
On marche dans une forêt verte (placeholder), la caméra suit doucement.

---

## Backlog global
- [ ] Session 04 — DayNightCycle · GlobalLight URP · ambiance
- [ ] Session 05 — Tuiles corrompues · purification au contact
- [ ] Session 06 — SanctuaryZone · jauge de vie
- [ ] Session 07 — EnemySpawner · pathfinding · vague nocturne
- [ ] Session 08 — UI · game over · restart · boucle complète

---

## Structure du projet (Assets/)