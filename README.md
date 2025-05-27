# 🚗 Automašīnu novietošanas spēle

**Automašīnu novietošanas spēle** ir Unity projekts, kurā spēlētājam jānovieto automašīnas pareizajās vietās. Spēlē tiek izmantota tagu sistēma un mēroga pārbaude, lai pārliecinātos, ka katra automašīna ir novietota pareizi.

## 🔧 Galvenās funkcijas:
- **Velc un nomet (Drag & Drop)** — spēlētājs var vilkt automašīnas un novietot tās pareizajās pozīcijās.
- **Mēroga pārbaude** — automašīnai jābūt pareizā izmērā, lai to varētu novietot.
- **Laika mērītājs** — parāda spēles laiku formātā `MM:SS`.
- **Zvaigžņu vērtējums** — spēlētājs saņem no 1 līdz 4 zvaigznēm atkarībā no pabeigšanas laika.
- **Pogas `Menu` un `Retry`** — pēc līmeņa pabeigšanas spēlētājs var restartēt spēli vai atgriezties izvēlnē.

## 📜 Skripti:
### `GameTimer.cs`  
Pārvalda spēles gaitu, laika atskaiti un rezultātu parādīšanu.

### `PlaceScript.cs`  
Apstrādā automašīnu novietošanu, pārbauda tagus un mērogu.

### `LevelTimer.cs`  
Parāda spēles laiku un fiksē gala rezultātu.

## 🎮 Vadība:
- **Velc automašīnu** uz pareizo vietu.
- Ja automašīna der, tā tiek fiksēta.
- Kad visas automašīnas ir novietotas, parādās rezultātu ekrāns ar laiku un zvaigznēm.

## 🛠 Instalēšana:
1. **Lejupielādē** projekta failus.
2. **Importē** tos Unity.
3. **Konfigurē `Canvas` un `UI`**, lai elementi tiktu pareizi attēloti.
4. **Palaiž spēli** un testē funkcionalitāti!

## 🚀 Izstrādāts ar ❤️ priekš Unity
